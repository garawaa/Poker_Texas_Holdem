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

public class Anonymous_SignIn : MonoBehaviour
{
    private FirebaseAuth auth;
    bool flag = false;
    // Start is called before the first frame update
    void Awake()
    {
        flag = true;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    auth = FirebaseAuth.DefaultInstance;
                }
            }
        });
        flag = false;
    }
    private void Start()
    {
        Debug.LogWarning(Database.Instance);    
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    auth = FirebaseAuth.DefaultInstance;
                }
            }
        });
    }
#if UNITY_EDITOR
    private void Update()
    {
        if(auth ==null && flag==false )
        {
            flag = true;
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    if (task.Result == DependencyStatus.Available)
                    {
                        auth = FirebaseAuth.DefaultInstance;
                    }
                }
            });
            flag = false;
        }
       
    }
#endif
    public void  SignIn_Anonymously()
    {
        PlayerPrefs.SetInt("AnonUser", 1);
        SignIn();
        PlayerPrefs.SetString("ID", PlayerData.Instance.email);
        EnableAfterLogin();
    }
    void SignIn()
    {
        #if !UNITY_EDITOR
        auth = FirebaseAuth.DefaultInstance;
        #endif
        auth.SignInAnonymouslyAsync().ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            PlayerData.Instance.email = newUser.UserId.ToString();
            if (Database.Instance.CheckUserExists(PlayerData.Instance))
            {
                Debug.Log("A");
                Database.Instance.GetPlayerData(PlayerData.Instance);
            }
            else
            {
                PlayerData.Instance.Name = "Guest";
                Database.Instance.CreateorGetPlayerData(PlayerData.Instance);
            }


        });
    }
    public void EnableAfterLogin()
    {
        LoadingManager.Instance.EnableInGameLogin();
        LoadingManager.Instance.AfterLogin();
    }
}
