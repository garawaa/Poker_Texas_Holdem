using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class GamePlayManager : Photon.PunBehaviour
{

	//GENERATE A HAND FOR EACH PLAYER IN GAME. MAKE SURE THERE ARE 5 COMM CARDS.
	//COMPARE THEM AND ADD POINTS TO THE WINNER

	private static PhotonView gpmPhotonView;

	public Dictionary<string, Sprite> deckDict = new Dictionary<string, Sprite>();
	public GameObject[] hand;
	public GameObject[] Flop;
	public GameObject Turn;
	public GameObject River;
	public Text Chips;
	public Text Bets;
	public Text betAmount;
	public Text RaiseAmount;
	public Text POTAmount;
	public Slider Betslider;
	public Slider raiseSlider;
	private PhotonView myPhotonView;

	public GameObject[] playerAvatarGlow;
	public GameObject[] playerAvatar;
	public Text[] playerChip;

	//these are the players that are present in the current game, identified by player number
	public static List<int> playerIDs = new List<int>();

	public static List<PhotonPlayer> playerList;
	public static int SortByID(PhotonPlayer a, PhotonPlayer b)
	{
		return b.ID.CompareTo(a.ID);
	}

	public static List<string> commCards;

	static int indexOfShuffledDeck;
	static bool flag = false;
	static bool flag1 = false;
	static List<List<string>> twoCardLists;
	static List<List<Texture2D>> texuters;
	static DealCard card1;
	static DealCard card2;
	static FlipCards flip;
	PhotonPlayer pp;

	//only populated if get to showdown. Used to add points and win to winner(s)
	static List<PhotonPlayer> winningPlayers;
	public GameObject call;
	public GameObject Raise;
	public GameObject Check;
	public GameObject Fold;
	public GameObject Bet;
	Transform originalpos;

	float TurnTime = 0;
	[SerializeField] float MaxTurnTime = 10f;
	[SerializeField] Image Timebar;
	[SerializeField] Text HandRank;

	static bool flagrunned = false;
	bool leavingRoom = false;
	bool gameStarted = false;
	//connect
	void Start()
	{
		LoadDeckDict();
		//LoadPlayerData();

		leavingRoom = false;
		
		bool roomjoined = false;
		foreach (RoomInfo r in PhotonNetwork.GetRoomList())
		{
			Debug.Log(1);
			//Debug.Log((int)r.CustomProperties["Mode"]);
			//Debug.Log(PlayerPrefs.GetInt("Mode", 1));
			if (r.PlayerCount < r.MaxPlayers)
			{			
				PhotonNetwork.JoinRoom(r.Name);
				roomjoined = true;
			}
		}
		if (roomjoined == false)
		{
			Debug.Log(2);
			RoomOptions roomOptions = new RoomOptions() { isVisible = true, maxPlayers = 6, PlayerTtl = 100000, IsOpen=true };
			PhotonNetwork.CreateRoom("", roomOptions, TypedLobby.Default);
		}
		gpmPhotonView = this.GetComponent<PhotonView>();
		PhotonNetwork.player.leftRoom = false;
		PhotonNetwork.player.myChipAmount = PlayerPrefs.GetInt("BuyIn", 40000);
		PhotonNetwork.player.AvatarGlow = PlayerPrefs.GetInt("EclipseIndex");
		PhotonNetwork.player.Avatar = PlayerPrefs.GetInt("AvatarIndex");
		PhotonNetwork.player.myBetAmount = 0;
		PhotonNetwork.player.points = 0;
		PhotonNetwork.player.wins = 0;
		PhotonNetwork.player.losses = 0;
		flag = false;
		flag1 = false;
		originalpos = Flop[0].transform;
		Timebar.gameObject.SetActive(false);
	}

	public void LoadDeckDict()
    {
		Sprite[] sprites = Resources.LoadAll<Sprite>("SpriteSheet");

		foreach (Sprite sprite in sprites)
		{
			deckDict.Add(sprite.name, sprite);
		}
	}

	public void LoadPlayerData()
	{
		foreach(var item in playerAvatarGlow)
        {
			item.transform.parent.gameObject.SetActive(false);
		}
		playerAvatarGlow[0].GetComponent<Image>().sprite = ProfileSelectionManager.instance.eclipseList[PhotonNetwork.player.AvatarGlow].image.sprite;
		playerAvatarGlow[0].GetComponent<Image>().SetNativeSize();
		playerAvatarGlow[0].transform.parent.gameObject.SetActive(true);
		for (int i=1,j=0;i<playerAvatarGlow.Length && j<playerList.Count;j++)
        {
			if (playerList[j] != PhotonNetwork.player)
			{
				playerAvatarGlow[i].GetComponent<Image>().sprite = ProfileSelectionManager.instance.eclipseList[playerList[j].AvatarGlow].image.sprite;
				playerAvatarGlow[i].GetComponent<Image>().SetNativeSize();
				playerAvatarGlow[i].transform.parent.gameObject.SetActive(true);
				i++;
			}
		}

		playerAvatar[0].GetComponent<Image>().sprite = ProfileSelectionManager.instance.avatarList[PhotonNetwork.player.Avatar].image.sprite;
		playerAvatar[0].GetComponent<Image>().SetNativeSize();
		for (int i = 1, j = 0; i < playerAvatar.Length && j < playerList.Count; j++)
		{
			if(playerList[j]!= PhotonNetwork.player)
            {
				playerAvatar[i].GetComponent<Image>().sprite = ProfileSelectionManager.instance.avatarList[playerList[j].Avatar].image.sprite;
				playerAvatar[i].GetComponent<Image>().SetNativeSize();
				i++;
			}
		}
		SetPlayerChips();

	}
	void SetPlayerChips()
    {

		int tempChip = PhotonNetwork.player.myChipAmount;
		char tempChar = 'K';
		if (tempChip >= 1000000000)
		{
			tempChip = tempChip / 1000000000;
			tempChar = 'B';
		}

		else if (tempChip >= 1000000)
		{
			tempChip = tempChip / 1000000;
			tempChar = 'M';
		}

		else if (tempChip >= 1000)
		{
			tempChip = tempChip / 1000;
			tempChar = 'K';
		}
		playerChip[0].text = "$" + tempChip + tempChar;
		Debug.Log(playerList.Count);
		for (int i = 1, j = 0; i < playerChip.Length && j < playerList.Count; j++)
		{
			if (playerList[j] != PhotonNetwork.player)
			{
				tempChip = playerList[j].myChipAmount;
				tempChar = 'K';
				if (tempChip >= 1000000000)
				{
					tempChip = tempChip / 1000000000;
					tempChar = 'B';
				}

				else if (tempChip >= 1000000)
				{
					tempChip = tempChip / 1000000;
					tempChar = 'M';
				}

				else if (tempChip >= 1000)
				{
					tempChip = tempChip / 1000;
					tempChar = 'K';
				}
				playerChip[i].text = "$" + tempChip + tempChar;
				i++;
			}
		}
	}
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	//join a random room
	public override void OnCreatedRoom()
	{
		if (PhotonNetwork.isMasterClient)
		{
			SetGameStarted(false);
			SetCurrentRound(GameState.Rounds.isPreDeal);
			GamePlayManager.SetPotAmount(0);
			SetMode(PlayerPrefs.GetInt("Mode", 1));
			SetBuyIn(PlayerPrefs.GetInt("BuyIn", 40000));
			SetBet(false);
			SetCheck(false);
			SetTurn(false);
			SetFlop(false);
			SetRiver(false);
		}
	}
	//runs only when non-local player enters
	void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
	{
		//pp = photonPlayer;
		photonPlayer.leftRoom = false;
		Debug.Log("OnPhotonPlayerConnected: " + photonPlayer);
		print("new player ID: " + photonPlayer.ID);
		//		playerIDs.Add (photonPlayer.ID); 

		//		//I PUT THIS IN UPDATE FUNCTION TEMPORARILY
		//		if (PhotonNetwork.playerList.Length > 1) {

		//			//DOESN'T WORK
		////			Player otherPlayer = GameObject.Find ("MYPlayer(Clone)").GetComponent<Player> ();

		//		}

	}
	public void OnLeftRoom()
	{
		SceneManager.LoadScene("MainMenu");
	}
	public void LeaveRoom()
	{
		PhotonNetwork.player.leftRoom = true;
		SetleavingRoom(true);
		Database.Instance.getPlayerCoins(PlayerData.Instance, PhotonNetwork.player.myChipAmount);
		if (GetGameStarted())
		{
			if(GameState.currentPlayer==PhotonNetwork.player)
            {
				FoldButtonPressed();		
				PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
			}		
		}
		PhotonNetwork.LeaveRoom();
	}
	private void OnApplicationQuit()
	{
		PhotonNetwork.player.leftRoom = true;
		Database.Instance.getPlayerCoins(PlayerData.Instance, PhotonNetwork.player.myChipAmount);
		if (GetGameStarted())
		{
			if (GameState.currentPlayer == PhotonNetwork.player)
			{
				FoldButtonPressed();
				PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
			}		
			else
            {
				leavingRoom = true;
			}
		}
		PhotonNetwork.LeaveRoom();
	}
	/// <summary>
	/// Called after switching to a new MasterClient when the current one leaves.
	/// </summary>
	/// <remarks>
	/// This is not called when this client enters a room.
	/// The former MasterClient is still in the player list when this method get called.
	/// </remarks>
	public void OnMasterClientSwitched(PhotonPlayer newMasterClient)
	{
		if (!GetGameStarted())
		{
			if (PhotonNetwork.room.PlayerCount - 1 > 1 && gameStarted == false)
			{		
				StartGame(newMasterClient);
				SetGameStarted(true);
			}
		}
	}

	bool TimeOut()
	{
		if (TurnTime <= Time.time)
		{
			return true;
		}
		return false;
	}
	void SetUIButtons()
	{
		raiseSlider.minValue = GameState.currentMinRaise * GameState.lastBetAmount;
		if (raiseSlider.minValue > PhotonNetwork.player.myChipAmount)
		{
			raiseSlider.minValue = PhotonNetwork.player.myChipAmount;
		}
		raiseSlider.maxValue = PhotonNetwork.player.myChipAmount;
		Betslider.maxValue = PhotonNetwork.player.myChipAmount;
		Chips.text = "Chips: " + PhotonNetwork.player.myChipAmount;
		Bets.text = "Bet: " + PhotonNetwork.player.myBetAmount;
		betAmount.text = Betslider.value.ToString();
		RaiseAmount.text = raiseSlider.value.ToString();
		POTAmount.text = GameState.potAmount.ToString();
	}
	void ChangeUIButtonsStateOnTurnChange()
	{
		if (GameState.currentPlayer.ID == PhotonNetwork.player.ID)
		{
			if (Getcheck())
			{
				call.SetActive(false);
				Check.SetActive(true);
			}
			else
			{
				call.SetActive(true);
				Check.SetActive(false);
			}
			if (GetBet())
			{
				Bet.SetActive(true);
				Betslider.gameObject.SetActive(true);
				betAmount.gameObject.SetActive(true);
				Raise.SetActive(false);
				raiseSlider.gameObject.SetActive(false);
				RaiseAmount.gameObject.SetActive(false);
			}
			else
			{
				Bet.SetActive(false);
				Betslider.gameObject.SetActive(false);
				betAmount.gameObject.SetActive(false);
				Raise.SetActive(true);
				raiseSlider.gameObject.SetActive(true);
				RaiseAmount.gameObject.SetActive(true);
			}
			Fold.SetActive(true);
			if (!flagrunned)
			{
				TurnTime = Time.time + MaxTurnTime;
				Timebar.gameObject.SetActive(true);
				Timebar.fillAmount = 1;
				flagrunned = true;
			}
			else
			{
				if (TimeOut())
				{
					if (Getcheck())
					{
						CheckButtonPressed();

					}
					else
					{
						CallButtonPressed();
					}
				}
			}


		}
		else
		{
			flagrunned = false;
			Timebar.gameObject.SetActive(false);
			call.SetActive(false);
			Raise.SetActive(false);
			Check.SetActive(false);
			Fold.SetActive(false);
			Bet.SetActive(false);
			Betslider.gameObject.SetActive(false);
			betAmount.gameObject.SetActive(false);
			raiseSlider.gameObject.SetActive(false);
			RaiseAmount.gameObject.SetActive(false);
		}
	}
	void PlaceCommCards()
	{
		HandRank.text = "RanK";
		if (GetFlop())
		{

			Flop[0].SetActive(true);
			Flop[1].SetActive(true);
			Flop[2].SetActive(true);
			HandRank.text = PhotonNetwork.player.hand.getRankstring();

		}
		else
		{
			//Flop[0].transform.localPosition = originalpos.localPosition;
			//Flop[1].transform.localPosition = originalpos.localPosition;
			//Flop[2].transform.localPosition = originalpos.localPosition;
			Flop[0].SetActive(false);
			Flop[1].SetActive(false);
			Flop[2].SetActive(false);
		}
		if (GetTurn())
		{

			Turn.SetActive(true);
			HandRank.text = PhotonNetwork.player.hand.getRankstring();
		}
		else
		{
			//Turn.transform.localPosition = originalpos.localPosition;
			Turn.SetActive(false);
		}
		if (GetRiver())
		{
			River.SetActive(true);
			HandRank.text = PhotonNetwork.player.hand.getRankstring();
		}
		else
		{
			//River.transform.localPosition = originalpos.localPosition;
			River.SetActive(false);
		}
	}
	void ReadyDeck()
	{
		SyncComCards();
		Debug.Log("Current Player " + GameState.currentPlayer.ID);
		if (flag1 == false)
		{
			flag1 = true;
			string card1 = PhotonNetwork.player.hand.twoCardList[0];
			string card2 = PhotonNetwork.player.hand.twoCardList[1];
			string card3 = commCards[0];
			string card4 = commCards[1];
			string card5 = commCards[2];
			string card6 = commCards[3];
			string card7 = commCards[4];

			//Sprite card1image = deckDict[card1];
			//Sprite card2image = deckDict[card2];
			//Sprite card3image = deckDict[card3];
			//Sprite card4image = deckDict[card4];
			//Sprite card5image = deckDict[card5];
			//Sprite card6image = deckDict[card6];
			//Sprite card7image = deckDict[card7];

			//Sprite card1image = Resources.Load<Sprite>("Images/" + card1);
			//Sprite card2image = Resources.Load<Sprite>("Images/" + card2);
			//Sprite card3image = Resources.Load<Sprite>("Images/" + card3);
			//Sprite card4image = Resources.Load<Sprite>("Images/" + card4);
			//Sprite card5image = Resources.Load<Sprite>("Images/" + card5);
			//Sprite card6image = Resources.Load<Sprite>("Images/" + card6);
			//Sprite card7image = Resources.Load<Sprite>("Images/" + card7);

			Debug.Log(deckDict[card1]);
			hand[0].GetComponent<Image>().sprite = deckDict[card1];
			hand[1].GetComponent<Image>().sprite = deckDict[card2];
			hand[0].SetActive(true);
			hand[1].SetActive(true);
			Flop[0].GetComponent<Image>().sprite = deckDict[card3];
			Flop[1].GetComponent<Image>().sprite = deckDict[card4];
			Flop[2].GetComponent<Image>().sprite = deckDict[card5];
			Turn.GetComponent<Image>().sprite = deckDict[card6];
			River.GetComponent<Image>().sprite = deckDict[card7];
		}
	}
	void Update()
	{
		if (PhotonNetwork.playerList.Length > 1)
		{
			if (GetGameStarted())
			{
				if (GameState.currentPlayer.leftRoom == true)
				{
					FoldButtonPressed();
				}
				if (PhotonNetwork.player == GameState.currentPlayer)
				{
					
					if (PhotonNetwork.player.myChipAmount == 0)
					{
						NextTurn();
					}
				}
				SetPlayerChips();
			}
			else
			{
				if (PhotonNetwork.player.myChipAmount == 0)
				{
					if (PlayerPrefs.GetInt("AutoBuyIn") == 1)
					{
						PhotonNetwork.player.myChipAmount = PlayerPrefs.GetInt("BuyIn", 40000);
					}
				}
				flag = false;
			}	
			if (flagrunned)
			{
				float timeleft = (TurnTime - Time.time);
				Timebar.fillAmount = timeleft / MaxTurnTime;
			}
			SetUIButtons();

			if (flag == false)
			{
				playerList = PhotonNetwork.playerList.ToList();
				playerList.Sort(SortByID);
				foreach(var item in playerList)
                {
					if(item.myChipAmount==0 || item.leftRoom==true)
                    {
						playerList.Remove(item);
                    }						
                }
			}
			gameStarted = GetGameStarted();
			if (gameStarted == true)
			{

				if (flag == false)
				{
					flag = true;
					GameState.GameBeginPlayerList = playerList;
					LoadPlayerData();
				}
				ReadyDeck();
				PlaceCommCards();
				ChangeUIButtonsStateOnTurnChange();
			}
		}
		else
		{
			if (GetGameStarted())
			{
				LeaveRoom();
			}
		}

		if (PhotonNetwork.isMasterClient)
		{
			if (PhotonNetwork.room.PlayerCount > 1 && GetGameStarted() == false)
			{
				hand[0].SetActive(false);
				hand[1].SetActive(false);
				if (GameState.dealer != null)
				{
					if (playerList.ToList().IndexOf(GameState.dealer) == playerList.Count - 1)
					{
						playerList = PhotonNetwork.playerList.ToList();
						playerList.Sort(SortByID);
						StartGame(playerList[0]);
					}
					else
					{
						PhotonPlayer newCurrentPlayer = playerList[playerList.ToList().IndexOf(GameState.dealer) + 1];
						playerList = PhotonNetwork.playerList.ToList();
						playerList.Sort(SortByID);
						StartGame(newCurrentPlayer);
					}
				}
				else
                {
					StartGame(playerList[0]);
				}			
				TurnTime = Time.time + MaxTurnTime;
				SetGameStarted(true);
			}
		}
	}

	#region setter/getters
	public static void SetCurrentPlayer(PhotonPlayer p)
	{
		GameState.currentPlayer = p;
		Hashtable hash = new Hashtable();
		hash.Add("currentPlayer", p);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public void SetGameStarted(bool p)
	{
		gameStarted = p;
		Hashtable hash = new Hashtable();
		hash.Add("GameStarted", gameStarted);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public void SetleavingRoom(bool p)
	{
		leavingRoom = p;
		Hashtable hash = new Hashtable();
		hash.Add("leavingRoom", p);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public void SetBuyIn(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("BuyIn", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
	}

	public void SetMode(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("Mode", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static void SetShuffledDeck(string[] shuffleddeck)
	{
		Hashtable hash = new Hashtable();
		hash.Add("ShuffledDeck", shuffleddeck);
		PhotonNetwork.room.SetCustomProperties(hash);
		GameState.shuffledDeck = shuffleddeck;
	}
	public static void SetCurrentRound(GameState.Rounds currentround)
	{
		Hashtable hash = new Hashtable();
		hash.Add("currentRound", currentround);
		PhotonNetwork.room.SetCustomProperties(hash);
		GameState.currentRound = currentround;
	}
	public static void SetDealer(PhotonPlayer dealer)
	{
		Hashtable hash = new Hashtable();
		hash.Add("dealer", dealer);
		PhotonNetwork.room.SetCustomProperties(hash);
		GameState.dealer = dealer;
	}
	public static void SetlastBetAmount(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("lastBetAmount", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
		GameState.lastBetAmount = amount;
	}
	public static void SetcurrentMinRaise(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("currentMinRaise", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
		GameState.currentMinRaise = amount;
	}
	public static void SetPotAmount(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("potAmount", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
		GameState.potAmount = amount;
	}
	public static void SetPlayerList(PhotonPlayer[] playerlist1)
	{
		Hashtable hash = new Hashtable();
		hash.Add("PlayerList", playerlist1);
		PhotonNetwork.room.SetCustomProperties(hash);
		//playerList = playerlist1;
	}
	public static void SetComCards(List<string> cards)
	{
		Hashtable hash = new Hashtable();
		hash.Add("ComCards", cards.ToArray());
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static void SetTotalBetsAmount(int amount)
	{
		Hashtable hash = new Hashtable();
		hash.Add("totalBetsAmount", amount);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static void SetCheck(bool check)
	{
		Hashtable hash = new Hashtable();
		hash.Add("check", check);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static bool Getcheck()
	{
		return (bool)PhotonNetwork.room.CustomProperties["check"];
	}
	public static void SetBet(bool Bet)
	{
		Hashtable hash = new Hashtable();
		hash.Add("Bet", Bet);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static bool GetBet()
	{
		return (bool)PhotonNetwork.room.CustomProperties["Bet"];
	}
	public static void SetFlop(bool check)
	{
		Hashtable hash = new Hashtable();
		hash.Add("Flop", check);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static bool GetFlop()
	{
		return (bool)PhotonNetwork.room.CustomProperties["Flop"];
	}
	public static void SetTurn(bool check)
	{
		Hashtable hash = new Hashtable();
		hash.Add("Turn", check);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static bool GetTurn()
	{
		return (bool)PhotonNetwork.room.CustomProperties["Turn"];
	}
	public static void SetRiver(bool check)
	{
		Hashtable hash = new Hashtable();
		hash.Add("River", check);
		PhotonNetwork.room.SetCustomProperties(hash);
	}
	public static bool GetRiver()
	{
		return (bool)PhotonNetwork.room.CustomProperties["River"];
	}
	public static int GetPotAmount()
	{
		return (int)PhotonNetwork.room.CustomProperties["potAmount"];
	}
	public static int GetTotalBetsAmount()
	{
		return (int)PhotonNetwork.room.CustomProperties["totalBetsAmount"];
	}
	public static void SyncComCards()
	{
		commCards = ((string[])PhotonNetwork.room.CustomProperties["ComCards"]).ToList();
	}
	public static bool GetGameStarted()
	{
		return (bool)PhotonNetwork.room.CustomProperties["GameStarted"];
	}
	public static bool GetleavingRoom()
	{
		return (bool)PhotonNetwork.room.CustomProperties["leavingRoom"];
	}
	#endregion
	//when local player joins the room
	void OnJoinedRoom()
	{

		print("player with ID " + PhotonNetwork.player.ID + " joined room");
		print("Number of Photon Players: " + PhotonNetwork.playerList.Length);
		GameObject playerGO = PhotonNetwork.Instantiate("MYPlayer", Vector3.zero, Quaternion.identity, 0);
		Player playerScript = playerGO.GetComponent<Player>();
		playerScript.ID = PhotonNetwork.player.ID;
		playerIDs.Add(playerScript.ID);
		PhotonNetwork.player.leftRoom = false;
	}
	public static void StartGame(PhotonPlayer p)
	{
		
		SetCheck(false);
		SetBet(false);
		SetTurn(false);
		SetFlop(false);
		SetRiver(false);
		flag1 = false;
		flag = false;
		flagrunned = false;
		SetPotAmount(0);
		SetlastBetAmount(0);
		print("number of players" + playerList.Count);
		//TODO: ANIMATE THE SHUFFLING DECK WITH SOUND
		//SYNC THIS ACROSS THE NETWORK
		string[] deck = ShuffleDeck().ToArray();
		SetShuffledDeck(deck);
		//game starts at preDeal round, ASK STRADDLE FOR BET
		GameState.currentRound = GameState.Rounds.isPreDeal;
		SetCurrentRound(GameState.Rounds.isPreDeal);
		//TODO: INCREMENT DEALER SINCE LAST GAME 
		GameState.dealer = p;
		SetDealer(p);
		//assigns the small blind player, big blind player and straddle player based on the dealer
		GameState.OnGameStarted();
		//small blind
		GameState.smallBlindPlayer.myBetAmount = GameState.smallBlindAmount;
		GameState.smallBlindPlayer.myChipAmount -= GameState.smallBlindAmount;
		//big blind
		GameState.bigBlindPlayer.myBetAmount = GameState.bigBlindAmount;
		GameState.bigBlindPlayer.myChipAmount -= GameState.bigBlindAmount;
		//GameState.currentPlayer = GameState.straddlePlayer;
		SetCurrentPlayer(GameState.straddlePlayer);
		//TODO: SHOW BUTTONS FOR CURRENT PLAYER
		if (GameState.currentRound == GameState.Rounds.isPreDeal)
		{
			GameState.currentRound = GameState.Rounds.isPreFlop;
			SetCurrentRound(GameState.Rounds.isPreFlop);

		}
		GenerateTwoCardHands();
		GenerateCommCards();
		GeneratePlayerHands();

	}
	public static List<string> ShuffleDeck()
	{

		List<string> myShuffledDeck = Hand.cardNames.ToList();

		//random shuffle the cards
		for (int i = 0; i < myShuffledDeck.Count; i++)
		{
			string temp = myShuffledDeck[i];
			int randomIndex = Random.Range(i, myShuffledDeck.Count);
			myShuffledDeck[i] = myShuffledDeck[randomIndex];
			myShuffledDeck[randomIndex] = temp;

			//print (i+": "+myShuffledDeck [i]);
		}

		return myShuffledDeck;

	}

	public static void GenerateTwoCardHands()
	{
		indexOfShuffledDeck = new int();

		//list of 2 card lists 
		twoCardLists = new List<List<string>>(playerList.Count);

		List<string> twoCardList;

		int playerIndex;

		//for each player in game, generate a 2-card hand
		for (playerIndex = 0; playerIndex < playerList.Count; playerIndex++)
		{

			//create a new object for list of lists to point to
			twoCardList = new List<string>(2);

			//generate a 2 card hand
			for (int i = 0; i < 2; i++)
			{
				indexOfShuffledDeck = 2 * playerIndex + i;
				string card = GameState.shuffledDeck[indexOfShuffledDeck];

				twoCardList.Add(card);
			}
			//flip.enabled=true;
			twoCardLists.Add(twoCardList);

		}

	}

	public static void GenerateCommCards()
	{

		//generate the community cards
		commCards = new List<string>(5);

		for (int i = 0; i < 5; i++)
		{

			indexOfShuffledDeck++;

			commCards.Add(GameState.shuffledDeck[indexOfShuffledDeck]);

			//print("comm card " + i + ": " + commCards[i]);

		}
		SetComCards(commCards);
	}
	public static void GeneratePlayerHands()
	{

		//each player's full hand of cards
		string[] myCards;

		//each player's Hand object
		Hand myHand;

		//creating the Hand object for each player and assigning it to the player
		for (int playerIndex = 0; playerIndex < playerList.Count; playerIndex++)
		{

			myCards = new string[7];

			//copy the 2 cards to myCards at index 0. Copy comm cards to myCards at index 2
			twoCardLists[playerIndex].CopyTo(myCards, 0);
			commCards.CopyTo(myCards, 2);

			//create the Hand object using the current myCards array
			myHand = new Hand(myCards);

			//assign the current hand to the current player
			playerList[playerIndex].hand = myHand;
		}

		//print the player IDs and their respective cards
		foreach (PhotonPlayer gamePlayer in playerList)
		{
			print("Player ID " + gamePlayer.ID + " has cards " + gamePlayer.hand.twoCardList[0] + " " + gamePlayer.hand.twoCardList[1]);

		}

	}

	public static void AddPointsToWinners()
	{

		//list of all ranks in the game
		List<double> rankList = new List<double>();

		winningPlayers = new List<PhotonPlayer>();

		double winRank = 0;

		//get the ranks, find winner
		for (int playerIndex = 0; playerIndex < playerList.Count; playerIndex++)
		{

			//add each player's rank to the rank list
			rankList.Add(playerList[playerIndex].hand.getRank());

			//finding the winning rank
			if (rankList[playerIndex] > winRank)
			{
				winRank = playerList[playerIndex].hand.getRank();
			}
		}

		int winPoints = 0;
		//calculate the points to be added to winner(s)
		foreach (double rank in rankList)
		{

			if (rank != winRank)
			{

				winPoints += (int)Mathf.Floor((float)rank) + 1;
			}
		}

		//check if there are multiple players with same win rank for tie game
		//add points to winners and add 1 win
		for (int playerIndex = 0; playerIndex < playerList.Count; playerIndex++)
		{

			if (rankList[playerIndex] == winRank)
			{

				playerList[playerIndex].points += winPoints;
				playerList[playerIndex].wins++;

				winningPlayers.Add(playerList[playerIndex]);

			}
		}

		//print the winning (or tied) player IDs and win points
		if (winningPlayers.Count > 1)
		{
			int winamount = GameState.potAmount / winningPlayers.Count;
			foreach (PhotonPlayer player in winningPlayers)
			{
				print("Tied player ID " + player.ID + " earns " + winPoints + " points.");
				winningPlayers[0].myChipAmount += winamount;
			}
			//the winner
		}
		else

		{
			print("Winning player ID " + winningPlayers[0].ID + " earns " + winPoints + " points.");
			winningPlayers[0].myChipAmount += GameState.potAmount;

		}
		GameState.potAmount -= 0;
	}

	void ShowButtons()
	{
		//show the buttons for the current player, hide for all other players

	}

	//call the RPC "Call" using the current player's PhotonView. Target all other players
	//so everyone knows that current player called
	void NextTurn()
	{
		PhotonPlayer newCurrentPlayer;
		if (playerList.IndexOf(GameState.currentPlayer) == playerList.Count - 1)
		{
			newCurrentPlayer = playerList[0];
		}
		else
		{
			newCurrentPlayer = playerList[playerList.IndexOf(GameState.currentPlayer) + 1];
		}
		//if the round is pre - flop, straddle or big blind can raise or check(if bets are equal)
		if (GameState.currentRound == GameState.Rounds.isPreFlop)
		{
			//if straddle player exists
			if (GameState.straddlePlayer != null)
			{
				if (CheckBetEquality.CheckIfBetsAreEqual() && newCurrentPlayer == GameState.straddlePlayer)
				{
					CheckBetEquality.MoveBetsToPot();
					SetCurrentRound(GameState.Rounds.isFlop);
					GameState.currentRound++;
					SetCheck(true);
					SetBet(true);
					SetFlop(true);
					//TODO: MAKE FIRST PERSON TO LEFT OF DEALER THE NEW CURRENT PLAYER
					if (playerList.ToList().IndexOf(GameState.dealer) == playerList.Count - 1)
					{
						newCurrentPlayer = playerList[0];
					}
					else
					{
						newCurrentPlayer = playerList[playerList.ToList().IndexOf(GameState.dealer) + 1];
					}
					SetCurrentPlayer(newCurrentPlayer);
				}
				else
				{

					SetCurrentPlayer(newCurrentPlayer);
				}
			}
			else
			{ //straddle player doesn't exist so big blind has option of betting/checking

				if (CheckBetEquality.CheckIfBetsAreEqual() && GameState.currentPlayer == GameState.bigBlindPlayer)
				{
					CheckBetEquality.MoveBetsToPot();
					SetCurrentRound(GameState.Rounds.isFlop);
					GameState.currentRound++;
					SetCheck(true);
					SetBet(true);
					SetFlop(true);

					//TODO: MAKE FIRST PERSON TO LEFT OF DEALER THE NEW CURRENT PLAYER
					if (playerList.ToList().IndexOf(GameState.dealer) == playerList.Count - 1)
					{
						newCurrentPlayer = playerList[0];
					}
					else
					{
						newCurrentPlayer = playerList[playerList.ToList().IndexOf(GameState.dealer) + 1];
					}
					SetCurrentPlayer(newCurrentPlayer);
				}
				else
				{

					SetCurrentPlayer(newCurrentPlayer);
				}

			}

		}
		else //round is not preflop
		{
			//if bets are equal
			Debug.Log(newCurrentPlayer == GameState.smallBlindPlayer);
			Debug.Log(CheckBetEquality.CheckIfBetsAreEqual());
			if (CheckBetEquality.CheckIfBetsAreEqual() && newCurrentPlayer == GameState.smallBlindPlayer)
			{

				CheckBetEquality.MoveBetsToPot();
				//if showdown
				if (GameState.currentRound == GameState.Rounds.isRiver)
				{

					AddPointsToWinners();
					GameState.potAmount = 0;

					if (playerList.ToList().IndexOf(GameState.dealer) == playerList.Count - 1)
					{
						playerList = PhotonNetwork.playerList.ToList();
						playerList.Sort(SortByID);
						SetGameStarted(false);

					}
					else
					{
						newCurrentPlayer = playerList[playerList.ToList().IndexOf(GameState.dealer) + 1];
						playerList = PhotonNetwork.playerList.ToList();
						playerList.Sort(SortByID);
						SetGameStarted(false);
					}
					//TODO: ANIMATE THE WIN, START NEW GAME

				}
				else
				{
					GameState.Rounds c = GameState.currentRound + 1;
					SetCurrentRound(c);
					GameState.currentRound++;
					SetCheck(true);
					SetBet(true);
					if (GetTurn())
					{
						SetRiver(true);
					}
					else
					{
						SetTurn(true);
					}
					//TODO: MAKE FIRST PERSON TO LEFT OF DEALER THE NEW CURRENT PLAYER
					if (playerList.ToList().IndexOf(GameState.dealer) == playerList.Count - 1)
					{
						newCurrentPlayer = playerList[0];
					}
					else
					{
						newCurrentPlayer = playerList[playerList.ToList().IndexOf(GameState.dealer) + 1];
					}
					playerList = GameState.GameBeginPlayerList;
					SetCurrentPlayer(newCurrentPlayer);
				}

			}
			else
			{ //bets are not equal
				SetCurrentPlayer(newCurrentPlayer);
			}
		}
	}
	public void CallButtonPressed()
	{
		SetCheck(false);
		int index = playerList.ToList().IndexOf(GameState.currentPlayer);
		if (GameState.lastBetAmount <= playerList[index].myChipAmount)
		{
			playerList[index].myBetAmount = GameState.lastBetAmount;
		}
		else
		{
			playerList[index].myBetAmount = playerList[index].myChipAmount;
		}
		playerList[index].myChipAmount -= GameState.currentPlayer.myBetAmount;
		SetlastBetAmount(playerList[index].myBetAmount);
		NextTurn();
		//GameState.currentPlayer.GetComponent<PhotonView>().RPC("Call", PhotonTargets.All);
	}

	public void FoldButtonPressed()
	{

		PhotonPlayer newCurrentPlayer;
		int pot = 0;
		foreach (PhotonPlayer p in playerList)
		{
			pot += p.myBetAmount;
			p.myBetAmount = 0;

		}
		if (playerList.IndexOf(GameState.currentPlayer) == playerList.Count - 1)
		{
			newCurrentPlayer = playerList[0];
		}
		else
		{
			newCurrentPlayer = playerList[playerList.IndexOf(GameState.currentPlayer) + 1];
		}
		playerList.RemoveAt(playerList.IndexOf(GameState.currentPlayer));
		//if only 1 player left, he is the winner
		if (playerList.Count == 1)
		{

			print("Winner ID " + playerList[0].ID);

			//add winPoints and a win to the winner
			AddPointsToWinners();

			//move the pot to the winner
			playerList[0].myChipAmount += pot + GetPotAmount();
			GameState.potAmount = 0;
			if (playerList.ToList().IndexOf(GameState.dealer) == playerList.Count - 1)
			{
				playerList = PhotonNetwork.playerList.ToList();
				playerList.Sort(SortByID);
				SetGameStarted(false);
			}
			else
			{
				newCurrentPlayer = playerList[playerList.ToList().IndexOf(GameState.dealer) + 1];
				playerList = PhotonNetwork.playerList.ToList();
				playerList.Sort(SortByID);
				SetGameStarted(false);		
			}

		}
		else
		{
			NextTurn();
		}
	}
	public void RaiseButtonPressed()
	{
		SetCheck(false);
		SetBet(false);
		int index = playerList.ToList().IndexOf(GameState.currentPlayer);
		playerList[index].myBetAmount = (int)raiseSlider.value;
		SetlastBetAmount(playerList[index].myBetAmount);
		playerList[index].myChipAmount -= GameState.currentPlayer.myBetAmount;
		NextTurn();
	}
	public void BetButtonPressed()
	{
		SetCheck(false);
		SetBet(false);
		int index = playerList.ToList().IndexOf(GameState.currentPlayer);
		playerList[index].myBetAmount = (int)Betslider.value;
		playerList[index].myChipAmount -= GameState.currentPlayer.myBetAmount;
		SetlastBetAmount(playerList[index].myBetAmount);
		NextTurn();
	}
	public void CheckButtonPressed()
	{
		NextTurn();
	}

}
