using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class itwana : MonoBehaviour {

	#region Variables
	//repository of all living iTweens:
	public Type type;
	public Method  method;
	public Axis axis;
	public float x, y, z;
	public GameObject Location;
	public EaseType easeType;
	public float time, delay;
	public LoopType loopType;
	public bool Onclick=false;
	public bool repeat=false;
	public bool ignoreTimeScale=false;
    public AudioClip clip;
	public float pitch;
	public float volume;
	public string pathName;

	public enum Axis{
		None,X,Y,Z,XY,XZ,YZ,XYZ,Gameobject
	}
	public enum Type{
		None,Scale,Move,Rotate,Stab,FollowPath,Audio
	}
	public enum Method{
		None,To,From,Add,Update,By,Punch,Shake
	}
	public enum EaseType{
		easeInQuad,
		easeOutQuad,
		easeInOutQuad,
		easeInCubic,
		easeOutCubic,
		easeInOutCubic,
		easeInQuart,
		easeOutQuart,
		easeInOutQuart,
		easeInQuint,
		easeOutQuint,
		easeInOutQuint,
		easeInSine,
		easeOutSine,
		easeInOutSine,
		easeInExpo,
		easeOutExpo,
		easeInOutExpo,
		easeInCirc,
		easeOutCirc,
		easeInOutCirc,
		linear,
		spring,
		/* GFX47 MOD START */
		//bounce,
		easeInBounce,
		easeOutBounce,
		easeInOutBounce,
		/* GFX47 MOD END */
		easeInBack,
		easeOutBack,
		easeInOutBack,
		/* GFX47 MOD START */
		//elastic,
		easeInElastic,
		easeOutElastic,
		easeInOutElastic,
		/* GFX47 MOD END */
		punch
	}



	public enum LoopType{
		none,
		loop,
		pingPong
	}


	#endregion
	int a=0;
	bool Onclickhelp=false;
	Hashtable hash=new Hashtable();

	Vector3 pos,rot,scal;
    void OnEnable()
        {
        pos = transform.localPosition;
        scal = transform.localScale;
        rot = transform.localEulerAngles;
        if(repeat)
        start();
      


        }
    void Start(){
	

        if (!repeat)
            start();
	


	}

    private void OnDisable()
        {
        if (repeat) {
            transform.localPosition = pos;
            transform.localScale = scal;
            transform.localEulerAngles = rot;
            }
        }


    void start(){
		hash=new Hashtable();


        if (method != Method.Update)
            {
            hash.Add("EaseType", "" + easeType);
            hash.Add("LoopType", "" + loopType);

            print("update not");
            }

        hash.Add("time", time);
        hash.Add("delay", delay);

        if (ignoreTimeScale)
            {
            hash.Add("ignoretimescale", ignoreTimeScale);
            }


		/////////////////////////////////Scale type Itween Methods/////////////////
		if (Type.Scale == type) {
			ScaleMethods ();

		} ///////////////////////////////////////end Scale type/////////////////////////////////////////
		else /////////////////////////////////Move type Itween Methods/////////////////
			if (Type.Move == type) {
				MoveMethods ();
			} ///////////////////////////////////////end Move type/////////////////////////////////////////
			else if (Type.Rotate == type) {
				RotateMethods();
			} ///////////////////////////////////////end Rotate type/////////////////////////////////////////
			else  if (Type.Stab == type) {
			StabMethod ();
			}
			else if (Type.FollowPath == type) {
			MovePathMethod ();
	     	}
			else if (Type.Audio == type) {
			AudioMethods ();
			}
		    else 
			{
				Debug.Log ("Select Correct type of itween");

			}




	}
	void Update(){


		if (a >= 1 && a < 27) {
			if (Onclickhelp && a == 1) {
				iTween.ScaleTo (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 2) {
				iTween.ScaleFrom (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 3) {
				iTween.ScaleAdd (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 4) {
				iTween.ScaleUpdate (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 5) {
				iTween.ScaleBy (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 6) {
				iTween.PunchScale (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 7) {
				iTween.ShakeScale (gameObject, hash);
				a = 27;
			}
			/////////////////////////////////////////////////////////////

			if (Onclickhelp && a == 8) {
				iTween.MoveTo (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 9) {
				iTween.MoveFrom (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 10) {
				iTween.MoveAdd (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 11) {
				iTween.MoveUpdate (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 12) {
				iTween.MoveBy (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 13) {
				iTween.PunchPosition (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 14) {
				iTween.ShakePosition (gameObject, hash);
				a = 27;
			}
			///////////////////////////////////////////////////////
			if (Onclickhelp && a == 15) {
				iTween.RotateTo (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 16) {
				iTween.RotateFrom (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 17) {
				iTween.RotateAdd (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 18) {
				iTween.RotateUpdate (gameObject, hash); 
				a = 27;
			}
			if (Onclickhelp && a == 19) {
				iTween.RotateBy (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 20) {
				iTween.PunchRotation (gameObject, hash);
				a = 27;
			}
			if (Onclickhelp && a == 21) {
				iTween.ShakeRotation (gameObject, hash);
				a = 27;
			}	
			if (Onclickhelp && a == 22) {
				iTween.Stab (gameObject, hash);
				a = 27;
			}

			if (Onclickhelp && a == 23) {
				iTween.MoveTo (gameObject, hash); 
				a = 27;
			}
			if (Onclickhelp && a == 24) {
				iTween.AudioTo(gameObject, hash); 
				a = 27;
			}
			if (Onclickhelp && a == 25) {
				iTween.AudioFrom(gameObject, hash); 
				a = 27;
			}
			if (Onclickhelp && a == 26) {
				iTween.AudioUpdate(gameObject, hash); 
				a = 27;
			}
		}



		if (!Onclickhelp && a == 4) {
			iTween.ScaleUpdate (gameObject, hash); 
		}
		if (!Onclickhelp && a == 11) {
			iTween.MoveUpdate (gameObject, hash); 
		}
		if (!Onclickhelp && a == 18) {
			iTween.RotateUpdate (gameObject, hash); 
		}
		if (!Onclickhelp && a == 26) {
			iTween.AudioUpdate (gameObject, hash); 
		}


	}	

	public void OnClickTwana(){
		print ("enter");
		Onclickhelp = true;

	}

	void MovePathMethod (){
		hash.Add ("path", iTweenPath.GetPath (pathName));
	
		if(!Onclick)
			iTween.MoveTo (gameObject,hash);

		a = 23;
	
	}

	void AudioMethods(){
		////////////////////////////Method To////////////////////////////////////
		if (Method.To == method) {
				
				
				if(!Onclick)
				iTween.AudioTo (gameObject,hash);
				
			a = 24;
			}
		else if (Method.From== method) {

			if(!Onclick)
				iTween.AudioFrom (gameObject,hash);

			a = 25;
		}
		else if (Method.Update== method) {

			if(!Onclick)
				iTween.AudioFrom (gameObject,hash);

			a = 26;
		}
			else {
				Debug.Log ("there is no method in Type " + type);
			}

	
	
	
	}





	void StabMethod (){
		hash.Add ("Audioclip", clip);
		hash.Add ("pitch",pitch);
		hash.Add ("volume", volume);
		if(!Onclick)
		iTween.Stab (gameObject, hash );
	
		a = 22;
	}

	void ScaleMethods(){

		////////////////////////////Method To////////////////////////////////////
		if (Method.To == method) {
			if (Axis.X == axis) {
				y = gameObject.transform.localScale.y;
				z = gameObject.transform.localScale.z;
				hash.Add ("x",x);
			
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
			}
			else if (Axis.Y == axis) {
				x =gameObject.transform.localScale.x;
				z =gameObject.transform.localScale.z;
				hash.Add ("y",y);
		
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
			}
			else if (Axis.Z == axis) {
				x = gameObject.transform.localScale.x;
				y = gameObject.transform.localScale.y;
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
			}
			else if (Axis.XY == axis) {
				z = gameObject.transform.localScale.z;
				hash.Add ("x",x);
				hash.Add ("y",y);
			
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
			}
			else if (Axis.XZ == axis) {
				y = gameObject.transform.localScale.y;
				hash.Add ("x",x);
				hash.Add ("z",z);
			
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
			}
			else if (Axis.YZ == axis) {
				x = gameObject.transform.localScale.x;
				hash.Add ("y",y);
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
			}
			else if (Axis.XYZ == axis) {
				hash.Add ("x",x);
				hash.Add ("y",y);
				hash.Add ("z",z);
			
				if(!Onclick)
					iTween.ScaleTo (gameObject,hash);

				a = 1;
                }
            else if (Axis.Gameobject == axis)
                {
                hash.Add("scale", Location.transform.localScale);

                if (!Onclick)
                    iTween.ScaleTo(gameObject, hash);

                a = 1;
                }
            } 
		///////////////////////////////////////////////////End Method to/////////////////////////////////////
		
		///////////////////////////////////////////////// method Form/////////////////////////////////////////////////////
		else if (Method.From == method) {
			if (Axis.X == axis) {
				y = gameObject.transform.localScale.y;
				z = gameObject.transform.localScale.z;
				hash.Add ("x",x);
		
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
			}
			else if (Axis.Y == axis) {
				x =gameObject.transform.localScale.x;
				z =gameObject.transform.localScale.z;
				hash.Add ("y",y);
		
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
			}
			else if (Axis.Z == axis) {
				x = gameObject.transform.localScale.x;
				y = gameObject.transform.localScale.y;
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
			}
			else if (Axis.XY == axis) {
				z = gameObject.transform.localScale.z;
				hash.Add ("x",x);
				hash.Add ("y",y);
		
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
			}
			else if (Axis.XZ == axis) {
				y = gameObject.transform.localScale.y;
				hash.Add ("x",x);
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
			}
			else if (Axis.YZ == axis) {
				x = gameObject.transform.localScale.x;
				hash.Add ("y",y);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
			}
			else if (Axis.XYZ == axis) {
				hash.Add ("x",x);
				hash.Add ("y",y);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.ScaleFrom (gameObject,hash);

				a = 2;
                }
            else if (Axis.Gameobject == axis)
                {
                hash.Add("scale", Location.transform.localScale);

                if (!Onclick)
                    iTween.ScaleFrom(gameObject, hash);

                a = 2;
                }



            } 
		///////////////////////////////////////////////////End Method From/////////////////////////////////////
	
		/// 		///////////////////////////////////////////////////Method Add/////////////////////////////////////
		else  if (Method.Add == method) {
			if (Axis.X == axis) {
				y = gameObject.transform.localScale.y;
				z = gameObject.transform.localScale.z;
				hash.Add ("x",x);
	
				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}
			else if (Axis.Y == axis) {
				x =gameObject.transform.localScale.x;
				z =gameObject.transform.localScale.z;
				hash.Add ("y",y);
		
				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}
			else if (Axis.Z == axis) {
				x = gameObject.transform.localScale.x;
				y = gameObject.transform.localScale.y;
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}
			else if (Axis.XY == axis) {
				z = gameObject.transform.localScale.z;
				hash.Add ("x",x);
				hash.Add ("y",y);
		
				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}
			else if (Axis.XZ == axis) {
				y = gameObject.transform.localScale.y;
				hash.Add ("x",x);
				hash.Add ("z",z);

				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}
			else if (Axis.YZ == axis) {
				x = gameObject.transform.localScale.x;
				hash.Add ("y",y);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}
			else if (Axis.XYZ == axis) {
				hash.Add ("x",x);
				hash.Add ("y",y);
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.ScaleAdd (gameObject,hash);

				a = 3;
			}



		} 
		///////////////////////////////////////////////////End Method Add/////////////////////////////////////
		/// 
		else /// 		///////////////////////////////////////////////////Method update/////////////////////////////////////
			if (Method.Update == method) {
				if (Axis.X == axis) {
					y = gameObject.transform.localScale.y;
					z = gameObject.transform.localScale.z;
					hash.Add ("x",x);
		
					a = 4;
				}
				else if (Axis.Y == axis) {
					x =gameObject.transform.localScale.x;
					z =gameObject.transform.localScale.z;
					hash.Add ("y",y);
		
					a = 4;

				}
				else if (Axis.Z == axis) {
					x = gameObject.transform.localScale.x;
					y = gameObject.transform.localScale.y;
					hash.Add ("z",z);
		
					a = 4;
				}
				else if (Axis.XY == axis) {
					z = gameObject.transform.localScale.z;
					hash.Add ("x",x);
					hash.Add ("y",y);
		
					a = 4;
				}
				else if (Axis.XZ == axis) {
					y = gameObject.transform.localScale.y;
					hash.Add ("x",x);
					hash.Add ("z",z);
			
					a = 4;
				}
				else if (Axis.YZ == axis) {
					x = gameObject.transform.localScale.x;
					hash.Add ("y",y);
					hash.Add ("z",z);
		
					a = 4;
				}
				else if (Axis.XYZ == axis) {
					hash.Add ("x",x);
					hash.Add ("y",y);
					hash.Add ("z",z);
			
					a = 4;
				}



			} 
		///////////////////////////////////////////////////End Method update/////////////////////////////////////
		/// 
		/// ////////////////////////Method By//////////////////////////////////////////////////////////////////
			else if (Method.By == method) {
				if (Axis.X == axis) {
					y = gameObject.transform.localScale.y;
					z = gameObject.transform.localScale.z;
					hash.Add ("x",x);
		
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;
				}
				else if (Axis.Y == axis) {
					x =gameObject.transform.localScale.x;
					z =gameObject.transform.localScale.z;
					hash.Add ("y",y);
	
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;
				}
				else if (Axis.Z == axis) {
					x = gameObject.transform.localScale.x;
					y = gameObject.transform.localScale.y;
					hash.Add ("z",z);
		
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;
				}
				else if (Axis.XY == axis) {
					z = gameObject.transform.localScale.z;
					hash.Add ("x",x);
					hash.Add ("y",y);
		
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;
				}
				else if (Axis.XZ == axis) {
					y = gameObject.transform.localScale.y;
					hash.Add ("x",x);
					hash.Add ("z",z);
		
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;
				}
				else if (Axis.YZ == axis) {
					x = gameObject.transform.localScale.x;
					hash.Add ("y",y);
					hash.Add ("z",z);
	
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;
				}
				else if (Axis.XYZ == axis) {
					hash.Add ("x",x);
					hash.Add ("y",y);
					hash.Add ("z",z);
	
					if(!Onclick)
						iTween.ScaleBy (gameObject,hash);

					a = 5;

				}
			}
		///////////////////////////////////////end Method By////////////////////////////////////////
			else 
				/// ////////////////////////Method Punch//////////////////////////////////////////////////////////////////
				if (Method.Punch == method) {
					if (Axis.X == axis) {
						y = gameObject.transform.localScale.y;
						z = gameObject.transform.localScale.z;
						hash.Add ("x",x);
	
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;

					}
					else if (Axis.Y == axis) {
						x =gameObject.transform.localScale.x;
						z =gameObject.transform.localScale.z;
						hash.Add ("y",y);
	
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;
					}
					else if (Axis.Z == axis) {
						x = gameObject.transform.localScale.x;
						y = gameObject.transform.localScale.y;
						hash.Add ("z",z);
		
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;
					}
					else if (Axis.XY == axis) {
						z = gameObject.transform.localScale.z;
						hash.Add ("x",x);
						hash.Add ("y",y);
			
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;
					}
					else if (Axis.XZ == axis) {
						y = gameObject.transform.localScale.y;
						hash.Add ("x",x);
						hash.Add ("z",z);
			
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;
					}
					else if (Axis.YZ == axis) {
						x = gameObject.transform.localScale.x;
						hash.Add ("y",y);
						hash.Add ("z",z);
		
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;
					}
					else if (Axis.XYZ == axis) {
						hash.Add ("x",x);
						hash.Add ("y",y);
						hash.Add ("z",z);
				
						if (!Onclick) 
							iTween.PunchScale (gameObject,hash);
						a = 6;

					}
				}
		///////////////////////////////////////end Method Punch////////////////////////////////////////
				else		/// ////////////////////////Method Shake//////////////////////////////////////////////////////////////////

					if (Method.Shake == method) {
						if (Axis.X == axis) {
							y = gameObject.transform.localScale.y;
							z = gameObject.transform.localScale.z;
							hash.Add ("x",x);
	
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;

						}
						else if (Axis.Y == axis) {
							x =gameObject.transform.localScale.x;
							z =gameObject.transform.localScale.z;
							hash.Add ("y",y);
		
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;
						}
						else if (Axis.Z == axis) {
							x = gameObject.transform.localScale.x;
							y = gameObject.transform.localScale.y;
							hash.Add ("z",z);
			
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;
						}
						else if (Axis.XY == axis) {
							z = gameObject.transform.localScale.z;
							hash.Add ("x",x);
							hash.Add ("y",y);
				
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;
						}
						else if (Axis.XZ == axis) {
							y = gameObject.transform.localScale.y;
							hash.Add ("x",x);
							hash.Add ("z",z);
				
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;
						}
						else if (Axis.YZ == axis) {
							x = gameObject.transform.localScale.x;
							hash.Add ("y",y);
							hash.Add ("z",z);
		
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;
						}
						else if (Axis.XYZ == axis) {
							hash.Add ("x",x);
							hash.Add ("y",y);
							hash.Add ("z",z);
				
							if (!Onclick) 
								iTween.ShakeScale (gameObject,hash);
							a = 7;

						}
					}
		///////////////////////////////////////end Method Shake//////////////////////////////////////// 
					else {
						Debug.Log ("there is no method in Type" + type);
					}





	}

	void MoveMethods(){

		/////////////////////////////Method To////////////////////////////////////
		if (Method.To == method) {
			if (Axis.X == axis) {
				y = gameObject.transform.localPosition.y;
				z = gameObject.transform.localPosition.z;
				hash.Add ("x",x);

				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.Y == axis) {
				x =gameObject.transform.localPosition.x;
				z =gameObject.transform.localPosition.z;
				hash.Add ("y",y);
	
				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.Z == axis) {
				x = gameObject.transform.localPosition.x;
				y = gameObject.transform.localPosition.y;
				hash.Add ("z",z);

				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.XY == axis) {
				z = gameObject.transform.localPosition.z;
				hash.Add ("x",x);
				hash.Add ("y",y);
	
				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.XZ == axis) {
				y = gameObject.transform.localPosition.y;
				hash.Add ("x",x);
				hash.Add ("z",z);

				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.YZ == axis) {
				x = gameObject.transform.localPosition.x;
				hash.Add ("y",y);
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.XYZ == axis) {
				hash.Add ("x",x);
				hash.Add ("y",y);
				hash.Add ("z",z);

				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
			else if (Axis.Gameobject == axis) {
				hash.Add ("position", Location.transform.position);
	
				if(!Onclick)
					iTween.MoveTo (gameObject,hash);

				a = 8;
			}
		} 
		///////////////////////////////////////////////////End Method to/////////////////////////////////////
	
		///////////////////////////////////////////////// method Form/////////////////////////////////////////////////////
		else if (Method.From == method) {
			if (Axis.X == axis) {
				y = gameObject.transform.localPosition.y;
				z = gameObject.transform.localPosition.z;
				hash.Add ("x",x);

				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.Y == axis) {
				x =gameObject.transform.localPosition.x;
				z =gameObject.transform.localPosition.z;
				hash.Add ("y",y);
	
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.Z == axis) {
				x = gameObject.transform.localPosition.x;
				y = gameObject.transform.localPosition.y;
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.XY == axis) {
				z = gameObject.transform.localPosition.z;
				hash.Add ("x",x);
				hash.Add ("y",y);
		
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.XZ == axis) {
				y = gameObject.transform.localPosition.y;
				hash.Add ("x",x);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.YZ == axis) {
				x = gameObject.transform.localPosition.x;
				hash.Add ("y",y);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.XYZ == axis) {
				hash.Add ("x",x);
				hash.Add ("y",y);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}
			else if (Axis.Gameobject == axis) {
				hash.Add ("position", Location.transform.position);
	
				if(!Onclick)
					iTween.MoveFrom (gameObject,hash);

				a = 9;
			}



		} 
		///////////////////////////////////////////////////End Method From/////////////////////////////////////
		/// 
		/// 		///////////////////////////////////////////////////Method Add/////////////////////////////////////
		else  if (Method.Add == method) {
			if (Axis.X == axis) {
				y = gameObject.transform.localPosition.y;
				z = gameObject.transform.localPosition.z;
				hash.Add ("x",x);
	
				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}
			else if (Axis.Y == axis) {
				x =gameObject.transform.localPosition.x;
				z =gameObject.transform.localPosition.z;
				hash.Add ("y",y);
	
				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}
			else if (Axis.Z == axis) {
				x = gameObject.transform.localPosition.x;
				y = gameObject.transform.localPosition.y;
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}
			else if (Axis.XY == axis) {
				z = gameObject.transform.localPosition.z;
				hash.Add ("x",x);
				hash.Add ("y",y);
			
				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}
			else if (Axis.XZ == axis) {
				y = gameObject.transform.localPosition.y;
				hash.Add ("x",x);
				hash.Add ("z",z);
		
				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}
			else if (Axis.YZ == axis) {
				x = gameObject.transform.localPosition.x;
				hash.Add ("y",y);
				hash.Add ("z",z);

				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}
			else if (Axis.XYZ == axis) {
				hash.Add ("x",x);
				hash.Add ("y",y);
				hash.Add ("z",z);
	
				if(!Onclick)
					iTween.MoveAdd (gameObject,hash);

				a = 10;
			}





		} 
		///////////////////////////////////////////////////End Method Add/////////////////////////////////////
		/// 
		else /// 		///////////////////////////////////////////////////Method update/////////////////////////////////////
			if (Method.Update == method) {
				if (Axis.X == axis) {
					y = gameObject.transform.localPosition.y;
					z = gameObject.transform.localPosition.z;
					hash.Add ("x",x);
		
					a = 11;
				}
				else if (Axis.Y == axis) {
					x =gameObject.transform.localPosition.x;
					z =gameObject.transform.localPosition.z;
					hash.Add ("y",y);
		
					a = 11;

				}
				else if (Axis.Z == axis) {
					x = gameObject.transform.localPosition.x;
					y = gameObject.transform.localPosition.y;
					hash.Add ("z",z);
		
					a = 11;
				}
				else if (Axis.XY == axis) {
					z = gameObject.transform.localPosition.z;
					hash.Add ("x",x);
					hash.Add ("y",y);
			
					a = 11;
				}
				else if (Axis.XZ == axis) {
					y = gameObject.transform.localPosition.y;
					hash.Add ("x",x);
					hash.Add ("z",z);
	
					a = 11;
				}
				else if (Axis.YZ == axis) {
					x = gameObject.transform.localPosition.x;
					hash.Add ("y",y);
					hash.Add ("z",z);
	
					a = 11;
				}
				else if (Axis.XYZ == axis) {
					hash.Add ("x",x);
					hash.Add ("y",y);
					hash.Add ("z",z);
		
					a = 11;
				}
				else if (Axis.Gameobject == axis) {
					hash.Add ("position", Location.transform.position);
			

					a = 11;
				}



			} 
		///////////////////////////////////////////////////End Method update/////////////////////////////////////

		/// ////////////////////////Method By//////////////////////////////////////////////////////////////////
			else if (Method.By == method) {
				if (Axis.X == axis) {
					y = gameObject.transform.localPosition.y;
					z = gameObject.transform.localPosition.z;
					hash.Add ("x",x);
			
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;
				}
				else if (Axis.Y == axis) {
					x =gameObject.transform.localPosition.x;
					z =gameObject.transform.localPosition.z;
					hash.Add ("y",y);
		
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;
				}
				else if (Axis.Z == axis) {
					x = gameObject.transform.localPosition.x;
					y = gameObject.transform.localPosition.y;
					hash.Add ("z",z);
	
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;
				}
				else if (Axis.XY == axis) {
					z = gameObject.transform.localPosition.z;
					hash.Add ("x",x);
					hash.Add ("y",y);
			
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;
				}
				else if (Axis.XZ == axis) {
					y = gameObject.transform.localPosition.y;
					hash.Add ("x",x);
					hash.Add ("z",z);
			
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;
				}
				else if (Axis.YZ == axis) {
					x = gameObject.transform.localPosition.x;
					hash.Add ("y",y);
					hash.Add ("z",z);
		
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;
				}
				else if (Axis.XYZ == axis) {
					hash.Add ("x",x);
					hash.Add ("y",y);
					hash.Add ("z",z);
		
					if(!Onclick)
						iTween.MoveBy (gameObject,hash);

					a = 12;

				}
			

			}
		///////////////////////////////////////end Method By////////////////////////////////////////
			else 
				/// ////////////////////////Method Punch//////////////////////////////////////////////////////////////////
				if (Method.Punch == method) {
					if (Axis.X == axis) {
						y = gameObject.transform.localPosition.y;
						z = gameObject.transform.localPosition.z;
						hash.Add ("x",x);
				
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;

					}
					else if (Axis.Y == axis) {
						x =gameObject.transform.localPosition.x;
						z =gameObject.transform.localPosition.z;
						hash.Add ("y",y);
			
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;
					}
					else if (Axis.Z == axis) {
						x = gameObject.transform.localPosition.x;
						y = gameObject.transform.localPosition.y;
						hash.Add ("z",z);
		
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;
					}
					else if (Axis.XY == axis) {
						z = gameObject.transform.localPosition.z;
						hash.Add ("x",x);
						hash.Add ("y",y);
			
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;
					}
					else if (Axis.XZ == axis) {
						y = gameObject.transform.localPosition.y;
						hash.Add ("x",x);
						hash.Add ("z",z);
				
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;
					}
					else if (Axis.YZ == axis) {
						x = gameObject.transform.localPosition.x;
						hash.Add ("y",y);
						hash.Add ("z",z);
		
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;
					}
					else if (Axis.XYZ == axis) {
						hash.Add ("x",x);
						hash.Add ("y",y);
						hash.Add ("z",z);
			
						if (!Onclick) 
							iTween.PunchPosition (gameObject,hash);
						a = 13;

					}
				

				}
		///////////////////////////////////////end Method Punch////////////////////////////////////////
				else		/// ////////////////////////Method Shake//////////////////////////////////////////////////////////////////

					if (Method.Shake == method) {
						if (Axis.X == axis) {
							y = gameObject.transform.localPosition.y;
							z = gameObject.transform.localPosition.z;
							hash.Add ("x",x);
				
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;

						}
						else if (Axis.Y == axis) {
							x =gameObject.transform.localPosition.x;
							z =gameObject.transform.localPosition.z;
							hash.Add ("y",y);
			
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;
						}
						else if (Axis.Z == axis) {
							x = gameObject.transform.localPosition.x;
							y = gameObject.transform.localPosition.y;
							hash.Add ("z",z);
				
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;
						}
						else if (Axis.XY == axis) {
							z = gameObject.transform.localPosition.z;
							hash.Add ("x",x);
							hash.Add ("y",y);
		
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;
						}
						else if (Axis.XZ == axis) {
							y = gameObject.transform.localPosition.y;
							hash.Add ("x",x);
							hash.Add ("z",z);
				
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;
						}
						else if (Axis.YZ == axis) {
							x = gameObject.transform.localPosition.x;
							hash.Add ("y",y);
							hash.Add ("z",z);
					
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;
						}
						else if (Axis.XYZ == axis) {
							hash.Add ("x",x);
							hash.Add ("y",y);
							hash.Add ("z",z);
			
							if (!Onclick) 
								iTween.ShakePosition (gameObject,hash);
							a = 14;

						}


					}
		///////////////////////////////////////end Method Shake////////////////////////////////////////
					else {
						Debug.Log ("there is no method in Type" + type);
					}

	}

    void RotateMethods()
        {

        ////////////////////////////Method To////////////////////////////////////
        if (Method.To == method)
            {
            if (Axis.X == axis)
                {
                y = gameObject.transform.localRotation.y;
                z = gameObject.transform.localRotation.z;
                hash.Add("x", x);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.Y == axis)
                {
                x = gameObject.transform.localRotation.x;
                z = gameObject.transform.localRotation.z;
                hash.Add("y", y);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.Z == axis)
                {
                x = gameObject.transform.localRotation.x;
                y = gameObject.transform.localRotation.y;
                hash.Add("z", z);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.XY == axis)
                {
                z = gameObject.transform.localRotation.z;
                hash.Add("x", x);
                hash.Add("y", y);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.XZ == axis)
                {
                y = gameObject.transform.localRotation.y;
                hash.Add("x", x);
                hash.Add("z", z);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.YZ == axis)
                {
                x = gameObject.transform.localRotation.x;
                hash.Add("y", y);
                hash.Add("z", z);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.XYZ == axis)
                {
                hash.Add("x", x);
                hash.Add("y", y);
                hash.Add("z", z);


                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            else if (Axis.Gameobject == axis)
                {
                hash.Add("rotation", Location.transform.localEulerAngles);

                if (!Onclick)
                    iTween.RotateTo(gameObject, hash);

                a = 15;
                }
            ///////////////////////////////////////////////////End Method to/////////////////////////////////////
            }
            /// 
            ///////////////////////////////////////////////// method Form/////////////////////////////////////////////////////
            else if (Method.From == method)
                {
                if (Axis.X == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.Y == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.Z == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    y = gameObject.transform.localRotation.y;
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.XY == axis)
                    {
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.XZ == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    hash.Add("x", x);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.YZ == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.XYZ == axis)
                    {
                    hash.Add("x", x);
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }
                else if (Axis.Gameobject == axis)
                    {
                    hash.Add("rotation", Location.transform.localEulerAngles);

                    if (!Onclick)
                        iTween.RotateFrom(gameObject, hash);

                    a = 16;
                    }



                }
            ///////////////////////////////////////////////////End Method From/////////////////////////////////////
            /// 
            /// 		///////////////////////////////////////////////////Method Add/////////////////////////////////////
            else if (Method.Add == method)
                {
                if (Axis.X == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }
                else if (Axis.Y == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }
                else if (Axis.Z == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    y = gameObject.transform.localRotation.y;
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }
                else if (Axis.XY == axis)
                    {
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }
                else if (Axis.XZ == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    hash.Add("x", x);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }
                else if (Axis.YZ == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }
                else if (Axis.XYZ == axis)
                    {
                    hash.Add("x", x);
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateAdd(gameObject, hash);

                    a = 17;
                    }



                }
            ///////////////////////////////////////////////////End Method Add/////////////////////////////////////
            /// 
            else /// 		///////////////////////////////////////////////////Method update/////////////////////////////////////
           if (Method.Update == method)
                {
                if (Axis.X == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);

                    a = 18;
                    }
                else if (Axis.Y == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("y", y);

                    a = 18;

                    }
                else if (Axis.Z == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    y = gameObject.transform.localRotation.y;
                    hash.Add("z", z);

                    a = 18;
                    }
                else if (Axis.XY == axis)
                    {
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);
                    hash.Add("y", y);

                    a = 18;
                    }
                else if (Axis.XZ == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    hash.Add("x", x);
                    hash.Add("z", z);

                    a = 18;
                    }
                else if (Axis.YZ == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    hash.Add("y", y);
                    hash.Add("z", z);

                    a = 18;
                    }
                else if (Axis.XYZ == axis)
                    {
                    hash.Add("x", x);
                    hash.Add("y", y);
                    hash.Add("z", z);

                    a = 18;
                    }



                }
            ///////////////////////////////////////////////////End Method update/////////////////////////////////////
            /// 
            /// ////////////////////////Method By//////////////////////////////////////////////////////////////////
            else if (Method.By == method)
                {
                if (Axis.X == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;
                    }
                else if (Axis.Y == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;
                    }
                else if (Axis.Z == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    y = gameObject.transform.localRotation.y;
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;
                    }
                else if (Axis.XY == axis)
                    {
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;
                    }
                else if (Axis.XZ == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    hash.Add("x", x);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;
                    }
                else if (Axis.YZ == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;
                    }
                else if (Axis.XYZ == axis)
                    {
                    hash.Add("x", x);
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.RotateBy(gameObject, hash);

                    a = 19;

                    }
                }
            ///////////////////////////////////////end Method By////////////////////////////////////////
            else
                /// ////////////////////////Method Punch//////////////////////////////////////////////////////////////////
                if (Method.Punch == method)
                {
                if (Axis.X == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;

                    }
                else if (Axis.Y == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;
                    }
                else if (Axis.Z == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    y = gameObject.transform.localRotation.y;
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;
                    }
                else if (Axis.XY == axis)
                    {
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;
                    }
                else if (Axis.XZ == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    hash.Add("x", x);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;
                    }
                else if (Axis.YZ == axis)
                    {
                    x = gameObject.transform.localRotation.x;
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;
                    }
                else if (Axis.XYZ == axis)
                    {
                    hash.Add("x", x);
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.PunchRotation(gameObject, hash);
                    a = 20;

                    }
                }
            ///////////////////////////////////////end Method Punch////////////////////////////////////////
            else        /// ////////////////////////Method Shake//////////////////////////////////////////////////////////////////

                    if (Method.Shake == method)
                {
                if (Axis.X == axis)
                    {
                    y = gameObject.transform.localRotation.y;
                    z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;

                    }
                else if (Axis.Y == axis)
                    {
                    //							x =gameObject.transform.localPosition.x;
                    //							z =gameObject.transform.localPosition.z;
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;
                    }
                else if (Axis.Z == axis)
                    {
                    //							x = gameObject.transform.localPosition.x;
                    //							y = gameObject.transform.localPosition.y;
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;
                    }
                else if (Axis.XY == axis)
                    {
                    //							z = gameObject.transform.localRotation.z;
                    hash.Add("x", x);
                    hash.Add("y", y);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;
                    }
                else if (Axis.XZ == axis)
                    {
                    //							y = gameObject.transform.localPosition.y;
                    hash.Add("x", x);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;
                    }
                else if (Axis.YZ == axis)
                    {
                    //							x = gameObject.transform.localPosition.x;
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;
                    }
                else if (Axis.XYZ == axis)
                    {
                    hash.Add("x", x);
                    hash.Add("y", y);
                    hash.Add("z", z);

                    if (!Onclick)
                        iTween.ShakeRotation(gameObject, hash);
                    a = 21;

                    }
                }
            ///////////////////////////////////////end Method Shake////////////////////////////////////////
            else
                {
                Debug.Log("there is no method in Type" + type);
                }
            }
        }

