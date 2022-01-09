using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BetButtonAction : MonoBehaviour {

	public Text sliderValText;
	public GameObject confirmBetButton;

	public GameObject sliderObject;
	Slider betSlider;

	public void showBetSlider()
	{
		sliderObject.SetActive (true);
		confirmBetButton.SetActive (true);

		sliderObject = GameObject.Find ("BetSlider");
		betSlider = sliderObject.GetComponent<Slider> ();

		//slider min value is minimum raise plus last bet amount
		betSlider.minValue = GameState.currentMinRaise + GameState.lastBetAmount;
			
		//slider max value is current player's total chips (chip amount plus bet amount before raise)
		int possibleMaxValue = GameState.currentPlayer.myChipAmount + GameState.currentPlayer.myBetAmount;
			
		//check if min value exceeds my total chips. If so, All in.
		if (betSlider.minValue >= possibleMaxValue) {
		
			//case all in
			//HIDE SLIDER, SLIDER VAL TEXT SHOULD READ "ALL IN? $ AMOUNT"
			betSlider.maxValue = betSlider.minValue;
			
		} else {
		
			betSlider.maxValue = possibleMaxValue;
		
		}

		//assign value to slider value text
		sliderValText.text = betSlider.value.ToString();
	}
}
