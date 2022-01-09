using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SliderMenu))]
[System.Serializable]
public class SliderMenu_Inspector : Editor {
	public string ProjectName = "Slider Menu Free_New Edition";
	public GUISkin SliderMenuSkin;
	//================================================Icons===============================================
	public GUIContent SliderMenuthumbnail;
	//>>>>>>>>>>>>>>>>>>>>Collapse Icons Variables
	public GUIContent CollapseOn;
	public GUIContent CollapseOff;

	//####################Begin Slides Align Icons Variables
	public GUIContent SlidesAlignToTop;
	public GUIContent SlidesAlignToMiddle;
	public GUIContent SlidesAlignToBottom;
	public GUIContent SlidesAlignToLeft;
	public GUIContent SlidesAlignToCenter;
	public GUIContent SlidesAlignToRight;
	//######################End Slides Align Icons Variables

	//############BeginPrevious Button Align Icons Variables
	public GUIContent PreviousButtonAlignToLeftBottom;
	public GUIContent PreviousButtonAlignToLeftMiddle;
	public GUIContent PreviousButtonAlignToLeftTop;
	public GUIContent PreviousButtonAlignToCenterBottom;
	public GUIContent PreviousButtonAlignToCenterMiddle;
	public GUIContent PreviousButtonAlignToCenterTop;
	public GUIContent PreviousButtonAlignToRightBottom;
	public GUIContent PreviousButtonAlignToRightMiddle;
	public GUIContent PreviousButtonAlignToRightTop;
	//######################End Button Align Icons Variables

	//###############Begin Next Button Align Icons Variables
	public GUIContent NextButtonAlignToLeftBottom;
	public GUIContent NextButtonAlignToLeftMiddle;
	public GUIContent NextButtonAlignToLeftTop;
	public GUIContent NextButtonAlignToCenterBottom;
	public GUIContent NextButtonAlignToCenterMiddle;
	public GUIContent NextButtonAlignToCenterTop;
	public GUIContent NextButtonAlignToRightBottom;
	public GUIContent NextButtonAlignToRightMiddle;
	public GUIContent NextButtonAlignToRightTop;
	//#################End Next Button Align Icons Variables
	//====================================================================================================

	void OnEnable () {
		//================================================Icons===============================================
		SliderMenuthumbnail	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Header.png",typeof(Texture2D)),"");
		//######################Begin Collapse Icons
		CollapseOn			= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Collapse On.psd",typeof(Texture2D)),"");
		CollapseOff			= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Collapse Off.psd",typeof(Texture2D)),"");
		//########################End Collapse Icons

		//##################Begin Slides Align Icons
		SlidesAlignToTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Slides Align To Top.psd",typeof(Texture2D)),"");
		SlidesAlignToMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Slides Align To Middle.psd",typeof(Texture2D)),"");
		SlidesAlignToBottom	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Slides Align To Bottom.psd",typeof(Texture2D)),"");
		SlidesAlignToLeft	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Slides Align To Left.psd",typeof(Texture2D)),"");
		SlidesAlignToCenter	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Slides Align To Center.psd",typeof(Texture2D)),"");
		SlidesAlignToRight	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Slides Align To Right.psd",typeof(Texture2D)),"");
		//####################End Slides Align Icons

		//##################Begin Buttons Align Icons
		PreviousButtonAlignToLeftBottom = new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Left Bottom.png",typeof(Texture2D)),"");
		PreviousButtonAlignToLeftMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Left Middle.png",typeof(Texture2D)),"");
		PreviousButtonAlignToLeftTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Left Top.png",typeof(Texture2D)),"");
		PreviousButtonAlignToCenterBottom = new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Center Bottom.png",typeof(Texture2D)),"");
		PreviousButtonAlignToCenterMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Center Middle.png",typeof(Texture2D)),"");
		PreviousButtonAlignToCenterTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Center Top.png",typeof(Texture2D)),"");
		PreviousButtonAlignToRightBottom = new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Right Bottom.png",typeof(Texture2D)),"");
		PreviousButtonAlignToRightMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Right Middle.png",typeof(Texture2D)),"");
		PreviousButtonAlignToRightTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Previous Button Align To Right Top.png",typeof(Texture2D)),"");

		NextButtonAlignToLeftBottom = new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Left Bottom.png",typeof(Texture2D)),"");
		NextButtonAlignToLeftMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Left Middle.png",typeof(Texture2D)),"");
		NextButtonAlignToLeftTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Left Top.png",typeof(Texture2D)),"");
		NextButtonAlignToCenterBottom = new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Center Bottom.png",typeof(Texture2D)),"");
		NextButtonAlignToCenterMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Center Middle.png",typeof(Texture2D)),"");
		NextButtonAlignToCenterTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Center Top.png",typeof(Texture2D)),"");
		NextButtonAlignToRightBottom = new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Right Bottom.png",typeof(Texture2D)),"");
		NextButtonAlignToRightMiddle	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Right Middle.png",typeof(Texture2D)),"");
		NextButtonAlignToRightTop	= new GUIContent(" ",(Texture2D)AssetDatabase.LoadAssetAtPath("Assets/"+ProjectName+"/Editor/Icons/Next Button Align To Right Top.png",typeof(Texture2D)),"");
		//####################End Buttons Align Icons
		//====================================================================================================
	}

