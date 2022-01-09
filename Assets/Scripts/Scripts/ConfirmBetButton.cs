using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfirmBetButton : MonoBehaviour {

	public Text sliderValText;

	public void ConfirmBet()
	{
		//MOVED TO PLAYER SCRIPT

//		//creating the BettingTextDisplay reference
//		GameObject textObject = GameObject.Find("Chip and Bet Amount Texts");
//		BettingTextDisplay btd = textObject.GetComponent<BettingTextDisplay> ();

//		//creating the slider reference
//		GameObject sliderObject = GameObject.Find ("BetSlider");
//		Slider betSlider = sliderObject.GetComponent<Slider> ();
//
//		//the current value of the slider on click
//		var betSliderValInt = (int)betSlider.value;
//
//		//new current minimum raise is the new bet amount (slider value) - previous player's bet amount
//		GameState.currentMinRaise = betSliderValInt - GameState.lastBetAmount;
//
//		//update the last bet amount to be the new bet
//		GameState.lastBetAmount = betSliderValInt;
//
//		//chip amount = chip amount + bet amount - new bet amount (betslider's value)
//		GameState.currentPlayer.myChipAmount = GameState.currentPlayer.myChipAmount + GameState.currentPlayer.myBetAmount - GameState.lastBetAmount;
//
//		//bet amount of current player becomes the slider value
//		GameState.currentPlayer.myBetAmount = GameState.lastBetAmount;

//		//assign current player (before incrementing) to previous player
//		BettingTextDisplay.previousPlayerPos = BettingTextDisplay.currentPlayerPos;


//		//finding the new current player position based on active player position list (COPIED FROM CALLBUTTONACTION SCRIPT)
//		if (BettingTextDisplay.activePlayerPosList.IndexOf(BettingTextDisplay.previousPlayerPos) == BettingTextDisplay.activePlayerPosList.Count-1) {
//
//			BettingTextDisplay.currentPlayerPos = BettingTextDisplay.activePlayerPosList[0];
//
//
//		} else {
//
//			BettingTextDisplay.currentPlayerPos = BettingTextDisplay.activePlayerPosList[BettingTextDisplay.activePlayerPosList.IndexOf(BettingTextDisplay.previousPlayerPos) + 1];
//		}
//
//		btd.chipAmountText [BettingTextDisplay.currentPlayerPos].color = Color.yellow;
//		btd.chipAmountText [BettingTextDisplay.previousPlayerPos].color = Color.black;
//
//		//hide slider, slider text, confirm button
//		sliderObject.SetActive(false);
//		sliderValText.text = "";
//		gameObject.SetActive (false);	//confirm bet button

	}
}
