using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CallButtonAction : MonoBehaviour {

	//MOVED TO PLAYER RPC
	public void Call()
	{

		//GameObject textGameObject = GameObject.Find ("Chip and Bet Amount Texts");
		//BettingTextDisplay btd = textGameObject.GetComponent<BettingTextDisplay> ();

		//var currentPlayerPos = BettingTextDisplay.currentPlayerPos;
		//var previousPlayerPos = BettingTextDisplay.previousPlayerPos;

		////current player's chips equals chips + previous bet - current bet
		//btd.chipAmountText [currentPlayerPos].text = (int.Parse(btd.chipAmountText[currentPlayerPos].text) + int.Parse(btd.betAmountText [currentPlayerPos].text) - int.Parse(btd.betAmountText [previousPlayerPos].text)).ToString(); 

		////current player's bet equals previous player's bet
		//btd.betAmountText [currentPlayerPos].text = btd.betAmountText [previousPlayerPos].text;


		////assign current player to previous player before incrementing to next player
		//BettingTextDisplay.previousPlayerPos = BettingTextDisplay.currentPlayerPos;

		////finding the new current player position based on active player position list
		//if (BettingTextDisplay.activePlayerPosList.IndexOf(BettingTextDisplay.previousPlayerPos) == BettingTextDisplay.activePlayerPosList.Count-1) {

		//	BettingTextDisplay.currentPlayerPos = BettingTextDisplay.activePlayerPosList[0];


		//} else {

		//	BettingTextDisplay.currentPlayerPos = BettingTextDisplay.activePlayerPosList[BettingTextDisplay.activePlayerPosList.IndexOf(BettingTextDisplay.previousPlayerPos) + 1];
		//}

		//btd.chipAmountText [BettingTextDisplay.currentPlayerPos].color = Color.yellow;
		//btd.chipAmountText [BettingTextDisplay.previousPlayerPos].color = Color.black;


		////CHECK FOR STRADDLE
		//CheckBetEquality.CheckIfBetsAreEqual ();
	}
}
