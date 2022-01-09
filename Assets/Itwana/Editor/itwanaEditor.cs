using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof(itwana))]
public class itwanaEditor: Editor{
	itwana itwan;

	void OnEnable(){

		itwan = (itwana)target;

	}

	public override void OnInspectorGUI(){
		//base.OnInspectorGUI ();

		EditorGUILayout.BeginVertical ();

		

		itwan.type = (itwana.Type)EditorGUILayout.EnumPopup ("type", itwan.type);


		if (itwan.type == itwana.Type.Move ||itwan.type == itwana.Type.Scale ||itwan.type == itwana.Type.Rotate) {
			itwan.method = (itwana.Method)EditorGUILayout.EnumPopup ("method", itwan.method);

			if (itwan.method == itwana.Method.To ||itwan.method == itwana.Method.Add || itwan.method == itwana.Method.By||
				itwan.method == itwana.Method.From ||itwan.method == itwana.Method.Punch || itwan.method == itwana.Method.Shake) {
			
				itwan.axis=(itwana.Axis)EditorGUILayout.EnumPopup ("axis", itwan.axis);

				if (itwan.axis == itwana.Axis.X)
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);

				if (itwan.axis == itwana.Axis.Y)
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);

				if (itwan.axis == itwana.Axis.Z)
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);
				if (itwan.axis == itwana.Axis.XYZ) {
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);
				}
				if (itwan.axis == itwana.Axis.XY) {
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);
				}
				if (itwan.axis == itwana.Axis.YZ) {
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);

				}
				if (itwan.axis == itwana.Axis.XZ) {
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);

				}
				if (itwan.type == itwana.Type.Move || itwan.type == itwana.Type.Rotate|| itwan.type == itwana.Type.Scale)
				if (itwan.method == itwana.Method.To || itwan.method == itwana.Method.From)
				if (itwan.axis == itwana.Axis.Gameobject) {
					itwan.Location=(GameObject)EditorGUILayout.ObjectField ("location",itwan.Location,typeof(GameObject),true);

				}
				itwan.easeType=(itwana.EaseType)EditorGUILayout.EnumPopup ("easeType", itwan.easeType);
				itwan.loopType=(itwana.LoopType)EditorGUILayout.EnumPopup ("loopType", itwan.loopType);

				itwan.delay = EditorGUILayout.FloatField ("delay", itwan.delay);
				itwan.time = EditorGUILayout.FloatField ("time", itwan.time);
				itwan.repeat = EditorGUILayout.Toggle ("Repeat", itwan.repeat);
				itwan.Onclick = EditorGUILayout.Toggle ("Onclick",itwan.Onclick);
                itwan.ignoreTimeScale = EditorGUILayout.Toggle("IgnoreTimeScale", itwan.ignoreTimeScale);

                }

            if (itwan.method == itwana.Method.Update) {
			
				itwan.axis=(itwana.Axis)EditorGUILayout.EnumPopup ("axis", itwan.axis);

				if (itwan.axis == itwana.Axis.X)
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);

				if (itwan.axis == itwana.Axis.Y)
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);

				if (itwan.axis == itwana.Axis.Z)
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);
				if (itwan.axis == itwana.Axis.XYZ) {
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);

				}
				if (itwan.axis == itwana.Axis.XY) {
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);
				}
				if (itwan.axis == itwana.Axis.YZ) {
					itwan.y = EditorGUILayout.FloatField ("y", itwan.y);
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);

				}
				if (itwan.axis == itwana.Axis.XZ) {
					itwan.x = EditorGUILayout.FloatField ("x", itwan.x);
					itwan.z = EditorGUILayout.FloatField ("z", itwan.z);

				}
				if (itwan.axis == itwana.Axis.Gameobject) {
					itwan.Location = (GameObject)EditorGUILayout.ObjectField ("location", itwan.Location, typeof(GameObject), true);
				}
				itwan.delay = EditorGUILayout.FloatField ("delay", itwan.delay);
				itwan.time = EditorGUILayout.FloatField ("time", itwan.time);
				itwan.repeat = EditorGUILayout.Toggle ("Repeat", itwan.repeat);
				itwan.Onclick = EditorGUILayout.Toggle ("Onclick",itwan.Onclick);
                itwan.ignoreTimeScale = EditorGUILayout.Toggle("IgnoreTimeScale", itwan.ignoreTimeScale);



                }

            }

		if (itwan.type == itwana.Type.Stab) {
			itwan.clip =(AudioClip)EditorGUILayout.ObjectField ("Clip",itwan.clip, typeof(AudioClip),true);
			itwan.pitch = EditorGUILayout.Slider ("Pitch",itwan.pitch, -3, 3);
			itwan.volume = EditorGUILayout.Slider ("Volume", itwan.volume, 0, 1);
			itwan.repeat = EditorGUILayout.Toggle ("Repeat", itwan.repeat);
			itwan.Onclick = EditorGUILayout.Toggle ("Onclick",itwan.Onclick);
            itwan.ignoreTimeScale = EditorGUILayout.Toggle("IgnoreTimeScale", itwan.ignoreTimeScale);

            }
        if (itwan.type == itwana.Type.FollowPath) {
			itwan.pathName= EditorGUILayout.TextField("pathName",itwan.pathName);
			itwan.easeType=(itwana.EaseType)EditorGUILayout.EnumPopup ("easeType", itwan.easeType);
			itwan.loopType=(itwana.LoopType)EditorGUILayout.EnumPopup ("loopType", itwan.loopType);
			itwan.delay = EditorGUILayout.FloatField ("delay", itwan.delay);
			itwan.time = EditorGUILayout.FloatField ("time", itwan.time);
			itwan.repeat = EditorGUILayout.Toggle ("Repeat", itwan.repeat);
			itwan.Onclick = EditorGUILayout.Toggle ("Onclick",itwan.Onclick);
            itwan.ignoreTimeScale = EditorGUILayout.Toggle("IgnoreTimeScale", itwan.ignoreTimeScale);

            }

        if (itwan.type == itwana.Type.Audio) {
			itwan.method = (itwana.Method)EditorGUILayout.EnumPopup ("method", itwan.method);
			if (itwan.method == itwana.Method.To || itwan.method == itwana.Method.From || itwan.method == itwana.Method.Update) {
				itwan.pitch = EditorGUILayout.Slider ("Pitch", itwan.pitch, -3, 3);
				itwan.volume = EditorGUILayout.Slider ("Volume", itwan.volume, 0, 1);
				itwan.repeat = EditorGUILayout.Toggle ("Onclick", itwan.repeat);
				itwan.Onclick = EditorGUILayout.Toggle ("Repeat", itwan.Onclick);
				itwan.ignoreTimeScale = EditorGUILayout.Toggle ("IgnoreTimeScale", itwan.ignoreTimeScale);
                }
		}

		EditorGUILayout.EndVertical ();




	}



	}
