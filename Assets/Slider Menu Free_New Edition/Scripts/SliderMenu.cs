using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//===========================Begin Scroll Type And Scrollbar Direction================================
public enum scrolltype{
	Horizontal,Vertical
}
//============================End Scroll Type And Scrollbar Direction=================================


//==================================Begin Slides Align (Pro Only)=====================================
public enum slidesverticalalign{
	Top,Middle,Bottom
}
public enum slideshorizontalalign{
	Left,Center,Right
}
//========================================End Slides Align============================================


//=============================Begin Previous Button Align (Pro Only)=================================
public enum previousbuttonhorizontalalign{
	Left,Center,Right
}
public enum previousbuttonverticalalign{
	Top,Middle,Bottom
}
//====================================End Previous Button Align=======================================


//===============================Begin Next Button Align (Pro Only)===================================
public enum nextbuttonhorizontalalign{
	Left,Center,Right
}
public enum nextbuttonverticalalign{
	Top,Middle,Bottom
}
//======================================End Next Button Align=========================================



public class SliderMenu : MonoBehaviour {
	

	//=======================================Begin Main Objects===========================================
	public		bool							MainObjectBlock;
	public 		Canvas 							SliderMenuCanvas;										//Custom Canvas Object (Scroll Object Parent)
	public 		GameObject 						ScrollObject;											//Object That has Scroll Rect Component (Slides Content Parent)
	public 		GameObject 						SlidesContent;											//Slides Parent
	public 		List<GameObject> 				Slides;													//Slides
	//========================================End Main Objects============================================

	//======================================Begin Scroll Settings=========================================
	public		bool							ScrollSettingsBlock;
	public 		scrolltype 						ScrollType;												//Scroll type is horizontal or vertical

	//-------------------------------------------------------------------------------Horizontal scroll bar
	public		bool 							ShowHorizontalScrollbar; 								//Enable or disable horizontal scrollbar
	public 		Scrollbar 						HorizontalScrollbar;									//Horizontal Scrollbar Object
	public 		slidesverticalalign 			SlidesVerticalAlign;									//Slide's Vertical Align (Pro Only)

	//---------------------------------------------------------------------------------Vertical scroll bar
	public		bool 							ShowVerticalScrollbar;									//Enable or disable vertical scrollbar
	public 		Scrollbar 						VerticalScrollbar;										//Vertical Scrollbar Object
	public 		slideshorizontalalign 			SlidesHorizontalAlign;									//Slide's Horizontal Align (Pro Only)

	//------------------------------------------------------------------------Scroll With Arrow (Pro Only)
	public		bool							ScrollWithArrowBlock;
	public 		bool 							ScrollWithArrow;										//Enable Scroll With Arrow Keys
	public 		bool 							LeftAndRight;											//Enable Scroll With Left And Right Arrow Keys
	public		bool							HorizontalArrowStepByStep;								//Step By Step
	public 		bool 							UpAndDown;												//Enable Scroll With Down And Up Arrow Keys
	public		bool							VerticalArrowStepByStep;								//Step By Step

	public		float							ArrowTransition	= 0.1f;									//Transition Value
	//---------------------------------------------------------------------------------Scroll With Buttons
	public		bool							ScrollWithButtonsBlock;
	public 		bool 							ScrollWithButtons 				= true;					//Enable Scroll With Buttons
	public 		GameObject 						ScrollButtons;											//Define Scroll Buttons Group Object

	//Previous Button
	private 	GameObject 						PreviousButtonObject;									//For Define Previous Button Object (Automatically)
	public 		Sprite 							PreviousButtonImage;									//Previous Button Image
	public 		previousbuttonhorizontalalign 	PreviousButtonHorizontalAlign;							//Previous Button's Horizontal Align (Pro Only)
	public 		previousbuttonverticalalign 	PreviousButtonVerticalAlign;							//Previous Button's Vertical Align (Pro Only)
	public 		Vector4 						PreviousButtonMargin;									//Previous Button's Margin
	private 	bool 							PreviousButtonActive			= true;					//If The First Slide Is Active Previous Button Will Disable

