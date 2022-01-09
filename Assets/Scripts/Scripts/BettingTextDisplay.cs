using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Networking;
//using System.Linq;

//DELETE THIS
public class BettingTextDisplay : Photon.MonoBehaviour {

	public Text[] chipAmountText;
	public Text[] betAmountText;

	int currentSmallBlindPos;

	int currentBigBlindPos; 
	int smallBlind = 1;

	public static int currentPlayerPos;
	public static int previousPlayerPos;

	public static int currentMinRaise;

	//get this from Player.playerNumbers
	public static List<int> activePlayerList = new List<int>(){0,1,2,3,4,5,6,7,8};

	//index of activePlayerPosList is the player number
	public static List<int> activePlayerPosList = new List<int>();

	//public List<int> foldedPlayerPosList = new List<int>();

	public static Text potAmountText;

	//this is a constant
	private List<int> allPlayerPosList = new List<int>(){0,1,2,3,4,5,6,7,8};

	//public int myPlayerNumber;

	void Start() {
		
		//assign the pot amount text object
		GameObject potAmntTextObject = new GameObject ();
		potAmntTextObject = GameObject.Find ("potAmountText");
		potAmountText = potAmntTextObject.GetComponent<Text>();

	}
		
	//de-activates non-active player positions, assigns small blind position, 
	//current player position, previous player position, and current minimum raise
	//[ClientRpc]
	public void ActivatePlayers () {

		//List<int> testPosList = GameObject.Find ("Player").GetComponent<Player> ().testPosList;

		//make current small blind the host player
		currentSmallBlindPos = 0;  //activePlayerPosList [Player.playerNumbers [0]];

		//this is different for each player
//		var myPlayerNumber = Player.myPlayerNumber;




//		GameObject playerObj = GameObject.Find("Player(Clone)");
//		Player player = playerObj.GetComponent<Player> ();
//
//		int myPlayerNumber = player.myPlayerNumber;
//
//		print ("my player number called in bet text disp: " + myPlayerNumber);
//
//		Player myPlayer = GameObject.FindWithTag (myPlayerNumber.ToString ()).GetComponent<Player> ();
	
		//myPlayer.GeneratePlayerPosList ();

		//place each player in position based on their player number and associated active player position list
		//myPlayer.PlacePlayersInPosition ();

		//de-activate player positions that are not in active player positions list
		GameObject playerObject = new GameObject();
		foreach (int playerPos in allPlayerPosList) {

			if (!activePlayerPosList.Contains (playerPos)) {
				
				playerObject = GameObject.Find ("chipAmount" + playerPos);
				playerObject.SetActive (false);

				playerObject = GameObject.Find ("betAmount" + playerPos);
				playerObject.SetActive (false);

				playerObject = GameObject.Find ("Card0-" + playerPos);
				playerObject.SetActive (false);

				playerObject = GameObject.Find ("Card1-" + playerPos);
				playerObject.SetActive (false);

			}
		}
			
		//find big blind position
		if (activePlayerPosList.IndexOf (currentSmallBlindPos) == activePlayerPosList.Count - 1) {

			currentBigBlindPos = activePlayerPosList[0];

		} else {
			
			currentBigBlindPos = activePlayerPosList [activePlayerPosList.IndexOf (currentSmallBlindPos) + 1];
		}

		//small blind chip and bet amounts
		chipAmountText [currentSmallBlindPos].text = (int.Parse(chipAmountText[currentSmallBlindPos].text) - smallBlind).ToString();
		betAmountText [currentSmallBlindPos].text = smallBlind.ToString();

		//big blind chip and bet amounts
		chipAmountText [currentBigBlindPos].text = (int.Parse(chipAmountText[currentBigBlindPos].text) - 2*smallBlind).ToString();
		betAmountText [currentBigBlindPos].text = (2*smallBlind).ToString();

		//previous player was big blind
		previousPlayerPos = currentBigBlindPos;

		//find the current player position
		if (activePlayerPosList.IndexOf (previousPlayerPos) == activePlayerPosList.Count - 1) {

			currentPlayerPos = activePlayerPosList [0];

		} else {

			currentPlayerPos = activePlayerPosList [activePlayerPosList.IndexOf (previousPlayerPos) + 1];
		}

		chipAmountText [currentPlayerPos].color = Color.yellow; 

		//the minimum raise at beginning of game is the big blind
		currentMinRaise = 2 * smallBlind;

	}
	

}
