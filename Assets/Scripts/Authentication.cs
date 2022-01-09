using Firebase;
using Firebase.Auth;
using UnityEngine;


public class Authentication : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    bool isSignedIn;
    void Awake()
    {
        isSignedIn = false;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    auth = FirebaseAuth.DefaultInstance;
                    auth.StateChanged += AuthStateChanged;
                    AuthStateChanged(this, null);
                }
            }
        });
    }
    void start()
    {
        Debug.Log(PlayerData.Instance);
        Debug.Log(LoadingManager.Instance);
        Debug.Log(LoadingManager.Instance);
        Debug.Log(Database.Instance);
        Debug.Log(auth);
        
    }
    void Update()
    {
  
        if (auth == null)
        {
#if !UNITY_EDITOR
                            auth = FirebaseAuth.DefaultInstance;
                            auth.StateChanged += AuthStateChanged;
                            AuthStateChanged(this, null);
#endif
#if UNITY_EDITOR
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    if (task.Result == DependencyStatus.Available)
                    {
                        auth = FirebaseAuth.DefaultInstance;
                        auth.StateChanged += AuthStateChanged;
                        AuthStateChanged(this, null);
                    }
                }
            });
#endif
        }
        if (isSignedIn)
        {
            
            isSignedIn = false;          
            if (user.IsAnonymous)
            {
                PlayerData.Instance.email = user.UserId;
                LoadingManager.Instance.EnableInGameLogin();
            }
            else
            {
                LoadingManager.Instance.DisableInGameLogin();
                PlayerData.Instance.email = user.Email;
            }
            Database.Instance.CreateorGetPlayerData(PlayerData.Instance);
            Invoke("EnableAfterLogin", 4.5f);
        }
        
    }
    public void EnableAfterLogin()
    {
        LoadingManager.Instance.AfterLogin();
    }
    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            isSignedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!isSignedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }
}