	//Next Button
	private 	GameObject 						NextButtonObject;										//For Define Next Button Object (Automatically)
	public 		Sprite 							NextButtonImage;										//Next Button Image
	public 		nextbuttonhorizontalalign 		NextButtonHorizontalAlign;								//Next Button's Horizontal Align (Pro Only)
	public 		nextbuttonverticalalign 		NextButtonVerticalAlign;								//Next Button's Vertical Align (Pro Only)
	public 		Vector4 						NextButtonMargin;										//Next Button's Margin
	private 	bool 							NextButtonActive				= true;					//If The Last Slide Is Active Next Button Will Disable

	public 		float 							ButtonTransition;										//Button's Transition

	//--------------------------------------------------------------------------------Slider Magnet Effect
	public 		bool 							SliderMagnet;											//Enable Slider Magnet Effect
	public 		float 							MagnetTransition;										//Transition For Slider Magnet Effect
	//=======================================End Scroll Settings==========================================



	//======================================Begin Slides Property=========================================
	public		bool							SlidesPropertyBlock;
	public 		int 							SlidesInView;											//Number Of Slides In View
	public 		bool 							DefaultOffset;											//Enable Default Offset For Active Slide (Pro Only)
	public 		int 							ActiveSlideOffset;										//Define Active Slide Offset If Default Offset Is Disabled (Pro Only)
	public 		Vector2 						SlideSize;												//Slide Size Vector (x For Width And y For Height)
	public 		Vector4 						SlideMargin;											//Slide Margin Vector(x For Margin Top, y For Margin Right, z For Margin Bottom, And w For Margin Left)
	//=======================================End Slides Property==========================================

	//=========================================Begin Animation============================================
	public		bool							AnimationBlock;
	//############################################################Begin Previous Slides Animation Settings
	//Position Animation
	public		bool							PreviousPositionAnimation;
	public 		float 							PreviousOffset;											
	public 		float 							PreviousOffsetTransition 	= 0.1f;						

	//Scale Animation
	public		bool							PreviousScaleAnimation;
	public 		Vector2 						PreviousScale				= new Vector2(1,1);			
	public 		float 							PreviousScaleTransition 	= 0.1f;						

	//Rotation Animation
	public		bool							PreviousRotateAnimation;
	public 		Vector3 						PreviousRotation			= new Vector3(1,1,1);		
	public 		float 							PreviousRotationTransition 	= 0.1f;						

	//Color Animation
	public		bool							PreviousColorAnimation;
	public 		Color 							PreviousColor				= new Color(1,1,1,255);		
	public 		float 							PreviousColorTransition 	= 0.1f;						

	//Blur Animation
	public		bool 							PreviousBlurAnimation;									
	public		Material						PreviousBlurMaterial;									//(Pro Only)								
	public		float							PreviousBlurDistance		= 0.02f;	 				//(Pro Only)				 
	public		float							PreviousBlurTransition		= 0.01f;					//(Pro Only)

	//Order
	public		int								PreviousSiblingIndex;									//(Pro Only)									
	//##############################################################End Previous Slides Animation Settings


	//##############################################################Begin Active Slides Animation Settings
	//Position Animation
	public		bool							ActivePositionAnimation;
	public 		float 							ActiveOffset;											
	public 		float 							ActiveOffsetTransition 		= 0.1f;						

	//Scale Animation
	public		bool							ActiveScaleAnimation;
	public 		Vector2 						ActiveScale 				= new Vector2(1,1);			
	public 		float 							ActiveScaleTransition 		= 0.1f;						

	//Rotation Animation
	public		bool							ActiveRotateAnimation;
	public 		Vector3 						ActiveRotation				= new Vector3(1,1,1);		
	public 		float 							ActiveRotationTransition 	= 0.1f;						

	//Color Animation
	public		bool							ActiveColorAnimation;
	public 		Color 							ActiveColor					= new Color(1,1,1,255);		
	public 		float 							ActiveColorTransition		= 0.1f;						

