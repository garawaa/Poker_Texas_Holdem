using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Google;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Google_SignIn : MonoBehaviour
{
    public TMP_Text infoText;
    public string webClientId = "<your client id here>";

    private FirebaseAuth auth;
    private GoogleSignInConfiguration configuration;
    public List<GameObject> dailyrewards;
    private void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = webClientId,
            RequestIdToken = true,
            RequestEmail = true
        };
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

    public void SignInWithGoogle() {

        OnSignIn(); 
    }
    public void SignOutFromGoogle() { OnSignOut(); }

    private void OnSignIn()
    {

        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        GoogleSignIn.Configuration.RequestEmail = true;
        infoText.text = "RUN1 ";
        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
            OnAuthenticationFinished);
    }

    private void OnSignOut()
    {
        //AddToInformation("Calling SignOut");
        GoogleSignIn.DefaultInstance.SignOut();
    }

    public void OnDisconnect()
    {
       // AddToInformation("Calling Disconnect");
        GoogleSignIn.DefaultInstance.Disconnect();
    }

    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            infoText.text += " RUN2 ";
            using (IEnumerator<Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
                   
                }
                else
                {
           
                }
            }
        }
        else if (task.IsCanceled)
        {
            infoText.text += " RUN3 ";
            Debug.Log("taskIsCanceled");
        }
        else
        {
            infoText.text = "RUN4 ";
            PlayerData.Instance.email = task.Result.Email;
            infoText.text = PlayerData.Instance.email;
            PlayerData.Instance.Name= task.Result.DisplayName;
            SignInWithGoogleOnFirebase(task.Result.IdToken);
        }
    }

    private void SignInWithGoogleOnFirebase(string idToken)
    {
        infoText.text += "\n" + " RUN5";
        auth = FirebaseAuth.DefaultInstance;
        Credential credential = GoogleAuthProvider.GetCredential(idToken, null);
        // foreach (var item in dailyrewards)
        // {
        //    item.SetActive(true);
        // }
        infoText.text += " RUN6";
        try
        {
            infoText.text = "\n" + "RUN7 ";
            auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
            {
                infoText.text = " RUN8";
                Exception ex = task.Exception;
                if (ex != null)
                {
                    infoText.text = "\n" + ex.ToString();
                    Debug.Log(ex);
                }
                else
                {
                    infoText.text = "\n" + "RUN9";
                    if (PlayerPrefs.GetInt("AnonUser",0) == 1)
                    {
                        infoText.text += " RUNANN";
                        string email = PlayerData.Instance.email;
                        string name = PlayerData.Instance.Name;
                        PlayerData.Instance.email = PlayerPrefs.GetString("ID");
                        Database.Instance.GetPlayerData(PlayerData.Instance);
                        PlayerData.Instance.email = email;
                        PlayerData.Instance.Name = name;
                        Database.Instance.StorePlayerData(PlayerData.Instance);
                    }
                    else
                    {

                        if (Database.Instance.CheckUserExists(PlayerData.Instance))
                        {

                            Database.Instance.GetPlayerData(PlayerData.Instance);
                        }
                        else
                        {

                            Database.Instance.CreateorGetPlayerData(PlayerData.Instance);
                        }

                    }
                    //Invoke("EnableDailyRewards", 1f);
                    Invoke("EnableAfterLogin", 0.25f);
                    Debug.Log("Logged In");
                }
            });

        }
        catch (Exception ex)
        {
            //Debug.Log(ex.ToString());
        }

    }
    void EnableDailyRewards()
    {
        if (dailyrewards != null)
        {
            foreach (var item in dailyrewards)
            {
                item.SetActive(true);
            }
        }
    }

    public void EnableAfterLogin()
    {
        LoadingManager.Instance.DisableInGameLogin();
        LoadingManager.Instance.AfterLogin();
    }
    public void OnSignInSilently()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;

        GoogleSignIn.DefaultInstance.SignInSilently().ContinueWith(OnAuthenticationFinished);
    }

    public void OnGamesSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = true;
        GoogleSignIn.Configuration.RequestIdToken = false;
        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }
    private void OnApplicationQuit()
    {
        //SignOutFromGoogle();
    }
    //private void AddToInformation(string str) { infoText.text += "\n" + str; }
}