	public override void OnInspectorGUI () {
		serializedObject.Update ();							
		SliderMenu SliderMenuScript = (SliderMenu)target;	//Define And Find SliderMenu Script
		GUI.skin.label.alignment = TextAnchor.UpperCenter;	//Edit Alignment Of Lables
		GUILayout.Label (SliderMenuthumbnail, GUILayout.Width (EditorGUIUtility.currentViewWidth-35));

		GUI.skin.label.alignment = TextAnchor.MiddleCenter;	//Edit Alignment Of Lables
		EditorStyles.textField.fontStyle = FontStyle.Bold;	//Edit Font Style Of TextField Editor Style.

		//=======================================Begin Main Objects===========================================
		//######################################################################Begin Main Objects Block Title
		GUI.backgroundColor = new Vector4 (0,0,0,0.3f);
		if (SliderMenuScript.MainObjectBlock) {
			GUI.backgroundColor = new Vector4 (0, 150, 255, 1);
		} 
		EditorGUILayout.BeginVertical(EditorStyles.helpBox);
		/*-----*/SliderMenuScript.MainObjectBlock = GUILayout.Toggle(SliderMenuScript.MainObjectBlock, "Main Objects Settings", EditorStyles.textField, GUILayout.ExpandWidth(true));
		/*-----*/GUI.backgroundColor = Color.white;
		//########################################################################End Main Objects Block Title



		if (SliderMenuScript.MainObjectBlock) {
			//######################################################################Begin Collapse Off Other Block
			SliderMenuScript.ScrollSettingsBlock	= false;
			SliderMenuScript.SlidesPropertyBlock	= false;
			SliderMenuScript.AnimationBlock 		= false;
			//########################################################################End Collapse Off Other Block


			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			//#####################################################################Begin Slider Menu Canvas Object
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("SliderMenuCanvas"),new GUIContent("Canvas"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//#######################################################################End Slider Menu Canvas Object


			//#################################################################################Begin Scroll Object
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("ScrollObject"),new GUIContent("Scroll Object"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//###################################################################################End Scroll Object


			//#########################################################################Begin Slides Content Object
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("SlidesContent"),new GUIContent("Slides Content"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//###########################################################################End Slides Content Object


			//#################################################################################Begin Slides Object
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("Slides"),new GUIContent("Slides"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//###################################################################################End Slides Object

			EditorGUILayout.EndVertical();
		}
		EditorGUILayout.EndVertical();
		//========================================End Main Objects============================================


		//=====================================Begin Scroll Settings==========================================
		//###################################################################Begin Scroll Settings Block Title
		GUI.backgroundColor = new Vector4 (0,0,0,0.3f);
		if (SliderMenuScript.ScrollSettingsBlock) {
			GUI.backgroundColor = new Vector4 (0, 150, 255, 1);
		} 
		EditorGUILayout.BeginVertical(EditorStyles.helpBox);

		/*-----*/SliderMenuScript.ScrollSettingsBlock = GUILayout.Toggle(SliderMenuScript.ScrollSettingsBlock, "Scroll Settings", EditorStyles.textField, GUILayout.ExpandWidth(true));
		/*-----*/GUI.backgroundColor = Color.white;
		//#####################################################################End Scroll Settings Block Title

		if (SliderMenuScript.ScrollSettingsBlock) {
			//######################################################################Begin Collapse Off Other Block
			SliderMenuScript.MainObjectBlock		= false;
			SliderMenuScript.SlidesPropertyBlock	= false;
			SliderMenuScript.AnimationBlock 		= false;
			//########################################################################End Collapse Off Other Block

			//###################################################################################Begin Scroll Type
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ScrollType"), new GUIContent ("Scroll Type"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.ScrollType == scrolltype.Horizontal) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ShowHorizontalScrollbar"), new GUIContent ("Show Scrollbar"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				if(SliderMenuScript.ShowHorizontalScrollbar){
					/*-----*/EditorGUILayout.BeginHorizontal ();
					/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
					/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("HorizontalScrollbar"), new GUIContent ("Horizontal Scrollbar"), true);
					/*-----*/EditorGUILayout.EndHorizontal ();
				}

			}

			if (SliderMenuScript.ScrollType == scrolltype.Vertical) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ShowVerticalScrollbar"), new GUIContent ("Show Scrollbar"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				if (SliderMenuScript.ShowVerticalScrollbar) {
					/*-----*/EditorGUILayout.BeginHorizontal ();
					/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
					/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("VerticalScrollbar"), new GUIContent ("Vertical Scrollbar"), true);
					/*-----*/EditorGUILayout.EndHorizontal ();
				}

			}
			EditorGUILayout.EndVertical ();


			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Slides Align Thumbnail

			if (SliderMenuScript.ScrollType == scrolltype.Horizontal) {
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				GUI.color = Color.green;
				if(GUILayout.Button("Pro Version"))
				{
					Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
				}
				GUI.color = Color.white;

				GUI.enabled=false;
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("SlidesVerticalAlign"), new GUIContent ("Slides Align"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				if (SliderMenuScript.SlidesVerticalAlign == slidesverticalalign.Top) {
					GUILayout.Label (SlidesAlignToTop);
				} else if (SliderMenuScript.SlidesVerticalAlign == slidesverticalalign.Middle) {
					GUILayout.Label (SlidesAlignToMiddle);
				} else if (SliderMenuScript.SlidesVerticalAlign == slidesverticalalign.Bottom) {
					GUILayout.Label (SlidesAlignToBottom);
				}

				EditorGUILayout.EndVertical ();
			} else if (SliderMenuScript.ScrollType == scrolltype.Vertical) {
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				GUI.color = Color.green;
				if(GUILayout.Button("Pro Version"))
				{
					Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
				}
				GUI.color = Color.white;

				GUI.enabled=false;
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("SlidesHorizontalAlign"), new GUIContent ("Slides Align"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				if (SliderMenuScript.SlidesHorizontalAlign == slideshorizontalalign.Left) {
					GUILayout.Label (SlidesAlignToLeft);
				} else if (SliderMenuScript.SlidesHorizontalAlign == slideshorizontalalign.Center) {
					GUILayout.Label (SlidesAlignToCenter);
				} else if (SliderMenuScript.SlidesHorizontalAlign == slideshorizontalalign.Right) {
					GUILayout.Label (SlidesAlignToRight);
				}

				EditorGUILayout.EndVertical ();
			}
			GUI.enabled=true;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Slides Align Thumbnail
			//#####################################################################################End Scroll Type


			EditorGUILayout.Space ();


			//#############################################################################Begin Scroll With Arrow
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			/*-----*/SliderMenuScript.ScrollWithArrow = GUILayout.Toggle (SliderMenuScript.ScrollWithArrow, " Scroll With Arrow", EditorStyles.toggle, GUILayout.ExpandWidth (true));
			GUI.enabled = true;
			/*-----*/GUI.backgroundColor = Color.white;
			if (SliderMenuScript.ScrollWithArrow) {

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin And Right Keys
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				/*-----*/EditorGUILayout.BeginHorizontal ();
				if (SliderMenuScript.LeftAndRight) {
					GUILayout.Label (CollapseOn, GUILayout.Width (20));
				} else {
					GUILayout.Label (CollapseOff, GUILayout.Width (20));
				}
				/*----------*/SliderMenuScript.LeftAndRight = GUILayout.Toggle (SliderMenuScript.LeftAndRight, " Left And Right Keys", EditorStyles.toggle, GUILayout.ExpandWidth (true));
				/*-----*/EditorGUILayout.EndHorizontal ();

				if (SliderMenuScript.LeftAndRight) {
					
					/*-----*/EditorGUILayout.BeginHorizontal ();
					/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
					/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("HorizontalArrowStepByStep"), new GUIContent (" Step By Step"), true);
					/*-----*/EditorGUILayout.EndHorizontal ();

				}
				EditorGUILayout.EndVertical ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Up And Dow Keys
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				/*-----*/EditorGUILayout.BeginHorizontal ();
				if (SliderMenuScript.UpAndDown) {
					GUILayout.Label (CollapseOn, GUILayout.Width (20));
				} else {
					GUILayout.Label (CollapseOff, GUILayout.Width (20));
				}
				/*----------*/SliderMenuScript.UpAndDown = GUILayout.Toggle (SliderMenuScript.UpAndDown, " Up And Down Keys", EditorStyles.toggle, GUILayout.ExpandWidth (true));
				/*-----*/EditorGUILayout.EndHorizontal ();

				if (SliderMenuScript.UpAndDown) {
					/*-----*/EditorGUILayout.BeginHorizontal ();
					/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
					/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("VerticalArrowStepByStep"), new GUIContent ("Step By Step"), true);
					/*-----*/EditorGUILayout.EndHorizontal ();
				}

				EditorGUILayout.EndVertical ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Up And Dow Keys

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scroll Transition
				/*-----*/EditorGUILayout.BeginHorizontal (EditorStyles.helpBox);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ArrowTransition"), new GUIContent ("Scroll Transition"), true);
				if(SliderMenuScript.ArrowTransition == 0){
					SliderMenuScript.ArrowTransition = 0.001f;
				}
				/*-----*/EditorGUILayout.EndHorizontal ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scroll Transition

			}
			EditorGUILayout.EndVertical ();
			//###############################################################################End Scroll With Arrow


			EditorGUILayout.Space ();



			//###########################################################################Begin Scroll With Buttons
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			/*-----*/SliderMenuScript.ScrollWithButtons = GUILayout.Toggle (SliderMenuScript.ScrollWithButtons, " Scroll With Buttons", EditorStyles.toggle, GUILayout.ExpandWidth (true));
			/*-----*/GUI.backgroundColor = Color.white;
			if (SliderMenuScript.ScrollWithButtons) {

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scroll Buttons Object
				/*-----*/EditorGUILayout.BeginHorizontal (EditorStyles.helpBox);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ScrollButtons"), new GUIContent ("Scroll Buttons"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scroll Buttons Object

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Button
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				//------------------------------------------------------------------------Begin Previous Button Sprite
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousButtonImage"), new GUIContent ("Previous Button Sprite"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				//--------------------------------------------------------------------------End Previous Button Sprite



				//-------------------------------------------------------------------------Begin Previous Button Align
				GUI.color = Color.green;
				if(GUILayout.Button("Pro Version"))
				{
					Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
				}
				GUI.color = Color.white;
				GUI.enabled = false;
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousButtonHorizontalAlign"), new GUIContent ("Horizontal Align"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousButtonVerticalAlign"), new GUIContent ("Vertical Align"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				/*-----*/EditorGUILayout.BeginHorizontal ();
				if (SliderMenuScript.PreviousButtonHorizontalAlign 			== previousbuttonhorizontalalign.Left) {
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Bottom) {
						GUILayout.Label (PreviousButtonAlignToLeftBottom);
					}
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Middle) {
						GUILayout.Label (PreviousButtonAlignToLeftMiddle);
					}
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Top) {
						GUILayout.Label (PreviousButtonAlignToLeftTop);
					}
				} else if (SliderMenuScript.PreviousButtonHorizontalAlign 	== previousbuttonhorizontalalign.Center) {
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Bottom) {
						GUILayout.Label (PreviousButtonAlignToCenterBottom);
					}
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Middle) {
						GUILayout.Label (PreviousButtonAlignToCenterMiddle);
					}
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Top) {
						GUILayout.Label (PreviousButtonAlignToCenterTop);
					}
				} else if (SliderMenuScript.PreviousButtonHorizontalAlign 	== previousbuttonhorizontalalign.Right) {
					if (SliderMenuScript.PreviousButtonVerticalAlign 		== previousbuttonverticalalign.Bottom) {
						GUILayout.Label (PreviousButtonAlignToRightBottom);
					}
					if (SliderMenuScript.PreviousButtonVerticalAlign		== previousbuttonverticalalign.Middle) {
						GUILayout.Label (PreviousButtonAlignToRightMiddle);
					}
					if (SliderMenuScript.PreviousButtonVerticalAlign		== previousbuttonverticalalign.Top) {
						GUILayout.Label (PreviousButtonAlignToRightTop);
					}
				}
				/*-----*/EditorGUILayout.EndHorizontal ();
				//---------------------------------------------------------------------------End Previous Button Align

				GUI.enabled = true;
				//------------------------------------------------------------------------Begin Previous Button Margin
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousButtonMargin"), new GUIContent (" Previous Button Margin"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label ("X= Top Margin, Y= Right Margin, Z= Bottom Margin, And W= Left Margin", EditorStyles.helpBox);
				/*-----*/EditorGUILayout.EndHorizontal ();
				//--------------------------------------------------------------------------End Previous Button Margin

				EditorGUILayout.EndVertical ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Button



				EditorGUILayout.Space ();


				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Button
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				//----------------------------------------------------------------------------Begin Next Button Sprite
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextButtonImage"), new GUIContent (" Next Button Sprite"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				//------------------------------------------------------------------------------End Next Button Sprite

				//-----------------------------------------------------------------------------Begin Next Button Align
				GUI.color = Color.green;
				if(GUILayout.Button("Pro Version"))
				{
					Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
				}
				GUI.color = Color.white;
				GUI.enabled = false;
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextButtonHorizontalAlign"), new GUIContent (" Horizontal Align"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextButtonVerticalAlign"), new GUIContent (" Vertical Align"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();

				/*-----*/EditorGUILayout.BeginHorizontal ();
				if (SliderMenuScript.NextButtonHorizontalAlign == nextbuttonhorizontalalign.Left) {
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
						GUILayout.Label (NextButtonAlignToLeftBottom);
					}
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
						GUILayout.Label (NextButtonAlignToLeftMiddle);
					}
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
						GUILayout.Label (NextButtonAlignToLeftTop);
					}
				} else if (SliderMenuScript.NextButtonHorizontalAlign == nextbuttonhorizontalalign.Center) {
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
						GUILayout.Label (NextButtonAlignToCenterBottom);
					}
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
						GUILayout.Label (NextButtonAlignToCenterMiddle);
					}
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
						GUILayout.Label (NextButtonAlignToCenterTop);
					}
				} else if (SliderMenuScript.NextButtonHorizontalAlign == nextbuttonhorizontalalign.Right) {
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
						GUILayout.Label (NextButtonAlignToRightBottom);
					}
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
						GUILayout.Label (NextButtonAlignToRightMiddle);
					}
					if (SliderMenuScript.NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
						GUILayout.Label (NextButtonAlignToRightTop);
					}
				}
				/*-----*/EditorGUILayout.EndHorizontal ();
				//-------------------------------------------------------------------------------End Next Button Align

				GUI.enabled = true;
				//----------------------------------------------------------------------------Begin Next Button Margin
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextButtonMargin"), new GUIContent (" Next Button Margin"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();


				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label ("X= Top Margin, Y= Right Margin, Z= Bottom Margin, And W= Left Margin", EditorStyles.helpBox);
				/*-----*/EditorGUILayout.EndHorizontal ();
				//------------------------------------------------------------------------------End Next Button Margin

				EditorGUILayout.EndVertical ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Button


				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Button Transition
				EditorGUILayout.BeginVertical (EditorStyles.helpBox);

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ButtonTransition"), new GUIContent (" Scroll Transition"), true);
				if(SliderMenuScript.ButtonTransition == 0){
					SliderMenuScript.ButtonTransition = 0.001f;
				}
				/*-----*/EditorGUILayout.EndHorizontal ();

				EditorGUILayout.EndVertical ();
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Button Transition
			}
			EditorGUILayout.EndVertical ();
			//#############################################################################End Scroll With Buttons


			EditorGUILayout.Space ();


			//#################################################################################Begin Magnet Effect
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			/*-----*/SliderMenuScript.SliderMagnet = GUILayout.Toggle (SliderMenuScript.SliderMagnet, " Magnet Effect", EditorStyles.toggle, GUILayout.ExpandWidth (true));
			/*-----*/GUI.backgroundColor = Color.white;
			if (SliderMenuScript.SliderMagnet) {
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("MagnetTransition"), new GUIContent (" Magnet Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
			}

			EditorGUILayout.EndVertical ();
			//###################################################################################End Magnet Effect
		}
		EditorGUILayout.EndVertical ();
		//======================================End Scroll Settings===========================================


		//=====================================Begin Slides Property==========================================

		//#########################################################################Begin Slides Property Title
		EditorStyles.helpBox.alignment = TextAnchor.MiddleLeft;
		GUI.backgroundColor = new Vector4 (0,0,0,0.3f);
		if (SliderMenuScript.SlidesPropertyBlock) {
			GUI.backgroundColor = new Vector4 (0, 150, 255, 1);
		} 
		EditorGUILayout.BeginVertical(EditorStyles.helpBox);

		/*-----*/SliderMenuScript.SlidesPropertyBlock = GUILayout.Toggle(SliderMenuScript.SlidesPropertyBlock, "Slides Property", EditorStyles.textField, GUILayout.ExpandWidth(true));
		/*-----*/GUI.backgroundColor = Color.white;
		//###########################################################################End Slides Property Title


		if (SliderMenuScript.SlidesPropertyBlock) {
			//######################################################################Begin Collapse Off Other Block
			SliderMenuScript.MainObjectBlock 		= false;
			SliderMenuScript.ScrollSettingsBlock 	= false;
			SliderMenuScript.AnimationBlock 		= false;
			//########################################################################End Collapse Off Other Block

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);

			/*-----*/EditorStyles.helpBox.alignment = TextAnchor.MiddleCenter;
			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("General Property", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;


			//################################################################################Begin Slides In View
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("SlidesInView"),new GUIContent("Slides In View"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//##################################################################################End Slides In View

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//###########################################################################Begin Active Slide Offset
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if(SliderMenuScript.DefaultOffset){
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			} else{
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("DefaultOffset"),new GUIContent("Default Offset"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if(SliderMenuScript.DefaultOffset){
				GUI.enabled = false;
			} else{
				GUI.enabled = true;
			}

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("ActiveSlideOffset"),new GUIContent("Active Slide Offset"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			/*-----*/GUI.enabled = true;
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label ("Default Value Is Center Slides. For Exmaple: If 'Slides In View' Is 5, The Value Of Offset Will Be 3.", EditorStyles.helpBox);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//#############################################################################End Active Slide Offset
			GUI.enabled = true;
			EditorGUILayout.EndVertical();


			//###################################################################################Begin Slides Size
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("SlideSize"),new GUIContent("Size"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label ("X= Width, And Y= Height", EditorStyles.helpBox);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//#####################################################################################End Slides Size

			//#################################################################################Begin Slides Margin
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField(serializedObject.FindProperty ("SlideMargin"),new GUIContent("Margin"),true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label ("X= Top Margin, Y= Right Margin, Z= Bottom Margin, And W= Left Margin", EditorStyles.helpBox);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//###################################################################################End Slides Margin

			EditorGUILayout.EndVertical();


			EditorGUILayout.Space ();


			EditorGUILayout.BeginVertical(EditorStyles.helpBox);

			/*-----*/EditorStyles.helpBox.alignment = TextAnchor.MiddleCenter;
			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("Previous Slides", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Offset Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			if (SliderMenuScript.ScrollType == scrolltype.Horizontal) {
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousOffset"), new GUIContent ("Y Offset"), true);
			} else {
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousOffset"), new GUIContent ("X Offset"), true);
			}
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Offset Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scale Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousScale"), new GUIContent ("Scale"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scale Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Rotation Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousRotation"), new GUIContent ("Rotation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Rotation Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Color Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousColor"), new GUIContent ("Color"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Color Property

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Blur Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousBlurMaterial"), new GUIContent ("Blur Material"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousBlurDistance"), new GUIContent ("Blur Distance"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Blur Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Order Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousSiblingIndex"), new GUIContent ("Order"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Order Property
			GUI.enabled = true;
			EditorGUILayout.EndVertical();

			EditorGUILayout.EndVertical();
			//######################################################################End Previous Slides Properties



			EditorGUILayout.Space ();


			//######################################################################Begin Active Slides Properties
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);

			/*-----*/EditorStyles.helpBox.alignment = TextAnchor.MiddleCenter;
			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("Active Slide", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Offset Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			if (SliderMenuScript.ScrollType == scrolltype.Horizontal) {
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveOffset"), new GUIContent ("Y Offset"), true);
			} else {
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveOffset"), new GUIContent ("X Offset"), true);
			}
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Offset Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scale Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveScale"), new GUIContent ("Scale"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scale Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Rotation Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveRotation"), new GUIContent ("Rotation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Rotation Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Color Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveColor"), new GUIContent ("Color"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Color Property

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Blur Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveBlurMaterial"), new GUIContent ("Blur Material"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveBlurDistance"), new GUIContent ("Blur Distance"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Blur Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Order Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveSiblingIndex"), new GUIContent ("Order"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Order Property
			GUI.enabled = true;
			EditorGUILayout.EndVertical();

			EditorGUILayout.EndVertical();
			//########################################################################End Active Slides Properties



			EditorGUILayout.Space ();



			//########################################################################Begin Next Slides Properties
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);

			/*-----*/EditorStyles.helpBox.alignment = TextAnchor.MiddleCenter;
			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("Next Slides", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Offset Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			if (SliderMenuScript.ScrollType == scrolltype.Horizontal) {
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextOffset"), new GUIContent ("Y Offset"), true);
			} else {
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextOffset"), new GUIContent ("X Offset"), true);
			}
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Offset Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scale Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextScale"), new GUIContent ("Scale"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scale Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Rotation Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextRotation"), new GUIContent ("Rotation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Rotation Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Color Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextColor"), new GUIContent ("Color"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Color Property

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Blur Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextBlurMaterial"), new GUIContent ("Blur Material"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextBlurDistance"), new GUIContent ("Blur Distance"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Blur Property

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Order Property
			/*-----*/EditorGUILayout.BeginHorizontal ();
			/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextSiblingIndex"), new GUIContent ("Order"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Order Property
			GUI.enabled = true;
			EditorGUILayout.EndVertical();

			EditorGUILayout.EndVertical();
			//##########################################################################End Next Slides Properties
		}
		EditorGUILayout.EndVertical ();
		//======================================End Slides Property===========================================



		//========================================Begin Animations============================================
		//#########################################################################Begin Animation Block Title
		/*-----*/GUI.backgroundColor = new Vector4 (0,0,0,0.3f);
		if (SliderMenuScript.AnimationBlock) {
			GUI.backgroundColor = new Vector4 (0, 150, 255, 1);
		} 
		EditorGUILayout.BeginVertical(EditorStyles.helpBox);

		/*-----*/SliderMenuScript.AnimationBlock = GUILayout.Toggle(SliderMenuScript.AnimationBlock, "Animation Settings", EditorStyles.textField, GUILayout.ExpandWidth(true));
		/*-----*/GUI.backgroundColor = Color.white;
		//###########################################################################End Animation Block Title


		if (SliderMenuScript.AnimationBlock) {
			//######################################################################Begin Collapse Off Other Block
			SliderMenuScript.MainObjectBlock 		= false;
			SliderMenuScript.ScrollSettingsBlock	= false;
			SliderMenuScript.SlidesPropertyBlock	= false;
			//########################################################################End Collapse Off Other Block


			EditorStyles.helpBox.alignment = TextAnchor.MiddleCenter;

			//####################################################################Begin Previous Slides Animations
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("Previous Slides", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Position Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.PreviousPositionAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousPositionAnimation"), new GUIContent ("Position Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.PreviousPositionAnimation) {
				
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousOffsetTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Position Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scale Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.PreviousScaleAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousScaleAnimation"), new GUIContent ("Scale Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.PreviousScaleAnimation) {
				
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousScaleTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scale Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Rotation Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.PreviousRotateAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousRotateAnimation"), new GUIContent ("Rotate Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.PreviousRotateAnimation) {
				
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousRotationTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Rotation Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Color Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.PreviousColorAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousColorAnimation"), new GUIContent ("Color Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.PreviousColorAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousColorTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Color Animation

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Blur Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.PreviousBlurAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousBlurAnimation"), new GUIContent ("Blur Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.PreviousBlurAnimation) {
				
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("PreviousBlurTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();
			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Blur Animation
			GUI.enabled = true;
			EditorGUILayout.EndVertical ();

			EditorGUILayout.EndVertical ();
			//######################################################################End Previous Slides Animations


			EditorGUILayout.Space ();


			//#######################################################################Begin Active Slide Animations
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("Active Slide", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Position Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.ActivePositionAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActivePositionAnimation"), new GUIContent ("Position Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.ActivePositionAnimation) {
				
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveOffsetTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Position Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scale Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.ActiveScaleAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveScaleAnimation"), new GUIContent ("Scale Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.ActiveScaleAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveScaleTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scale Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Rotation Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.ActiveRotateAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveRotateAnimation"), new GUIContent ("Rotate Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.ActiveRotateAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveRotationTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Rotation Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Color Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.ActiveColorAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveColorAnimation"), new GUIContent ("Color Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.ActiveColorAnimation) {
				
				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveColorTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Color Animation

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Blur Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.ActiveBlurAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveBlurAnimation"), new GUIContent ("Blur Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.ActiveBlurAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("ActiveBlurTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Blur Animation
			GUI.enabled = true;
			EditorGUILayout.EndVertical ();

			EditorGUILayout.EndVertical ();
			//#########################################################################End Active Slide Animations


			EditorGUILayout.Space ();


			//########################################################################Begin Next Slides Animations
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);

			/*-----*/GUI.backgroundColor = new Color (0.46F, 0.46F, 0.46F, 0.5F);
			/*-----*/GUILayout.Label ("Next Slides", EditorStyles.helpBox);
			/*-----*/GUI.backgroundColor = Color.white;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Position Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.NextPositionAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextPositionAnimation"), new GUIContent ("Position Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();

			if (SliderMenuScript.NextPositionAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextOffsetTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Position Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Scale Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.NextScaleAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextScaleAnimation"), new GUIContent ("Scale Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.NextScaleAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextScaleTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Scale Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Rotation Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.NextRotateAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextRotateAnimation"), new GUIContent ("Rotate Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.NextRotateAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextRotationTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Rotation Animation

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Color Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.NextColorAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextColorAnimation"), new GUIContent ("Color Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.NextColorAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextColorTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();

			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Color Animation

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			GUI.color = Color.green;
			if(GUILayout.Button("Pro Version"))
			{
				Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/55336");
			}
			GUI.color = Color.white;
			GUI.enabled = false;
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Blur Animation
			/*-----*/EditorGUILayout.BeginHorizontal ();
			if (SliderMenuScript.NextBlurAnimation) {
				GUILayout.Label (CollapseOn, GUILayout.Width (20));
			} else {
				GUILayout.Label (CollapseOff, GUILayout.Width (20));
			}
			/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextBlurAnimation"), new GUIContent ("Blur Animation"), true);
			/*-----*/EditorGUILayout.EndHorizontal ();
			if (SliderMenuScript.NextBlurAnimation) {

				/*-----*/EditorGUILayout.BeginHorizontal ();
				/*----------*/GUILayout.Space (25);
				/*----------*/GUILayout.Label (CollapseOn, GUILayout.Width (20));
				/*----------*/EditorGUILayout.PropertyField (serializedObject.FindProperty ("NextBlurTransition"), new GUIContent ("Transition"), true);
				/*-----*/EditorGUILayout.EndHorizontal ();
				/*-----*/EditorGUILayout.Space ();
			}
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Blur Animation
			GUI.enabled = true;
			EditorGUILayout.EndVertical ();

			EditorGUILayout.EndVertical ();
			//##########################################################################End Next Slides Animations
		}


		EditorGUILayout.EndVertical ();
		//=========================================End Animations=============================================

		serializedObject.ApplyModifiedProperties();
	}
}