	//Blur Animation
	public		bool 							ActiveBlurAnimation;									
	public		Material						ActiveBlurMaterial;										//(Pro Only)								
	public		float							ActiveBlurDistance			= 0.02f;					//(Pro Only)					
	public		float							ActiveBlurTransition		= 0.01f;					//(Pro Only)					

	//Order
	public		int								ActiveSiblingIndex;										//(Pro Only)								
	//################################################################End Active Slides Animation Settings

	//################################################################Begin Next Slides Animation Settings
	//Position Animation
	public		bool							NextPositionAnimation;
	public 		float 							NextOffset;											
	public 		float 							NextOffsetTransition 		= 0.1f;					

	//Scale Animation
	public		bool							NextScaleAnimation;
	public 		Vector2 						NextScale 					= new Vector2(1,1);		
	public 		float 							NextScaleTransition 		= 0.1f;					

	//Rotation Animation
	public		bool							NextRotateAnimation;
	public 		Vector3 						NextRotation				= new Vector3(1,1,1);	
	public 		float 							NextRotationTransition 		= 0.1f;					

	//Color Animation
	public		bool							NextColorAnimation;
	public 		Color 							NextColor					= new Color(1,1,1,255);	
	public 		float 							NextColorTransition			= 0.1f;					

	//Blur Animation
	public		bool 							NextBlurAnimation;									
	public		Material						NextBlurMaterial;										//(Pro Only)								
	public		float							NextBlurDistance			= 0.02f;					//(Pro Only)				
	public		float							NextBlurTransition			= 0.01f;					//(Pro Only)				

	//Order
	public		int								NextSiblingIndex;										//(Pro Only)								
	//##################################################################End Next Slides Animation Settings
	//==========================================End Animation=============================================


	//=====================================Begin Other Properties=========================================
	//Scroll Step
	private 	float 							n;														//Use For Calculate Scroll Step
	private 	float 							ScrollStep;												//Scroll Step Of Horizontal And Vertical Slider					
	private 	float 							k							= 0;
	private 	bool 							ButtonClicked				= false;
	//=======================================End Other Properties=========================================


