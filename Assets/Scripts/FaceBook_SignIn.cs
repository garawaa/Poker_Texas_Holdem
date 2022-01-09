using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Google;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using TMPro;


public class FaceBook_SignIn : MonoBehaviour
{
    private FirebaseAuth auth;
    public List<GameObject> dailyrewards;

    private void Awake()
    {
       
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
        CheckFirebaseDependencies();

    }
    private void CheckFirebaseDependencies()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                    auth = FirebaseAuth.DefaultInstance;
                else
                    Debug.Log("Error");
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }
    #region Login / Logout
    public void FacebookLogin()
    {
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email" }, AuthCallBack);
    }
    public void FacebookLogout()
    {
        FB.LogOut();
    }
    // Start is called before the first frame update
    void AuthCallBack(ILoginResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("Facebook is Login!");
                auth = FirebaseAuth.DefaultInstance;
                Credential credential = FacebookAuthProvider.GetCredential(AccessToken.CurrentAccessToken.TokenString);
                FetchFBProfile();
                //foreach (var item in dailyrewards)
                //{
                //    item.SetActive(true);
                //}
             
                try
                {
                    auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
                    {
                        Exception ex = task.Exception;
                        if (ex != null)
                        {
                           
                            Debug.Log(ex);
                        }
                        else
                        {
                           // Invoke("EnableDailyRewards", 1f);
                            Invoke("EnableAfterLogin", 1f);
                            Debug.Log("Logged In");
                        }
                    });

                }
                catch(Exception ex)
                {
                    //Debug.Log(ex.ToString());
                }
            }
            else
            {
                Debug.Log("Facebook is not Logged in!");
            }
        }
    }
    void EnableDailyRewards()
    {
        foreach (var item in dailyrewards)
        {
            item.SetActive(true);
        }
    }

    public void EnableAfterLogin()
    {
        LoadingManager.Instance.DisableInGameLogin();
        LoadingManager.Instance.AfterLogin();
    }

    private void FetchFBProfile()
    {
      
        FB.API("/me?fields=email,name", HttpMethod.GET, FetchProfileCallback, new Dictionary<string, string>() { });
      
    }

    private void FetchProfileCallback(IGraphResult result)
    {

        Dictionary<string, object> FBUserDetails = (Dictionary<string, object>)result.ResultDictionary;
        if (PlayerPrefs.GetInt("AnonUser", 0) == 1)
        {
            Debug.LogError(2);
            string email = PlayerData.Instance.email;
            PlayerData.Instance.email = PlayerPrefs.GetString("ID");
            Database.Instance.GetPlayerData(PlayerData.Instance);
            PlayerData.Instance.email = FBUserDetails["email"].ToString();
            PlayerData.Instance.Name = FBUserDetails["name"].ToString();
            Database.Instance.StorePlayerData(PlayerData.Instance);
        }
        else
        {
            PlayerData.Instance.email = FBUserDetails["email"].ToString();
            PlayerData.Instance.Name = FBUserDetails["name"].ToString();
            Database.Instance.CreateorGetPlayerData(PlayerData.Instance);
            
        }
        Debug.Log(result.RawResult);

    }
    private void OnApplicationQuit()
    {
        //FacebookLogout();
    }
    #endregion


}