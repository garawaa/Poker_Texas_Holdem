using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class GameState : Photon.MonoBehaviour
{

	public static string[] shuffledDeck;

	public static int potAmount;

	public static List<PhotonPlayer> GameBeginPlayerList; // = GamePlayManager.playerList;

	public static PhotonPlayer currentPlayer;
	public static PhotonPlayer dealer, smallBlindPlayer, bigBlindPlayer;

	//straddle only exists if he decides to bet before the cards are dealt
	public static PhotonPlayer straddlePlayer;

	public static int smallBlindAmount, bigBlindAmount, straddleAmount;

	public static int lastBetAmount;

	public static int currentMinRaise;

	//the betting rounds and showdown
	public enum Rounds { isPreDeal, isPreFlop, isFlop, isTurn, isRiver, isShowdown }

	public static Rounds currentRound;

	void SyncVarialbes()
	{
		currentRound = (Rounds)PhotonNetwork.room.CustomProperties["currentRound"];
		shuffledDeck = (string[])PhotonNetwork.room.CustomProperties["shuffledDeck"];
		currentPlayer = (PhotonPlayer)PhotonNetwork.room.CustomProperties["currentPlayer"];
		dealer = (PhotonPlayer)PhotonNetwork.room.CustomProperties["dealer"];
		smallBlindPlayer = (PhotonPlayer)PhotonNetwork.room.CustomProperties["smallBlindPlayer"];
		bigBlindPlayer = (PhotonPlayer)PhotonNetwork.room.CustomProperties["bigBlindPlayer"];
		straddlePlayer = (PhotonPlayer)PhotonNetwork.room.CustomProperties["straddlePlayer"];
		smallBlindAmount = (int)PhotonNetwork.room.CustomProperties["smallBlindAmount"];
		bigBlindAmount = (int)PhotonNetwork.room.CustomProperties["bigBlindAmount"];
		straddleAmount = (int)PhotonNetwork.room.CustomProperties["straddleAmount"];
		lastBetAmount = (int)PhotonNetwork.room.CustomProperties["lastBetAmount"];
		currentMinRaise = (int)PhotonNetwork.room.CustomProperties["currentMinRaise"];
		potAmount = (int)PhotonNetwork.room.CustomProperties["potAmount"];
	}
	public static void SetsmallBlindPlayer(PhotonPlayer p)
	{
		Hashtable hash = new Hashtable();
		hash.Add("smallBlindPlayer", p);
		PhotonNetwork.room.SetCustomProperties(hash);
		smallBlindPlayer = p;
	}
	public static void SetbigBlindPlayer(PhotonPlayer p)
	{
		Hashtable hash = new Hashtable();
		hash.Add("bigBlindPlayer", p);
		PhotonNetwork.room.SetCustomProperties(hash);
		bigBlindPlayer = p;
	}
	public static void SetstraddlePlayer(PhotonPlayer p)
	{
		Hashtable hash = new Hashtable();
		hash.Add("straddlePlayer", straddlePlayer);
		PhotonNetwork.room.SetCustomProperties(hash);
		straddlePlayer = p;
	}
	public static void SetsmallBlindAmount(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("smallBlindAmount", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
		smallBlindAmount = amount;
	}
	public static void SetbigBlindAmount(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("bigBlindAmount", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
		bigBlindAmount = amount;
	}
	public static void SetstraddleAmount(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("straddleAmount", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
		straddleAmount = amount;
	}
	private void Update()
	{
		if (PhotonNetwork.room != null)
		{
			SyncVarialbes();
		}
	}
	public static void OnGameStarted()
	{

		//this is a permanent snapshot of playerlist at beginning of game. Used to find current player
		//at beginning of each new round
		//GameBeginPlayerList = GamePlayManager.playerList;

		//TODO: GRAB THIS FROM SERVER 
		
		int smallBlindAmount = PlayerPrefs.GetInt("Stake", 1000);
		int bigBlindAmount = 2 * smallBlindAmount;
		int lastBetAmount = bigBlindAmount;
		int straddleAmount = 2 * bigBlindAmount;
		int currentMinRaise = 2;
		SetsmallBlindAmount(smallBlindAmount);
		SetbigBlindAmount(bigBlindAmount);
		GamePlayManager.SetlastBetAmount(lastBetAmount);
		SetstraddleAmount(straddleAmount);
		GamePlayManager.SetcurrentMinRaise(currentMinRaise);
		//make smallblindplayer the next player in list after dealer
		if (GamePlayManager.playerList.IndexOf(dealer) == PhotonNetwork.playerList.Length - 1)
		{
			PhotonPlayer smallBlindPlayer = GamePlayManager.playerList[0];
			SetsmallBlindPlayer(smallBlindPlayer);
		}
		else
		{
			PhotonPlayer smallBlindPlayer = GamePlayManager.playerList[GamePlayManager.playerList.IndexOf(dealer) + 1];
			SetsmallBlindPlayer(smallBlindPlayer);
		}

		//assign big blind player
		if (GamePlayManager.playerList.IndexOf(smallBlindPlayer) == GamePlayManager.playerList.Count - 1)
		{
			PhotonPlayer bigBlindPlayer = GamePlayManager.playerList[0];
			SetbigBlindPlayer(bigBlindPlayer);
		}
		else
		{
			PhotonPlayer bigBlindPlayer = GamePlayManager.playerList[GamePlayManager.playerList.IndexOf(smallBlindPlayer) + 1];
			SetbigBlindPlayer(bigBlindPlayer);
		}
		//assign straddle player
		if (GamePlayManager.playerList.IndexOf(bigBlindPlayer) == GamePlayManager.playerList.Count - 1)
		{
			PhotonPlayer straddlePlayer = GamePlayManager.playerList[0];
			SetstraddlePlayer(straddlePlayer);
		}
		else
		{
			PhotonPlayer straddlePlayer = GamePlayManager.playerList[GamePlayManager.playerList.IndexOf(bigBlindPlayer) + 1];
			SetstraddlePlayer(straddlePlayer);
		}
		Debug.Log("BA");
		Debug.Log(dealer.ID);
		Debug.Log(smallBlindPlayer.ID);
		Debug.Log(bigBlindPlayer.ID);
		Debug.Log(straddlePlayer.ID);
		Debug.Log("BA");
	}
}
