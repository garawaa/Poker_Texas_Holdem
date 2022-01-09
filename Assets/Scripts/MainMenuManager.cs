using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class MainMenuManager : Photon.PunBehaviour
{
    public static MainMenuManager instance;

    public List<GameObject> dailyrewards;
    private bool Flag = false;
    // Start is called before the first frame update
    public TMP_Text infoText;
    private void Awake()
    {
     
        Flag = false;
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
       
    }
 
    // Update is called once per frame
    void Update()
    {
       // CheckSignedIn();
    }
   
    public void RewardCoins(int amount)
    {
        //infoText.text += "          RUN";
        Database.Instance.getPlayerCoins(PlayerData.Instance,amount);
    }

    IEnumerator RewardCoinsCo(int amount)
    {

       
        yield return new WaitForSeconds(2f);
        Debug.Log(PlayerData.Instance.coins);
       
    }

    public void RewardStars(int amount)
    {

    }

}
