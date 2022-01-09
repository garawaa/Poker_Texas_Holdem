using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData :MonoBehaviour
{

    static PlayerData instance;
    public static PlayerData Instance
    {
        get
        {
            if (PlayerData.instance == null)
            {
                PlayerData.instance = FindObjectOfType<PlayerData>();
            }
            return PlayerData.instance;
        }
    }
    public string email="0";
    public string Name = "0";
    public int coins = 0;
    public int level = 0;
    public int ranking = 0;
    public int wins = 0;
    public int losses = 0;
    public string league = "0";
    public List<string> friends;
    public int challengescompleted = 0;
    public int raiseFreq = 0;
    public int foldFreq = 0;
    public int games = 0;

}
