using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class cardBack : MonoBehaviour {

	public Mesh backColor1 ;
	public Mesh backColor2 ;
	public Mesh backColor3 ;

	public enum CardBack {Color1, Color2, Color3}
	public CardBack cardBackColor ;

	// Update function for [ExecuteInEditMode] work on realtime
	// You can put this code on Start function for optimization, but can't see the back color in realtime in editmode
	void Update () {
		
		switch (cardBackColor) {
		case CardBack.Color1 :
			GetComponent<MeshFilter>().sharedMesh = backColor1 ;
			break ;
		case CardBack.Color2 :
			GetComponent<MeshFilter>().sharedMesh = backColor2 ;
			break ;
		case CardBack.Color3 :
			GetComponent<MeshFilter>().sharedMesh = backColor3 ;
			break ;
		default :
			break ;
		}
		
	}

}
