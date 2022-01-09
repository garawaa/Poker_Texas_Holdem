using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase;
using TMPro;

public class Database : MonoBehaviour
{
    FirebaseFirestore db;

    static Database instance;

    public TMP_Text infoText;
    public static bool wait;
    public static Database Instance
    {
        get
        {
            if (Database.instance == null)
            {
                Database.instance = FindObjectOfType<Database>();
            }
            return Database.instance;
        }
    }
    private void Awake()
    {
        wait = false;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    db = FirebaseFirestore.DefaultInstance;
                }
                    
                else
                  Debug.Log("error2");
            }
            else
            {
                Debug.Log("error1");
            }
        });
       
    }
    public void AddData()
    {
        PlayerData.Instance.email = "A";
        PlayerData.Instance.Name = "B";
        Database.Instance.CreateorGetPlayerData(PlayerData.Instance);
    }
    public void CreateorGetPlayerData(PlayerData data)
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("Players").Document(data.email);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                DocumentSnapshot document = task.Result;
                Dictionary<string, object> documentDictionary = snapshot.ToDictionary();
                data.Name = documentDictionary["Name"].ToString();
                data.coins = int.Parse(documentDictionary["Coins"].ToString());
                UiManager.instance.UpdateCoins();
                data.level = int.Parse(documentDictionary["Level"].ToString());
                data.challengescompleted = int.Parse(documentDictionary["ChallengesCompleted"].ToString());
                data.league = documentDictionary["League"].ToString();
                data.ranking = int.Parse(documentDictionary["Ranking"].ToString());
                data.wins = int.Parse(documentDictionary["Wins"].ToString());
                //data.losses = int.Parse(documentDictionary["losses"].ToString());
                //data.foldFreq = int.Parse(documentDictionary["FoldFreq"].ToString());
                //data.raiseFreq = int.Parse(documentDictionary["RaiseFreq"].ToString());
                //data.games = int.Parse(documentDictionary["Games"].ToString());
                List<object> list = documentDictionary["Friends"] as List<object>;
                data.friends = new List<string>();
                foreach (object friend in list)
                {
                    data.friends.Add(friend.ToString());
                }
               
            }
            else
            {
                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "ChallengesCompleted", data.challengescompleted },
                    { "Coins", data.coins },
                    { "Email",  data.email },
                    { "Name", data.Name },
                    { "Friends", data.friends },
                    { "League", data.league },
                    { "Level", data.level },
                    { "Ranking", data.ranking },
                    { "Wins", data.wins },
                    { "losses", data.losses },
                    { "RaiseFreq", data.raiseFreq },
                    { "FoldFreq", data.foldFreq },
                    { "Games", data.games },
                };
                docRef.SetAsync(user).ContinueWithOnMainThread(task => {
                    Debug.Log("Added data to the Players document in the users collection.");
                });
            }
            
        });
      
    }
    public void StorePlayerData(PlayerData data)
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("Players").Document(data.email);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;

            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "ChallengesCompleted", data.challengescompleted },
                { "Coins", data.coins },
                { "Email",  data.email },
                { "Friends", data.friends },
                { "League", data.league },
                { "Level", data.level },
                { "Name", data.Name },
                { "Ranking", data.ranking },
                { "Wins", data.wins },
                { "losses", data.wins },
                { "RaiseFreq", data.raiseFreq },
                { "FoldFreq", data.foldFreq },
                { "Games", data.games },
            };
            docRef.SetAsync(user).ContinueWithOnMainThread(task => {
                Debug.Log("Added data to the Players document in the users collection.");
            });
            
        });

    }
    public void StoreData(string collection,string Docid,Dictionary<string,object> data)
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection(collection).Document(Docid);
        docRef.UpdateAsync(data).ContinueWithOnMainThread(task => {
            Debug.Log("Added data to the Players document in the users collection.");
        });
    }
    public bool CheckUserExists(PlayerData data)
    {
        Debug.Log("A");
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("Players").Document(data.email);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            Dictionary<string, object> documentDictionary = snapshot.ToDictionary();
            if (snapshot.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        });
        return false;
    }
    public PlayerData GetPlayerData(PlayerData data)
    {
        Debug.Log("1");
        db = FirebaseFirestore.DefaultInstance;
        Debug.Log("2");
        DocumentReference playerref= db.Collection("Players").Document(data.email);
        playerref.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            Debug.Log("3");
            DocumentSnapshot document = task.Result;
            Dictionary<string, object> documentDictionary = document.ToDictionary();
            data.Name = documentDictionary["Name"].ToString();
            Debug.Log("4");
            data.coins = int.Parse(documentDictionary["Coins"].ToString());
            Debug.Log("5");
            data.level = int.Parse(documentDictionary["Level"].ToString());
            data.challengescompleted = int.Parse(documentDictionary["ChallengesCompleted"].ToString());
            data.league = documentDictionary["League"].ToString();
            data.ranking = int.Parse(documentDictionary["Ranking"].ToString());
            data.wins = int.Parse(documentDictionary["Wins"].ToString());
            data.losses = int.Parse(documentDictionary["losses"].ToString());
            List<object> list = documentDictionary["Friends"] as List<object>;
            data.friends = new List<string>();
            foreach (object friend in list)
            {
                data.friends.Add(friend.ToString());
            }


        });
        return data;
    }
    public Dictionary<string, object> GetData(string collection,string DocId )
    {
        DocumentReference playerref = db.Collection(collection).Document(DocId);
        Dictionary<string, object> data = null;
        playerref.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {

            DocumentSnapshot document = task.Result;
            Dictionary<string, object> data = document.ToDictionary();
      


        });
        return data;
    }

    public void setPlayercoins(PlayerData data)
    {
        DocumentReference docRef = db.Collection("Players").Document(data.email);
        Dictionary<string, object> user = new Dictionary<string, object>
        {
            { "Coins", data.coins },

        };
        docRef.UpdateAsync(user).ContinueWithOnMainThread(task => {
            Debug.Log("Added data to the Players document in the users collection.");
        });
    }
    public void getPlayerCoins(PlayerData data,int amount)
    {
        //infoText.text += "\n" + "Coins Before DB " + data.coins.ToString();
        int coins=PlayerData.Instance.coins;
        DocumentReference playerref = db.Collection("Players").Document(data.email);     
       // infoText.text += "\n" + "Amount Reward" + amount;
        playerref.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {

            DocumentSnapshot document = task.Result;
            Dictionary<string, object> documentDictionary = document.ToDictionary();

            data.coins= int.Parse(documentDictionary["Coins"].ToString());
           // infoText.text += "\n" + "Coins After DB" + data.coins;
            data.coins = PlayerData.Instance.coins + amount;
            data.coins = PlayerData.Instance.coins;
            Database.Instance.setPlayercoins(PlayerData.Instance);
            UiManager.instance.UpdateCoins();

        });
       
    }
}
