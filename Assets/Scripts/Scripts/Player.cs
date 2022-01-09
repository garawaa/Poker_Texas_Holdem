using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class Player : Photon.MonoBehaviour {

	public int ID;

	public int myChipAmount;

	public int myBetAmount;

	public Hand hand;

	//the overall points from winning hands
	public int points;

	public int wins;

	public int losses;

	//initializer (NEED THIS??)
	public Player(int id) {
	
		ID = id;	
	}

	void Update()
	{
		//rename my player object "me"
		if (photonView.isMine) {
		
			gameObject.name = "me";
		}
		
	}

//	[PunRPC]
//	public void Call()
//	{
//		//TODO: IF STRADDLE JUST CALLED, MAKE STRADDLE NULL. ALSO BIG BLIND

//		foreach (Player player in GamePlayManager.playerList) {
		
//			if (player.ID == 1) {
			
//				player.myBetAmount++;
//				//GameObject.Find ("MyBetAmountText").GetComponent<Text> ().text = player.myBetAmount.ToString ();
//			}
//		}

//		//add back my previous bet to my chips stack
//		myChipAmount += myBetAmount;
//		myBetAmount = GameState.lastBetAmount;

//		myChipAmount -= myBetAmount;
	

//		//the possible new current player (if bets are not equal or if he is the straddle)
//		Player newCurrentPlayer;

//		//make next player the possible new current player
//		if (GamePlayManager.playerList.IndexOf (GameState.currentPlayer) == GamePlayManager.playerList.Count - 1) {

//			newCurrentPlayer = GamePlayManager.playerList [0];

//		} else {
		
//			newCurrentPlayer = GamePlayManager.playerList [GamePlayManager.playerList.IndexOf (GameState.currentPlayer) + 1];
//		}

//		//if the round is pre-flop, straddle or big blind can raise or check (if bets are equal)
//		if (GameState.currentRound == GameState.Rounds.isPreFlop) 
//		{
//			//if straddle player exists
//			if (GameState.straddlePlayer != null) {
				
//				if (CheckBetEquality.CheckIfBetsAreEqual () && newCurrentPlayer != GameState.straddlePlayer) {
//					CheckBetEquality.MoveBetsToPot ();
//					GameState.currentRound++;

//					//TODO: MAKE FIRST PERSON TO LEFT OF DEALER THE NEW CURRENT PLAYER
				
//				} else {
				
//					GameState.currentPlayer = newCurrentPlayer;
//				}


//			} else { //straddle player doesn't exist so big blind has option of betting/checking

//				if (CheckBetEquality.CheckIfBetsAreEqual () && newCurrentPlayer != GameState.bigBlindPlayer) {
//					CheckBetEquality.MoveBetsToPot ();
//					GameState.currentRound++;

//					//TODO: MAKE FIRST PERSON TO LEFT OF DEALER THE NEW CURRENT PLAYER
				
//				} else {

//					GameState.currentPlayer = newCurrentPlayer;
//				}
			
//			}

//		} else //round is not preflop
		
//		{ 
//			//if bets are equal
//			if (CheckBetEquality.CheckIfBetsAreEqual ()) {
			
//				CheckBetEquality.MoveBetsToPot ();

//				//if showdown
//				if (GameState.currentRound == GameState.Rounds.isShowdown) {
				
//					GamePlayManager.AddPointsToWinners ();

//					//TODO: ANIMATE THE WIN, START NEW GAME

//				} else {
				
//					GameState.currentRound++;

//					//TODO: MAKE FIRST PERSON TO LEFT OF DEALER THE NEW CURRENT PLAYER
//				}
			
//			} else { //bets are not equal
			
//				GameState.currentPlayer = newCurrentPlayer;
				
//			}
//		}
//	}

//	//when the player confirms that he wants to bet the slider amount
//	[PunRPC]
//	public void ConfirmBet()
//	{
//		//TODO: IF STRADDLE JUST BET, MAKE STRADDLE NULL. ALSO BIG BLIND

//		GameObject sliderObject = GameObject.Find ("BetSlider");
//		Slider betSlider = sliderObject.GetComponent<Slider> ();

//		var betSliderValInt = (int)betSlider.value;

//		//new current minimum raise is the new bet amount (slider value) - previous player's bet amount
//		GameState.currentMinRaise = betSliderValInt - GameState.lastBetAmount;

//		//update the last bet amount to be the new bet
//		GameState.lastBetAmount = betSliderValInt;

//		//new chip amount = chip amount + bet amount - new bet amount (betslider's value)
//		myChipAmount = myChipAmount + myBetAmount - GameState.lastBetAmount;

//		//new bet amount of current player becomes the slider value
//		myBetAmount = GameState.lastBetAmount;


//		//go to next player as current player
//		if (GamePlayManager.playerList.IndexOf (GameState.currentPlayer) == GamePlayManager.playerList.Count - 1) {
		
//			GameState.currentPlayer = GamePlayManager.playerList [0];
		
//		} else {

//			GameState.currentPlayer = GamePlayManager.playerList[GamePlayManager.playerList.IndexOf (GameState.currentPlayer)+1];
//		}

//		//hide slider, slider text, confirm button
//		sliderObject.SetActive(false);
//		GameObject.Find ("ConfirmBetButton").SetActive (false);
//		GameObject.Find ("SliderValText").GetComponent<Text> ().text = "";

//		//CHECK FOR STRADDLE/BIG BLIND IF GAME STATE IS PREFLOP. CHECK BET EQUALITY IF NOT

//	}

//	[PunRPC]
//	public void Fold()
//	{

//		//ANIMATE CARDS TO DEALER

//		//move my bet to the pot
//		GameState.potAmount += myBetAmount;
//		myBetAmount = 0;

//		//ANIMATE BET CHIPS TO POT

//		//save index of folded player
//		int indexOfFoldedPlayer = GamePlayManager.playerList.IndexOf (GameState.currentPlayer);

//		//remove the player from playerList
//		GamePlayManager.playerList.RemoveAt (GamePlayManager.playerList.IndexOf (GameState.currentPlayer));

//		//if only 1 player left, he is the winner
//		if (GamePlayManager.playerList.Count == 1) {
		
//			print ("Winner ID " + GamePlayManager.playerList [0].ID);

//			//add winPoints and a win to the winner
//			GamePlayManager.AddPointsToWinners ();

//			//move the pot to the winner
//			GamePlayManager.playerList [0].myChipAmount += GameState.potAmount;
//			GameState.potAmount = 0;

//			//START NEW GAME

//		//else assign the new current player and continue game
//		} else {

//			//the possible new current player (if bets are not equal or if he is the straddle)
//			Player newCurrentPlayer;

//			//make next player the possible new current player
//			//if the folded player was at the last index of the playerList before folding
//			if (indexOfFoldedPlayer == GamePlayManager.playerList.Count) {

//				newCurrentPlayer = GamePlayManager.playerList [0];

//			//new current player is at same index of folded player in the smaller playerList
//			} else {
				
//				newCurrentPlayer = GamePlayManager.playerList [indexOfFoldedPlayer];
//			}
		

//			//COPIED FROM CALL FUNCTION
//			//check if new current player is straddle. If not, check if bets are equal
//			//ALSO CHECK IF PRE-FLOP?
//			if (newCurrentPlayer == GameState.straddlePlayer) {


//				if (CheckBetEquality.CheckIfBetsAreEqual ()) {

//					//MOVE BETS TO POT AND DEAL THE NEW COMM CARDS DEPENDING ON GAME STATE
//					//NEED TO SPLIT UP THE CHECKIFBETSEQUAL FUNCTION

//				} else {

//					GameState.currentPlayer = newCurrentPlayer;			
//				}

//			//if new current player is the straddle, he has option of raising or checking
//			} else {

//				GameState.currentPlayer = newCurrentPlayer;

//			}
		
//		}
//	}
		
//	[PunRPC]
//	public void Check()
//	{
//		//CHECK BUTTON SHOULD NOT BE VISIBLE IF PLAYER CAN'T CHECK

//		//TODO: can't check during pre-flop unless you are straddle/big blind

//		//move the current player to the next player if bet is equal to previous bet
//		if (GameState.currentPlayer.myBetAmount == GameState.lastBetAmount) {

//			//if all bets are equal, move the bets to the pot and go to the next round
//			if (CheckBetEquality.CheckIfBetsAreEqual ()) {
			
//				GameObject cbeObject = GameObject.Find ("CheckBetEquality");
//				CheckBetEquality cbe = cbeObject.GetComponent<CheckBetEquality> ();

//				//move bets to pot after delay
//				cbe.Invoke ("MoveBetsToPot", 2f);

//				//GO TO THE NEXT GAMESTATE.ROUNDS!!!!
			
//			//assign the new current player
//			} else {

//				//make next player the new current player
//				if (GamePlayManager.playerList.IndexOf (GameState.currentPlayer) == GamePlayManager.playerList.Count - 1) {

//					GameState.currentPlayer = GamePlayManager.playerList [0];

//				} else {

//					GameState.currentPlayer = GamePlayManager.playerList [GamePlayManager.playerList.IndexOf (GameState.currentPlayer) + 1];
//				}
//			}
		
//		} else {
		
//			//CHECK BUTTON DOES NOTHING IF MY BET DOES NOT EQUAL PREVIOUS BET
//		}
//	}

//	[PunRPC]
//	public void Straddle()
//	{
//		//straddle player bets straddle amount
//		GameState.currentPlayer.myBetAmount = GameState.straddleAmount;
//		GameState.currentPlayer.myChipAmount -= GameState.straddleAmount;

//		//TODO: DEAL CARDS HERE
//		//HOW DO I MAKE SURE EVERY PLAYER SEES THIS ANIMATION??

////		//AT THIS POINT, THIS CODE GENERATES ENTIRE 7 CARD HAND FOR THE PLAYERS PRESENT
////		//generate the 2 card hands
////		GamePlayManager.GenerateTwoCardHands ();
////		//generate the community cards to add to 7 card hands
////		GamePlayManager.GenerateCommCards ();
////		//create the hand object for each player (also creates player.hand.twoCardList)
////		GamePlayManager.GeneratePlayerHands ();

//		//make next player the new current player
//		if (GamePlayManager.playerList.IndexOf (GameState.currentPlayer) == GamePlayManager.playerList.Count - 1) {

//			GameState.currentPlayer = GamePlayManager.playerList [0];

//		} else {

//			GameState.currentPlayer = GamePlayManager.playerList [GamePlayManager.playerList.IndexOf (GameState.currentPlayer) + 1];
//		}

//	}

//	[PunRPC]
//	public void PassStraddle()
//	{
//		//straddle is no longer defined for current game
//		GameState.straddlePlayer = null;

//		//current player is already the right one

//		//TODO: DEAL CARDS HERE

//	}

}
