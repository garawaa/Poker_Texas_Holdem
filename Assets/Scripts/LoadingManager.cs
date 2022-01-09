using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadingManager : MonoBehaviour
{
    static LoadingManager instance;
    public static bool isAnonymousLogin;

    public GameObject container;
    public GameObject royally;
    public GameObject loadingObj;
    public Text loadingText;

    [HideInInspector]
    public AsyncOperation asyncLevelLoad;
    private bool callOnce;
    public static LoadingManager Instance
    {
        get
        {
            if (LoadingManager.instance == null)
            {
                LoadingManager.instance = FindObjectOfType<LoadingManager>();
            }
            return LoadingManager.instance;
        }
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        callOnce = true;
        Invoke("EnableEverything", 5);
        isAnonymousLogin = false;
    }

    private void Update()
    {
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

    public void EnableEverything()
    {
        royally.SetActive(false);
        container.SetActive(true);
    }

    public void AfterLogin()
    {
        StartCoroutine(Loading("MainMenu"));
    }

    IEnumerator Loading(string LevelName)
    {
        loadingObj.gameObject.SetActive(true);
        asyncLevelLoad = SceneManager.LoadSceneAsync(LevelName);
        yield return asyncLevelLoad;
    }

    public void EnableInGameLogin()
    {
        isAnonymousLogin = true;
        PlayerPrefs.SetInt("DisableInGameLogin", 1);
    }

    public void DisableInGameLogin()
    {
        isAnonymousLogin = false;
        PlayerPrefs.SetInt("DisableInGameLogin", 0);
    }
}
