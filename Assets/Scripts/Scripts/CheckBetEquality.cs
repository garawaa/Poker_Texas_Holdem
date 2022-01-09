using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CheckBetEquality : MonoBehaviour {

	//all bet amounts combined
	static int totalBetsAmount;
	public static bool CheckIfBetsAreEqual()
	{
		//this is the return value
		bool betsAreEqual = false;

		//if bets are equal, this is the bet amount of each player
		int betAmount = 0;
		
		//check if all bets are equal. If so, move bets to pot and begin next round or showdown
		for (var i = 0; i < GamePlayManager.playerList.Count - 1; i++) {

			if (GamePlayManager.playerList[i].myBetAmount != GamePlayManager.playerList[i+1].myBetAmount) {
			
				//betsAreEqual = false;
				break;
			
			//checked the last 2 players and they have equal bet amount
			} else if (i == GamePlayManager.playerList.Count - 2) {
				
				betAmount = GamePlayManager.playerList[i].myBetAmount;

				//total of all bets combined
				//totalBetsAmount = betAmount * GamePlayManager.playerList.Length;
				GamePlayManager.SetTotalBetsAmount(betAmount * GamePlayManager.playerList.Count);
				betsAreEqual = true;
			}
		}

		return betsAreEqual;
	
	}

	//moves all bets to pot, goes to next round, or does winning logic (if current round is showdown)
	public static void MoveBetsToPot()
	{

		//add all bets to pot
		int pot = GamePlayManager.GetPotAmount() + GamePlayManager.GetTotalBetsAmount();
		GamePlayManager.SetPotAmount(pot);
		//removing bet amounts from table (bets go into pot)
		for (var i = 0; i < GamePlayManager.playerList.Count; i++) {

			GamePlayManager.playerList [i].myBetAmount = 0;
		}
		//ANIMATE THE BETS TO THE POT
		print("moved bets to pot " +GamePlayManager.GetTotalBetsAmount());

		//move to next round if not at showdown
		if (GameState.currentRound != GameState.Rounds.isShowdown) {

			if (GameState.currentRound == GameState.Rounds.isPreFlop) {

				//Deal the flop 
				GameObject flopObject = GameObject.Find ("FlopDeal");
				FlopDeal fd = flopObject.GetComponent<FlopDeal> ();

				fd.Flop ();
			
			} 
			else if (GameState.currentRound == GameState.Rounds.isFlop) 
			{
				//DEAL THE TURN CARD
			}
			else if (GameState.currentRound == GameState.Rounds.isTurn) 
			{
				//DEAL THE RIVER CARD
			}

			//go to the next round
			//GameState.Rounds c = GameState.currentRound + 1;
			//GamePlayManager.SetCurrentRound(c);
			//GameState.currentRound++;

		} else //current round is showdown 
		{

			//TODO: SHOW THE CARDS OF THE PLAYERS IN SHOWDOWN
			//TODO: ANIMATE WINNER SCENE

			GamePlayManager.AddPointsToWinners ();

		}
	}

}
