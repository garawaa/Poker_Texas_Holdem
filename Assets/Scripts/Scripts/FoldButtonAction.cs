using UnityEngine;
using System.Collections;

public class FoldButtonAction : MonoBehaviour {

	//MOVED TO PLAYER RPC
	public void Fold()
	{
//		//get the game object for chip and bet texts, get the BettingTextDisplay component to use betAmountText and chipAmountText
//		GameObject textGameObject = GameObject.Find ("Chip and Bet Amount Texts");
//		BettingTextDisplay btd = textGameObject.GetComponent<BettingTextDisplay> ();
//
//		//make the folded player color red
//		btd.chipAmountText [BettingTextDisplay.currentPlayerPos].color = Color.red;
//
//		var foldedPlayerPos = BettingTextDisplay.currentPlayerPos;
//
//		print ("Fold player position "+BettingTextDisplay.currentPlayerPos);
//
//		//move current player's bet amount to the pot
//		BettingTextDisplay.potAmountText.text = (int.Parse (BettingTextDisplay.potAmountText.text) + int.Parse (btd.betAmountText [BettingTextDisplay.currentPlayerPos].text)).ToString ();
//
//		//remove current player's bet amount (ANIMATE THIS GOING INTO THE POT?)
//		btd.betAmountText[BettingTextDisplay.currentPlayerPos].text = "FOLD";
//
//		//ANIMATE THE CARDS GOING TO DEALER?
//		GameObject cardObject = new GameObject();
//		cardObject = GameObject.Find ("Card0-" + BettingTextDisplay.currentPlayerPos);
//		cardObject.SetActive (false);
//		cardObject = GameObject.Find ("Card1-" + BettingTextDisplay.currentPlayerPos);
//		cardObject.SetActive (false);
//
//		//assign previous non-folded player position to previous player position
//		if (BettingTextDisplay.activePlayerPosList.IndexOf (BettingTextDisplay.currentPlayerPos) == 0) {
//
//			//if current folding player position is 0th index of active player position list, previous player position is at end of the list
//			BettingTextDisplay.previousPlayerPos = BettingTextDisplay.activePlayerPosList [BettingTextDisplay.activePlayerPosList.Count - 1];
//
//		} else {
//			
//			BettingTextDisplay.previousPlayerPos = BettingTextDisplay.activePlayerPosList[BettingTextDisplay.activePlayerPosList.IndexOf(BettingTextDisplay.currentPlayerPos)-1];
//		}
//
//		//finding the new current player position based on active player position list and folded player position
//		if (BettingTextDisplay.activePlayerPosList.IndexOf(foldedPlayerPos) == BettingTextDisplay.activePlayerPosList.Count-1) {
//
//			BettingTextDisplay.currentPlayerPos = BettingTextDisplay.activePlayerPosList[0];
//
//
//		} else {
//
//			BettingTextDisplay.currentPlayerPos = BettingTextDisplay.activePlayerPosList[BettingTextDisplay.activePlayerPosList.IndexOf(foldedPlayerPos) + 1];
//		}
//
//
//		btd.chipAmountText [BettingTextDisplay.currentPlayerPos].color = Color.yellow;
//		btd.chipAmountText [BettingTextDisplay.previousPlayerPos].color = Color.black;
//
//		//remove current player pos from active player pos list
//		BettingTextDisplay.activePlayerPosList.Remove(foldedPlayerPos);
//
//		//FOLDED PLAYER POS LIST: IS THIS NEEDED?
//		//BettingTextDisplay.foldedPlayerPosList.Add(foldedPlayerPos);
//
//		if (BettingTextDisplay.activePlayerPosList.Count == 1) {
//		
//			print ("winner");
//			//CURRENT PLAYER POSITION'S CHIP AMOUNT = CHIP AMOUNT + BET AMOUNT + POT AMOUNT
//		}
//
//		CheckBetEquality.CheckIfBetsAreEqual ();
//
	}
}