	void Update () {
		//==================================Begin Calculate Scroll Step Value=================================
		n = Slides.Count-1;
		ScrollStep = 1/n;
		//===================================End Calculate Scroll Step Value==================================

		//====================================Begin Horizontal Slider Menu====================================
		if (ScrollType == scrolltype.Horizontal) { 

			//####################################Begin Change Resolution Settings For Slides In View Property
			SliderMenuCanvas.GetComponent<CanvasScaler> ().matchWidthOrHeight 	= 0;

			SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution 	= new Vector2 (
				(SlideSize.x + SlideMargin.y + SlideMargin.w) * SlidesInView,
				SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution.y
			);
			//######################################End Change Resolution Settings For Slides In View Property

			//########################################################################Begin Change Scroll Type
			//Horizontal Scroll Enable And Vertical Scroll Disable

			//Automatically Define Horizontal Scrollbar By "HorizontalScrollbar" Value.
			ScrollObject.GetComponent<ScrollRect> ().horizontalScrollbar 	= HorizontalScrollbar;


			if (ShowHorizontalScrollbar == true) {
				ScrollObject.GetComponent<ScrollRect> ().horizontal = true;
				HorizontalScrollbar.gameObject.SetActive (true);
			} else {
				HorizontalScrollbar.gameObject.SetActive (false);
			}
			ScrollObject.GetComponent<ScrollRect> ().vertical 				= false;
			VerticalScrollbar.gameObject.SetActive (false);
			//##########################################################################End Change Scroll Type

			//########################################################################Begin Change Slides Size
			SlidesContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (
				(Slides.Count + SlidesInView - 1) * (SlideSize.x + SlideMargin.y + SlideMargin.w),
				(SlideSize.y + SlideMargin.x + SlideMargin.z)
			);
			//##########################################################################End Change Slides Size

			//#####################################Begin Work On Previous Slides, Active Slide, And Next Slids
			for(int i=0;i<Slides.Count;i++){			//For Set All Slides
				Slides [i].GetComponent<RectTransform> ().sizeDelta = SlideSize;
				for(int j=0;j<Slides.Count;j++){		//For Conditions. Such As Previous Slides, Active Silde, Next Slides, And Others. For Other Conditions You Can Compare i and j.
					if (HorizontalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (i - 1) * ScrollStep && HorizontalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + i * ScrollStep, 0, 1)) {
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Active Slide
						if (j == i) {
							//------------------------------------------------------------------------Begin Position Animation
							if (ActivePositionAnimation) {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
									//X
									((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
									//Y
									Mathf.Lerp (
									Slides [j].GetComponent<RectTransform> ().localPosition.y,																				//Current Position.y
									SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + ActiveOffset, 														//Target Position.y
									ActiveOffsetTransition																													//Transition Position.y
									),
									//Z
									10
								);
							} else {					
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
									//X
									((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
									//Y
									SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + ActiveOffset,
									//Z
									10
								);
							}
							//--------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (ActiveScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, ActiveScale, ActiveScaleTransition);
							} else {
								Slides [j].transform.localScale = ActiveScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//------------------------------------------------------------------------Begin Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform> ().localEulerAngles;
							if (ActiveRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, ActiveRotation, ActiveRotationTransition); 
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = new Vector3 (ActiveRotation.x,ActiveRotation.y,ActiveRotation.z); 
							}
							//--------------------------------------------------------------------------End Rotation Animation

							//---------------------------------------------------------------------------Begin Color Animation
							if (ActiveColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, ActiveColor, ActiveColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	ActiveColor, ActiveColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = ActiveColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = ActiveColor;
								}
							}
							//-----------------------------------------------------------------------------End Color Animation


							//---------------------------------------------------------------Begin Set Sibilin Of Active Slide
							Slides [j].gameObject.transform.SetAsLastSibling();
							//-----------------------------------------------------------------End Set Sibilin Of Active Slide

							//------------------------------------------------Begin Enable Or Disable Previous And Next Button
							//If The First Slide Is Active, Previous Button Must Be Disable.
							//If The Last Slide Is Active, Next Button Must Be Disable.
							if (j == 0) {										//If The First Slide Is Active
								PreviousButtonActive 	= false;
							} else {
								PreviousButtonActive 	= true;
							}

							if (j == Slides.Count - 1) {						//If The Last Slide Is Active
								NextButtonActive 		= false;
							} else {
								NextButtonActive 		= true;
							}
							//--------------------------------------------------End Enable Or Disable Previous And Next Button
						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Active Slide


						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Slides
						else if(j < i){
							//---------------------------------------------------------------Begin Previous Position Animation
							if (PreviousPositionAnimation) {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
									((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
									Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
										SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousOffset, 
										PreviousOffsetTransition
									),
									10
								);
							} else {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
									//X
									((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
									//Y
									SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousOffset, 
									//Z
									10
								);
							}
							//-----------------------------------------------------------------End Previous Position Animation



							//------------------------------------------------------------------Begin Previous Scale Animation
							if (PreviousScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, PreviousScale, PreviousScaleTransition);
							} else {
								Slides [j].transform.localScale = PreviousScale;
							}
							//--------------------------------------------------------------------End Previous Scale Animation

							//------------------------------------------------------------------------Begin Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform>().localEulerAngles;
							if (PreviousRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, PreviousRotation, PreviousRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = PreviousRotation;
							}
							//--------------------------------------------------------------------------End Rotation Animation

							//------------------------------------------------------------------Begin Previous Color Animation
							if (PreviousColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, PreviousColor, PreviousColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	PreviousColor, PreviousColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = PreviousColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = PreviousColor;
								}
							}
							//--------------------------------------------------------------------End Previous Color Animation



						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Slides

						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Slides
						else if(j > i){
							//-------------------------------------------------------------------Begin Next Position Animation
							if (NextPositionAnimation) {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
									//X
									((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
									//Y
									SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextOffset,
									//Z
									10
								);
							} else {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
									//X
									((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
									//Y
									SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextOffset,
									//Z
									10
								);
							}
							//---------------------------------------------------------------------End Next Position Animation

							//----------------------------------------------------------------------Begin Next Scale Animation
							if (NextScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, NextScale, NextScaleTransition);
							} else {
								Slides [j].transform.localScale = NextScale;
							}
							//------------------------------------------------------------------------End Next Scale Animation

							//-------------------------------------------------------------------Begin Next Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform>().localEulerAngles;
							if (NextRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, NextRotation, NextRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = NextRotation;
							}
							//---------------------------------------------------------------------End Next Rotation Animation

							//----------------------------------------------------------------------Begin Next Color Animation
							if (NextColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, NextColor, NextColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	NextColor, NextColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = NextColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = NextColor;
								}
							}
							//------------------------------------------------------------------------End Next Color Animation

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Slides
					}
				}
			}
			//#######################################End Work On Previous Slides, Active Slide, And Next Slids


			//#############################################################################Begin Slider Magnet
			if (SliderMagnet) {
				if (!Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {				//If Not Drag (In Desktop And Mobile Platform)
					for (int s = 0; s < Slides.Count; s++) {
						if (HorizontalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (s - 1) * ScrollStep && HorizontalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + s * ScrollStep, 0, 1)) {
							HorizontalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
								HorizontalScrollbar.GetComponent<Scrollbar> ().value,							//Current Value
								s * ScrollStep,																	//Target Value
								MagnetTransition																//Transition For Magnet
							);
						}
					}
				}
			}
			//###############################################################################End Slider Magnet

			//##################################################################Begin Previous And Next Button
			if (ScrollWithButtons == true) {
				ScrollButtons.SetActive (true);								//Show Previous And Next Button Object

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Find Button Objects
				PreviousButtonObject 										= GameObject.Find (ScrollButtons.name + "/Previous");		//Find Previous Button Object
				NextButtonObject 											= GameObject.Find (ScrollButtons.name + "/Next");			//Find Next Button Object
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Find Button Objects

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Define Button's Image
				PreviousButtonObject.GetComponent<Image> ().sprite 			= PreviousButtonImage;										//Define Previous Button's Image
				NextButtonObject.GetComponent<Image> ().sprite 				= NextButtonImage;											//Define Next Button's Image
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Define Button's Image

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Enable Or Diable Buttons
				//More: You Can Go To Active Slide Setting (When j==i) And See PreviousButtonActive And NextButtonActive Parameter
				PreviousButtonObject.GetComponent<Button> ().interactable 	= PreviousButtonActive;										//Enable Previous Button
				NextButtonObject.GetComponent<Button> ().interactable 		= NextButtonActive;											//Enable Next Button

				if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
					ButtonClicked = false;
				}
				if (ButtonClicked == true) {
					HorizontalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
						HorizontalScrollbar.GetComponent<Scrollbar> ().value, 
						k,
						ButtonTransition
					);
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Enable Or Diable Buttons

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Button Position
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.w,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							), 
							//Y
							0
						);
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Button Position

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Button Position
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								NextButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							0
						);
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Button Position
			} else {
				ScrollButtons.SetActive (false);			//Hide Previous And Next Button Object
			}
			//####################################################################End Previous And Next Button
		}
		//=====================================End Horizontal Slider Menu=====================================




		//=====================================Begin Vertical Slider Menu=====================================
		else if(ScrollType==scrolltype.Vertical){
			//####################################Begin Change Resolution Settings For Slides In View Property
			SliderMenuCanvas.GetComponent<CanvasScaler> ().matchWidthOrHeight 	= 1;
			SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution 	= new Vector2 (
				SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution.x,
				(SlideSize.y+SlideMargin.x+SlideMargin.z)*SlidesInView
			);
			//######################################End Change Resolution Settings For Slides In View Property

			//########################################################################Begin Change Scroll Type
			//Vertical Scroll Enable And Horizontal Scroll Disable

			//Automatically Define Vertical Scrollbar By "VerticalScrollbar" Value.
			ScrollObject.GetComponent<ScrollRect> ().verticalScrollbar = VerticalScrollbar;

			if (ShowVerticalScrollbar == true) {
				ScrollObject.GetComponent<ScrollRect> ().vertical = true;
				VerticalScrollbar.gameObject.SetActive (true);
			} else {
				VerticalScrollbar.gameObject.SetActive (false);
			}
			ScrollObject.GetComponent<ScrollRect> ().horizontal = false;
			HorizontalScrollbar.gameObject.SetActive (false);

			//##########################################################################End Change Scroll Type

			//########################################################################Begin Change Slides Size
			if (DefaultOffset) {
				SlidesContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (SlideSize.x+SlideMargin.y+SlideMargin.w,(Slides.Count+SlidesInView-1)*(SlideSize.y+SlideMargin.x+SlideMargin.z));
			} else {
				SlidesContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (SlideSize.x+SlideMargin.y+SlideMargin.w,(Slides.Count+SlidesInView-1)*(SlideSize.y+SlideMargin.x+SlideMargin.z));
			}
			//##########################################################################End Change Slides Size

			//#####################################Begin Work On Previous Slides, Active Slide, And Next Slids
			for(int i=0;i<Slides.Count;i++){
				Slides [i].GetComponent<RectTransform> ().sizeDelta = SlideSize;
				for(int j=0;j<Slides.Count;j++){
					if (VerticalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (i - 1) * ScrollStep && VerticalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + i * ScrollStep, 0, 1)) {
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Active Slide
						if (j == i) {
							//------------------------------------------------------------------------Begin Position Animation
							if (ActivePositionAnimation) {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + ActiveOffset, ActiveOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
							} else {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + ActiveOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
							}
							//--------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (ActiveScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, ActiveScale, ActiveScaleTransition);
							} else {
								Slides [j].transform.localScale = ActiveScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//------------------------------------------------------------------------Begin Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform>().localEulerAngles;
							if (ActiveRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, ActiveRotation, ActiveRotationTransition); 
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = ActiveRotation; 
							}
							//--------------------------------------------------------------------------End Rotation Animation

							//---------------------------------------------------------------------------Begin Color Animation
							if (ActiveColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, ActiveColor, ActiveColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	ActiveColor, ActiveColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = ActiveColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = ActiveColor;
								}
							}
							//-----------------------------------------------------------------------------End Color Animation

							//------------------------------------------------------------Begin Sibilin Index Of Active Slides
							Slides [j].gameObject.transform.SetAsLastSibling();
							//--------------------------------------------------------------End Sibilin Index Of Active Slides

							if (j == 0) {
								PreviousButtonActive 	= false;
							} else {
								PreviousButtonActive 	= true;
							}
							if (j == Slides.Count - 1) {
								NextButtonActive 		= false;
							} else {
								NextButtonActive 		= true;
							}

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Active Slide

						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Slides
						else if(j<i){
							//------------------------------------------------------------------------Begin Position Animation
							if (PreviousPositionAnimation) {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousOffset, PreviousOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
							} else {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
							}
							//--------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (PreviousScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, PreviousScale, PreviousScaleTransition);
							} else {
								Slides [j].transform.localScale = PreviousScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//---------------------------------------------------------------------------Begin Rotation Animation
							if (PreviousRotateAnimation) {
								Vector3 RotationVector=Slides[j].GetComponent<RectTransform>().localEulerAngles;
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, PreviousRotation, PreviousRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = PreviousRotation;
							}
							//-----------------------------------------------------------------------------End Rotation Animation

							//------------------------------------------------------------------------------Begin Color Animation
							if (PreviousColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, PreviousColor, PreviousColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	PreviousColor, PreviousColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = PreviousColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = PreviousColor;
								}
							}
							//--------------------------------------------------------------------------------End Color Animation

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Slides

						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Slides
						else if(j>i){
							//---------------------------------------------------------------------------Begin Position Animation
							if (NextPositionAnimation) {
								Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextOffset, NextOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
							} else {
								Slides [j].GetComponent<RectTransform>().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2+NextOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
							}
							//-----------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (NextScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, NextScale, NextScaleTransition);
							} else {
								Slides [j].transform.localScale = NextScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//---------------------------------------------------------------------------Begin Rotation Animation
							if (NextRotateAnimation) {
								Vector3 RotationVector=Slides[j].GetComponent<RectTransform>().localEulerAngles;
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, NextRotation, NextRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = NextRotation;
							}
							//-----------------------------------------------------------------------------End Rotation Animation

							//------------------------------------------------------------------------------Begin Color Animation
							if (NextColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, NextColor, NextColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	NextColor, NextColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = NextColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = NextColor;
								}
							}
							//--------------------------------------------------------------------------------End Color Animation

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Slides
					}
				}
			}
			//#######################################End Work On Previous Slides, Active Slide, And Next Slids


			//#############################################################################Begin Slider Magnet
			if (SliderMagnet) {
				if (!Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
					for (int s = 0; s < Slides.Count; s++) {
						if (VerticalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (s - 1) * ScrollStep && VerticalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + s * ScrollStep, 0, 1)) {
							VerticalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
								VerticalScrollbar.GetComponent<Scrollbar> ().value, 
								s * ScrollStep,
								MagnetTransition
							);
						}
					}
				}
			}
			//###############################################################################End Slider Magnet



			//##################################################################Begin Previous And Next Button
			if (ScrollWithButtons == true) {
				ScrollButtons.SetActive (true);

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Find Button Objects
				PreviousButtonObject = GameObject.Find (ScrollButtons.name + "/Previous");
				NextButtonObject = GameObject.Find (ScrollButtons.name + "/Next");
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Find Button Objects

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Define Button's Image
				PreviousButtonObject.GetComponent<Image> ().sprite = PreviousButtonImage;
				NextButtonObject.GetComponent<Image> ().sprite = NextButtonImage;
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Define Button's Image

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Enable Or Diable Buttons
				//More: You Can Go To Active Slide Setting (When j==i) And See PreviousButtonActive And NextButtonActive Parameter
				PreviousButtonObject.GetComponent<Button> ().interactable = PreviousButtonActive;
				NextButtonObject.GetComponent<Button> ().interactable = NextButtonActive;

				if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
					ButtonClicked = false;
				}
				if (ButtonClicked == true) {
					VerticalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp(
						VerticalScrollbar.GetComponent<Scrollbar> ().value, 
						k, 
						ButtonTransition
					);
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Enable Or Diable Buttons

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Button Position
				PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (PreviousButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Button Position


				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Button Position
				NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (NextButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));	
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Button Position

			} else {
				ScrollButtons.SetActive (false);
			}
			//####################################################################End Previous And Next Button
		}
		//======================================End Vertical Slider Menu======================================

	}


	//....................................Begin Next Button's Function....................................
	public void NextButton(){
		if(ScrollType==scrolltype.Horizontal){
			k = HorizontalScrollbar.GetComponent<Scrollbar> ().value;
		}
		else if(ScrollType==scrolltype.Vertical){
			k = VerticalScrollbar.GetComponent<Scrollbar> ().value;
		}
		k = Mathf.Clamp (k+ScrollStep,0,1);
		ButtonClicked = true;
	}
	//.....................................End Next Button's Function.....................................

	//..................................Begin Previous Button's Function..................................
	public void PreviousButton(){
		if(ScrollType==scrolltype.Horizontal){
			k = HorizontalScrollbar.GetComponent<Scrollbar> ().value;
		}
		else if(ScrollType==scrolltype.Vertical){
			k = VerticalScrollbar.GetComponent<Scrollbar> ().value;
		}
		k = Mathf.Clamp (k-ScrollStep,0,1);
		ButtonClicked = true;
	}
	//...................................End Previous Button's Function...................................

}
