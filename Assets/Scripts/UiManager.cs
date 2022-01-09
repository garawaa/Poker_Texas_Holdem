using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [HideInInspector]
    public AsyncOperation asyncLevelLoad;
    private bool callOnce;
    public Text loadingText;
    public GameObject loadingObj;

    public Text playerCoinsText;
    public Text playerProfileCoinsText;
    public Text playerName;

    public List<GameObject> listOfBuyIn;
    public List<GameObject> listOfPlayBuyIn;
    public List<GameObject> listOfEclipseBuyIn;
    public int indexOfEclipseBuyInList;
    public int indexOfBuyInList;
    public GameObject rightIndicator;
    public GameObject leftIndicator;
    public List<Transform> buyInPositions;

    public List<GameObject> listOfSitandGo;
    public List<GameObject> listOfEclipseSitandGo;
    public int indexOfEclipseSitandGoList;
    public int indexOfSitandGoList;
    public GameObject rightIndicatorSitandGo;
    public GameObject leftIndicatorSitandGo;

    [SerializeField] Text email;
    [SerializeField] Text coins;
    [SerializeField] Text level;
    [SerializeField] Text ranking;
    [SerializeField] Text wins;
    [SerializeField] Text losses;
    [SerializeField] Text raiseFreq;
    [SerializeField] Text foldFreq;
    [SerializeField] Text games;
    [SerializeField] Text Earnings;

    public GameObject playerProfileImageMainMenu;
    public List<GameObject> inGameLoginButtons;

    public GameObject autoRebuy;
    public Sprite[] autoRebuySpriteContainer;
    public GameObject autoRebuyRightIndicator;
    public GameObject autoRebuyLeftIndicator;
    public int autoRebuySpriteContainerIndex;

    public GameObject autoTopOff;
    public Sprite[] autoTopOffSpriteContainer;
    public GameObject autoTopOffRightIndicator;
    public GameObject autoTopOffLeftIndicator;
    public int autoTopOffSpriteContainerIndex;

    [System.Serializable]
    public struct MinMaxBuyIn
    {
        public int minValue;
        public int maxValue;
        public char currencyMinSuffix;
        public char currencyMaxSuffix;
    }
    public List<MinMaxBuyIn> mixMaxBuyInList;
    public Dictionary<int, MinMaxBuyIn> minMaxBuyInDict = new Dictionary<int, MinMaxBuyIn>();
    public Slider sliderBuyIn;
    public Text buyInPriceText;
    public Text playerBalanceText;
    public Text sliderMinPriceText;
    public Text sliderMaxPriceText;
    public List<string> listOfStakesText;
    public Text stakesPriceText;
    public GameObject notEnoughCoins;


    public List<int> listOfsitandGoBuyPrice;
    public List<string> listOfsitandGoBuyInText;
    public Text sitandGoBuyInText;
    public List<string> listOfSitandGoTitleText;
    public Text sitandGoTitleText;
    public List<string> listOfSitandGoBlindText;
    public Text sitandGoBlindTextText;
    public List<string> listOfSitandGoStackText;
    public Text sitandGoStackTextText;

    public GameObject BuyInSelector;
    public GameObject SitandGoSelector;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void UpdateUserStats()
    {
        playerCoinsText.text = PlayerData.Instance.coins.ToString();
        playerProfileCoinsText.text = PlayerData.Instance.coins.ToString();
        coins.text = PlayerData.Instance.coins.ToString();      
        //level.text = PlayerData.Instance.level.ToString();
        //ranking.text = PlayerData.Instance.ranking.ToString();
        wins.text = PlayerData.Instance.wins.ToString();
        //losses.text = PlayerData.Instance.losses.ToString();
        raiseFreq.text = PlayerData.Instance.raiseFreq.ToString();
        foldFreq.text = PlayerData.Instance.foldFreq.ToString();
        games.text = PlayerData.Instance.games.ToString();
        playerName.text = PlayerData.Instance.Name;
    }

    private void Start()
    {
        callOnce = true;
        BuyInSelector.SetActive(false);
        UpdateCoins();
        playerName.text = PlayerData.Instance.Name;
        //email.text = PlayerData.Instance.email;
        UpdateUserStats();
        if (PlayerPrefs.GetInt("ProfileOnceDone") == 1)
        {
            SetPlayerProf();
        }

        if (PlayerPrefs.GetInt("DisableInGameLogin") == 0)
        {
            DisableInGameLogin();
        }
        else
        {
            EnableInGameLogin();
        }

        indexOfSitandGoList = 0;
        indexOfBuyInList = 0;
        listOfBuyIn[0].gameObject.transform.position = buyInPositions[1].position;
        listOfBuyIn[1].gameObject.transform.position = buyInPositions[2].position;
        listOfBuyIn[0].gameObject.GetComponent<Button>().interactable = true;
        listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = false;
        listOfPlayBuyIn[0].gameObject.GetComponent<Button>().interactable = true;
        listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = false;

        indexOfEclipseBuyInList = 0;
        indexOfEclipseSitandGoList = 0;
        DisableAllEclipseBuyIn();
        DisableAllEclipseSitandGo();
        listOfEclipseBuyIn[0].SetActive(true);
        listOfEclipseSitandGo[0].SetActive(true);

        autoRebuySpriteContainerIndex = 0;
        autoTopOffSpriteContainerIndex = 0;

        LoadBuyInDictionary();
    }
    private void Update()
    {
        //BuyinAmount.text = "$" + Buyin.value.ToString() + "k";
        UpdateUserStats();
        try
        {
            if (asyncLevelLoad != null)
            {
                float progress = Mathf.Clamp01(asyncLevelLoad.progress / .9f);
                loadingText.text = progress * 100f + "%";
                if (asyncLevelLoad.progress >= 0.9f)
                {
                    if (callOnce)
                    {
                        callOnce = false;
                    }
                }
            }
        }
        catch (NullReferenceException ex)
        {
            print(ex.Data.ToString());
            Debug.Log("Async not loaded!");
        }
    }

    public void LoadBuyInDictionary()
    {
        for (int i = 0; i < listOfBuyIn.Count; i++)
        {
            minMaxBuyInDict.Add(i, mixMaxBuyInList[i]);
        }
    }

    public void DisableBuyInListObjects()
    {
        foreach (var item in listOfBuyIn)
        {
            item.SetActive(false);
        }
    }

    public void DisableSitandGoListObjects()
    {
        foreach (var item in listOfSitandGo)
        {
            item.SetActive(false);
        }
    }

    public void DisableAllEclipseBuyIn()
    {
        foreach (var item in listOfEclipseBuyIn)
        {
            item.SetActive(false);
        }
    }
    public void DisableAllEclipseSitandGo()
    {
        foreach (var item in listOfEclipseSitandGo)
        {
            item.SetActive(false);
        }
    }

    public void ShiftRightBuyIn()
    {
        if (indexOfBuyInList == listOfBuyIn.Count - 1)
        {
            rightIndicator.SetActive(false);
        }
        if ((indexOfBuyInList + 1) < listOfBuyIn.Count)
        {
            indexOfBuyInList++;
            indexOfEclipseBuyInList++;
            if (indexOfBuyInList >= 1)
                leftIndicator.SetActive(true);

            if (indexOfBuyInList == 1)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[0].SetActive(true);
                listOfBuyIn[1].SetActive(true);
                listOfBuyIn[2].SetActive(true);

                listOfBuyIn[0].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[2].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[0].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[2].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[0].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[1].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[2].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 2)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[1].SetActive(true);
                listOfBuyIn[2].SetActive(true);
                listOfBuyIn[3].SetActive(true);

                listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[2].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[3].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[2].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[3].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[1].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[2].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[3].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 3)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[2].SetActive(true);
                listOfBuyIn[3].SetActive(true);
                listOfBuyIn[4].SetActive(true);

                listOfBuyIn[2].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[3].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[4].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[2].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[3].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[4].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[2].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[3].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[4].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 4)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[3].SetActive(true);
                listOfBuyIn[4].SetActive(true);
                listOfBuyIn[5].SetActive(true);

                listOfBuyIn[3].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[4].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[5].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[3].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[4].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[5].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[3].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[4].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[5].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 5)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[4].SetActive(true);
                listOfBuyIn[5].SetActive(true);
                listOfBuyIn[6].SetActive(true);

                listOfBuyIn[4].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[5].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[6].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[4].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[5].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[6].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[4].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[5].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[6].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 6)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[5].SetActive(true);
                listOfBuyIn[6].SetActive(true);
                listOfBuyIn[7].SetActive(true);

                listOfBuyIn[5].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[6].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[7].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[5].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[6].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[7].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[5].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[6].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[7].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 7)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[6].SetActive(true);
                listOfBuyIn[7].SetActive(true);
                listOfBuyIn[8].SetActive(true);

                listOfBuyIn[6].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[7].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[8].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[6].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[7].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[8].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[6].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[7].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[8].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 8)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[7].SetActive(true);
                listOfBuyIn[8].SetActive(true);
                listOfBuyIn[9].SetActive(true);

                listOfBuyIn[7].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[8].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[9].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[7].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[8].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[9].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[7].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[8].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[9].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 9)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[8].SetActive(true);
                listOfBuyIn[9].SetActive(true);
                listOfBuyIn[10].SetActive(true);

                listOfBuyIn[8].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[9].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[10].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[8].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[9].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[10].gameObject.GetComponent<Button>().interactable = false;


                listOfBuyIn[8].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[9].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[10].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 10)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);

                listOfBuyIn[9].SetActive(true);
                listOfBuyIn[10].SetActive(true);

                listOfBuyIn[9].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[10].gameObject.GetComponent<Button>().interactable = true;

                listOfPlayBuyIn[9].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[10].gameObject.GetComponent<Button>().interactable = true;

                listOfBuyIn[9].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[10].gameObject.transform.position = buyInPositions[1].position;
                rightIndicator.SetActive(false);
            }
        }
    }

    public void ShiftLeftBuyIn()
    {
        if (indexOfBuyInList == 0)
        {
            leftIndicator.SetActive(false);
            rightIndicator.SetActive(true);
            
            DisableBuyInListObjects();
            DisableAllEclipseBuyIn();

            listOfEclipseBuyIn[0].SetActive(true);

            listOfBuyIn[0].SetActive(true);
            listOfBuyIn[1].SetActive(true);

            listOfBuyIn[0].gameObject.GetComponent<Button>().interactable = true;
            listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = false;

            listOfPlayBuyIn[0].gameObject.GetComponent<Button>().interactable = true;
            listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = false;

            listOfBuyIn[0].gameObject.transform.position = buyInPositions[1].position;
            listOfBuyIn[1].gameObject.transform.position = buyInPositions[2].position;
        }
        else
        {
            indexOfBuyInList--;
            indexOfEclipseBuyInList--;
            rightIndicator.SetActive(true);

            if (indexOfBuyInList == 0)
            {
                leftIndicator.SetActive(false);
                rightIndicator.SetActive(true);

                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[0].SetActive(true);

                listOfBuyIn[0].SetActive(true);
                listOfBuyIn[1].SetActive(true);

                listOfBuyIn[0].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[0].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[0].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[1].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 1)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[0].SetActive(true);
                listOfBuyIn[1].SetActive(true);
                listOfBuyIn[2].SetActive(true);

                listOfBuyIn[0].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[2].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[0].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[2].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[0].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[1].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[2].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 2)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[1].SetActive(true);
                listOfBuyIn[2].SetActive(true);
                listOfBuyIn[3].SetActive(true);

                listOfBuyIn[1].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[2].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[3].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[1].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[2].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[3].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[1].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[2].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[3].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 3)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[2].SetActive(true);
                listOfBuyIn[3].SetActive(true);
                listOfBuyIn[4].SetActive(true);

                listOfBuyIn[2].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[3].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[4].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[2].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[3].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[4].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[2].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[3].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[4].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 4)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[3].SetActive(true);
                listOfBuyIn[4].SetActive(true);
                listOfBuyIn[5].SetActive(true);

                listOfBuyIn[3].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[4].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[5].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[3].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[4].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[5].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[3].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[4].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[5].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 5)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[4].SetActive(true);
                listOfBuyIn[5].SetActive(true);
                listOfBuyIn[6].SetActive(true);

                listOfBuyIn[4].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[5].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[6].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[4].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[5].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[6].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[4].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[5].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[6].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 6)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[5].SetActive(true);
                listOfBuyIn[6].SetActive(true);
                listOfBuyIn[7].SetActive(true);

                listOfBuyIn[5].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[6].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[7].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[5].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[6].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[7].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[5].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[6].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[7].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 7)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[6].SetActive(true);
                listOfBuyIn[7].SetActive(true);
                listOfBuyIn[8].SetActive(true);

                listOfBuyIn[6].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[7].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[8].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[6].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[7].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[8].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[6].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[7].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[8].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 8)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[7].SetActive(true);
                listOfBuyIn[8].SetActive(true);
                listOfBuyIn[9].SetActive(true);

                listOfBuyIn[7].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[8].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[9].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[7].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[8].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[9].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[7].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[8].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[9].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 9)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[8].SetActive(true);
                listOfBuyIn[9].SetActive(true);
                listOfBuyIn[10].SetActive(true);

                listOfBuyIn[8].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[9].gameObject.GetComponent<Button>().interactable = true;
                listOfBuyIn[10].gameObject.GetComponent<Button>().interactable = false;

                listOfPlayBuyIn[8].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[9].gameObject.GetComponent<Button>().interactable = true;
                listOfPlayBuyIn[10].gameObject.GetComponent<Button>().interactable = false;

                listOfBuyIn[8].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[9].gameObject.transform.position = buyInPositions[1].position;
                listOfBuyIn[10].gameObject.transform.position = buyInPositions[2].position;
            }

            else if (indexOfBuyInList == 10)
            {
                DisableBuyInListObjects();
                DisableAllEclipseBuyIn();

                listOfEclipseBuyIn[indexOfEclipseBuyInList].SetActive(true);
                listOfBuyIn[9].SetActive(true);
                listOfBuyIn[10].SetActive(true);

                listOfBuyIn[9].gameObject.GetComponent<Button>().interactable = false;
                listOfBuyIn[10].gameObject.GetComponent<Button>().interactable = true;

                listOfPlayBuyIn[9].gameObject.GetComponent<Button>().interactable = false;
                listOfPlayBuyIn[10].gameObject.GetComponent<Button>().interactable = true;

                listOfBuyIn[9].gameObject.transform.position = buyInPositions[0].position;
                listOfBuyIn[10].gameObject.transform.position = buyInPositions[1].position;
            }
        }
    }

    public void ShiftRightSitandGo()
    {
        if (indexOfSitandGoList == listOfSitandGo.Count - 1)
        {
            rightIndicatorSitandGo.SetActive(false);
        }
        if((indexOfSitandGoList + 1) < listOfSitandGo.Count)
        {
            indexOfSitandGoList++;
            if (indexOfSitandGoList >= 1)
                leftIndicatorSitandGo.SetActive(true);

            if (indexOfSitandGoList == 1)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[1].SetActive(true);
                listOfSitandGo[1].SetActive(true);
            }

            else if (indexOfSitandGoList == 2)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[2].SetActive(true);
                listOfSitandGo[2].SetActive(true);
            }

            else if (indexOfSitandGoList == 3)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[3].SetActive(true);
                listOfSitandGo[3].SetActive(true);
            }

            else if (indexOfSitandGoList == 4)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[4].SetActive(true);
                listOfSitandGo[4].SetActive(true);
            }

            else if (indexOfSitandGoList == 5)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[5].SetActive(true);
                listOfSitandGo[5].SetActive(true);
            }

            else if (indexOfSitandGoList == 6)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[6].SetActive(true);
                listOfSitandGo[6].SetActive(true);
            }

            else if (indexOfSitandGoList == 7)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[7].SetActive(true);
                listOfSitandGo[7].SetActive(true);
                rightIndicatorSitandGo.SetActive(false);
            }
        }
    }

    public void ShiftLeftSitandGo()
    {
        if (indexOfSitandGoList == 0)
        {
            leftIndicatorSitandGo.SetActive(false);
            rightIndicatorSitandGo.SetActive(true);

            DisableSitandGoListObjects();
            DisableAllEclipseSitandGo();
            listOfEclipseSitandGo[0].SetActive(true);
            listOfSitandGo[0].SetActive(true);
        }
        else
        {
            indexOfSitandGoList--;
            rightIndicatorSitandGo.SetActive(true);

            if (indexOfSitandGoList == 0)
            {
                leftIndicatorSitandGo.SetActive(false);
                rightIndicatorSitandGo.SetActive(true);

                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[0].SetActive(true);
                listOfSitandGo[0].SetActive(true);
            }

            else if (indexOfSitandGoList == 1)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[1].SetActive(true);
                listOfSitandGo[1].SetActive(true);
            }

            else if (indexOfSitandGoList == 2)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[2].SetActive(true);
                listOfSitandGo[2].SetActive(true);
            }

            else if (indexOfSitandGoList == 3)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[3].SetActive(true);
                listOfSitandGo[3].SetActive(true);
            }

            else if (indexOfSitandGoList == 4)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[4].SetActive(true);
                listOfSitandGo[4].SetActive(true);
            }

            else if (indexOfSitandGoList == 5)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[5].SetActive(true);
                listOfSitandGo[5].SetActive(true);
            }

            else if (indexOfSitandGoList == 6)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[6].SetActive(true);
                listOfSitandGo[6].SetActive(true);
            }

            else if (indexOfSitandGoList == 7)
            {
                DisableSitandGoListObjects();
                DisableAllEclipseSitandGo();
                listOfEclipseSitandGo[7].SetActive(true);
                listOfSitandGo[7].SetActive(true);
                rightIndicatorSitandGo.SetActive(false);
            }
        }
    }

    public void AutoRebuyToggle()
    {
        if (autoRebuySpriteContainerIndex == 0)
        {
            autoRebuyLeftIndicator.SetActive(false);
            autoRebuyRightIndicator.SetActive(true);
            autoRebuySpriteContainerIndex = 1;
        }
        else
        {
            autoRebuyRightIndicator.SetActive(false);
            autoRebuyLeftIndicator.SetActive(true);
            autoRebuySpriteContainerIndex = 0;
        }
        autoRebuy.gameObject.GetComponent<Image>().sprite = autoRebuySpriteContainer[autoRebuySpriteContainerIndex];
    }

    public void AutoTopOffToggle()
    {
        if (autoTopOffSpriteContainerIndex == 0)
        {
            autoTopOffLeftIndicator.SetActive(false);
            autoTopOffRightIndicator.SetActive(true);
            autoTopOffSpriteContainerIndex = 1;
        }
        else
        {
            autoTopOffRightIndicator.SetActive(false);
            autoTopOffLeftIndicator.SetActive(true);
            autoTopOffSpriteContainerIndex = 0;
        }
        autoTopOff.gameObject.GetComponent<Image>().sprite = autoRebuySpriteContainer[autoTopOffSpriteContainerIndex];
    }

    public void DisableNotEnoughCoins()
    {
        notEnoughCoins.SetActive(false);
    }

    public void SelectBuyIn()
    {
        MinMaxBuyIn tempMinMax;
        tempMinMax.minValue = 0;
        tempMinMax.maxValue = 0;
        tempMinMax.currencyMinSuffix = 'K';
        tempMinMax.currencyMaxSuffix = 'K';

        sliderBuyIn.minValue = 0;
        sliderBuyIn.maxValue = 0;

        if (minMaxBuyInDict.TryGetValue(indexOfBuyInList, out tempMinMax))
        {
            if(minMaxBuyInDict[indexOfBuyInList].currencyMinSuffix == 'K')
            {
                sliderBuyIn.minValue = minMaxBuyInDict[indexOfBuyInList].minValue * 1000;
            }

            else if (minMaxBuyInDict[indexOfBuyInList].currencyMinSuffix == 'M')
            {
                sliderBuyIn.minValue = minMaxBuyInDict[indexOfBuyInList].minValue * 1000000;
            }

            else if (minMaxBuyInDict[indexOfBuyInList].currencyMinSuffix == 'B')
            {
                sliderBuyIn.minValue = minMaxBuyInDict[indexOfBuyInList].minValue * 1000000000;
            }

            if(PlayerData.Instance.coins < sliderBuyIn.minValue)
            {
                notEnoughCoins.SetActive(true);
                Invoke("DisableNotEnoughCoins", 2f);
                return;
            }

            if (minMaxBuyInDict[indexOfBuyInList].currencyMaxSuffix == 'K')
            {
                sliderBuyIn.maxValue = minMaxBuyInDict[indexOfBuyInList].maxValue * 1000;
            }

            else if (minMaxBuyInDict[indexOfBuyInList].currencyMaxSuffix == 'M')
            {
                sliderBuyIn.maxValue = minMaxBuyInDict[indexOfBuyInList].maxValue * 1000000;
            }

            else if (minMaxBuyInDict[indexOfBuyInList].currencyMaxSuffix == 'B')
            {
                sliderBuyIn.maxValue = minMaxBuyInDict[indexOfBuyInList].maxValue * 1000000000;
            }

            if (sliderBuyIn.maxValue == 200000)
            {
                PlayerPrefs.SetInt("Mode", 1);
                PlayerPrefs.SetInt("Stake", 1000);
            }
            else if (sliderBuyIn.maxValue == 1000000)
            {
                PlayerPrefs.SetInt("Mode", 2);
                PlayerPrefs.SetInt("Stake", 5000);
            }
            else if (sliderBuyIn.maxValue == 5000000)
            {
                PlayerPrefs.SetInt("Mode", 3);
                PlayerPrefs.SetInt("Stake", 25000);
            }
            else if (sliderBuyIn.maxValue == 10000000)
            {
                PlayerPrefs.SetInt("Mode", 4);
                PlayerPrefs.SetInt("Stake", 50000);
            }
            else if (sliderBuyIn.maxValue == 50000000)
            {
                PlayerPrefs.SetInt("Mode", 5);
                PlayerPrefs.SetInt("Stake", 250000);
            }
            else if (sliderBuyIn.maxValue == 100000000)
            {
                PlayerPrefs.SetInt("Mode", 6);
                PlayerPrefs.SetInt("Stake", 500000);
            }
            else if (sliderBuyIn.maxValue == 500000000)
            {
                PlayerPrefs.SetInt("Mode", 7);
                PlayerPrefs.SetInt("Stake", 2500000);
            }
            else if (sliderBuyIn.maxValue == 1000000000)
            {
                PlayerPrefs.SetInt("Mode", 8);
                PlayerPrefs.SetInt("Stake", 5000000);
            }
            else if (sliderBuyIn.maxValue == 5000000000)
            {
                PlayerPrefs.SetInt("Mode", 9);
                PlayerPrefs.SetInt("Stake", 25000000);
            }
            else if (sliderBuyIn.maxValue == 10000000000)
            {
                PlayerPrefs.SetInt("Mode", 10);
                PlayerPrefs.SetInt("Stake", 50000000);
            }
            else if (sliderBuyIn.maxValue == 20000000000)
            {
                PlayerPrefs.SetInt("Mode", 11);
                PlayerPrefs.SetInt("Stake", 100000000);
            }
            Debug.Log(PlayerPrefs.GetInt("Mode"));
            if (PlayerData.Instance.coins <= sliderBuyIn.maxValue)
            {
                sliderBuyIn.maxValue = PlayerData.Instance.coins;
            }

            BuyInSelector.SetActive(true);

            // Stakes Price Representation
            stakesPriceText.text = listOfStakesText[indexOfBuyInList];

            // Slider Min Price Representation
            Debug.Log("Slider Min Value" + minMaxBuyInDict[indexOfBuyInList].minValue);
            sliderMinPriceText.text = "$" + minMaxBuyInDict[indexOfBuyInList].minValue.ToString() + minMaxBuyInDict[indexOfBuyInList].currencyMinSuffix;

            // Slider Max Price Representation
            int tempValue = 0;
            char tempChar = 'K';
            if (sliderBuyIn.maxValue > 1000)
            {
                tempValue = (int) sliderBuyIn.maxValue / 1000;
                tempChar = 'K';
            }
            else if (sliderBuyIn.maxValue > 1000000)
            {
                tempValue = (int) sliderBuyIn.maxValue / 1000000;
                tempChar = 'M';
            }
            else if (sliderBuyIn.maxValue > 1000000000)
            {
                tempValue = (int) sliderBuyIn.maxValue / 1000000000;
                tempChar = 'B';
            }

            Debug.Log("Slider Max Value" + tempValue);
            sliderMaxPriceText.text = "$" + tempValue.ToString() + tempChar;

            // Player Balance Representation
            tempValue = 0;
            tempChar = 'K';
            if (PlayerData.Instance.coins > 1000)
            {
                tempValue = PlayerData.Instance.coins / 1000;
                tempChar = 'K';
            }
            else if (PlayerData.Instance.coins > 1000000)
            {
                tempValue = PlayerData.Instance.coins / 1000000;
                tempChar = 'M';
            }
            else if (PlayerData.Instance.coins > 1000000000)
            {
                tempValue = PlayerData.Instance.coins / 1000000000;
                tempChar = 'B';
            }
            playerBalanceText.text = "$" + tempValue.ToString() + tempChar;       
        }
        else
        {
            Debug.LogError("Dictionary Error!");
        }
        
    }

    public void UpdateSliderText()
    {
        int tempValue = 0;
        char tempChar = 'K';
        if (sliderBuyIn.value > 1000)
        {
            tempValue = (int) sliderBuyIn.value / 1000;
            tempChar = 'K';
        }
        else if (sliderBuyIn.value > 1000000)
        {
            tempValue = (int) sliderBuyIn.value / 1000000;
            tempChar = 'M';
        }
        else if (sliderBuyIn.value > 1000000000)
        {
            tempValue = (int) sliderBuyIn.value / 1000000000;
            tempChar = 'B';
        }
        buyInPriceText.text = tempValue.ToString() + tempChar;
    }

    public void PlusSlider()
    {
        if ((sliderBuyIn.value + 10000) <= sliderBuyIn.maxValue)
        {
            sliderBuyIn.value += 10000;
            int tempValue = 0;
            char tempChar = 'K';
            if (sliderBuyIn.value > 1000)
            {
                tempValue = (int)sliderBuyIn.value / 1000;
                tempChar = 'K';
            }
            else if (sliderBuyIn.value > 1000000)
            {
                tempValue = (int)sliderBuyIn.value / 1000000;
                tempChar = 'M';
            }
            else if (sliderBuyIn.value > 1000000000)
            {
                tempValue = (int)sliderBuyIn.value / 1000000000;
                tempChar = 'B';
            }
            buyInPriceText.text = tempValue.ToString() + tempChar;
        }
    }

    public void MinusSlider()
    {
        if ((sliderBuyIn.value - 10000) >= sliderBuyIn.minValue)
        {
            sliderBuyIn.value -= 10000;
            int tempValue = 0;
            char tempChar = 'K';
            if (sliderBuyIn.value > 1000)
            {
                tempValue = (int)sliderBuyIn.value / 1000;
                tempChar = 'K';
            }
            else if (sliderBuyIn.value > 1000000)
            {
                tempValue = (int)sliderBuyIn.value / 1000000;
                tempChar = 'M';
            }
            else if (sliderBuyIn.value > 1000000000)
            {
                tempValue = (int)sliderBuyIn.value / 1000000000;
                tempChar = 'B';
            }
            buyInPriceText.text = tempValue.ToString() + tempChar;
        }
    }

    public void SelectSitandGo()
    {
        if(PlayerData.Instance.coins >= listOfsitandGoBuyPrice[indexOfSitandGoList])
        {
            SitandGoSelector.SetActive(true);
            sitandGoBuyInText.text = listOfsitandGoBuyInText[indexOfSitandGoList];
            sitandGoTitleText.text = listOfSitandGoTitleText[indexOfSitandGoList];
            sitandGoBlindTextText.text = listOfSitandGoBlindText[indexOfSitandGoList];
            sitandGoStackTextText.text = listOfSitandGoStackText[indexOfSitandGoList];
        }
        else
        {
            notEnoughCoins.SetActive(true);
            Invoke("DisableNotEnoughCoins", 2f);
        }
    }

    public void DisableInGameLogin()
    {
        if (LoadingManager.isAnonymousLogin == false)
        {
            foreach (var item in inGameLoginButtons)
            {
                item.SetActive(false);
            }
        }
        
    }

    public void EnableInGameLogin()
    {
        if (LoadingManager.isAnonymousLogin)
        {
            foreach (var item in inGameLoginButtons)
            {
                item.SetActive(true);
            }
        }
    }

    public void SetPlayerProf()
    {
        playerProfileImageMainMenu.GetComponent<Image>().sprite = ProfileSelectionManager.instance.avatarList[PlayerPrefs.GetInt("AvatarIndex")].image.sprite;
        playerProfileImageMainMenu.GetComponent<Image>().SetNativeSize();
        playerProfileImageMainMenu.transform.GetChild(0).GetComponent<Image>().sprite = ProfileSelectionManager.instance.eclipseList[PlayerPrefs.GetInt("EclipseIndex")].image.sprite;
        playerProfileImageMainMenu.transform.GetChild(0).GetComponent<Image>().SetNativeSize();
    }

    public void UpdateCoins()
    {
        playerCoinsText.text = PlayerData.Instance.coins.ToString();
        Debug.LogError("playerCoins: " + PlayerData.Instance.coins);
    }

    public void UpdateCoins(Text tempText)
    {
        tempText.text = PlayerData.Instance.coins.ToString();
    }

    public void OnDiscord()
    {
        Application.OpenURL("https://discord.gg/9BQPv4qwbN");
    }
    public void StartMatch()
    {
        int buyin = (int)sliderBuyIn.value;
        PlayerPrefs.SetInt("BuyIn", buyin);
        Database.Instance.getPlayerCoins(PlayerData.Instance, -1 * buyin);
        StartCoroutine(Loading("Gameplay"));
        //SceneManager.LoadScene("Gameplay");
    }

    IEnumerator Loading(string LevelName)
    {
        loadingObj.gameObject.SetActive(true);
        asyncLevelLoad = SceneManager.LoadSceneAsync(LevelName);
        yield return asyncLevelLoad;
    }

    public void StartMatchSitandGo()
    {
        int buyin = listOfsitandGoBuyPrice[indexOfSitandGoList];
        PlayerPrefs.SetInt("BuyIn", buyin);
        Database.Instance.getPlayerCoins(PlayerData.Instance, -1 * buyin);
        SceneManager.LoadScene("Gameplay");
    }
}