using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BetSliderAction : MonoBehaviour {
	
	public void sliderValueChanged()
	{
		GameObject sliderObject = GameObject.Find ("BetSlider");
		Slider betSlider = sliderObject.GetComponent<Slider> ();

		Text sliderValText = GameObject.Find ("SliderValText").GetComponent<Text> ();

		//slider value text is equal to the slider value
		sliderValText.text = betSlider.value.ToString();
	}
}
