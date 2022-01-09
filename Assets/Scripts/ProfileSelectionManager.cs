using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSelectionManager : MonoBehaviour
{
    public static ProfileSelectionManager instance;

    public InputField playerNameInputField;
    public int indexOfAvatarList;
    public int indexOfEclipseList;
    public Text playerNameText;

    public Image selectedAvatarImage;
    public Image selectedEclipseImage;

    public List<Button> avatarList;
    public List<GameObject> avatarHighlighter;
    public List<Button> eclipseList;
    public List<GameObject> eclipseHighlighter;

    public GameObject playerProfileAvatarImage;
    public GameObject playerProfileEclipseImage;

    private bool profCheckDone;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerProfAvatar();
        SetPlayerProfEclipse();

        if (instance == null)
        {
            instance = this;
        }
        DisableAllHighlighters(avatarHighlighter);
        profCheckDone = false;
        DisableAllHighlighters(eclipseHighlighter);
    }

    private void Update()
    {
        if (profCheckDone == false)
        {
            if (PlayerPrefs.GetInt("AvatarDone") == 1 || PlayerPrefs.GetInt("EclipseDone") == 1)
            {
                profCheckDone = true;
                PlayerPrefs.SetInt("ProfileOnceDone", 1);
                UiManager.instance.SetPlayerProf();
            }
        }
    }

    public void SetPlayerProfAvatar()
    {
        playerProfileAvatarImage.GetComponent<Image>().sprite = avatarList[PlayerPrefs.GetInt("AvatarIndex")].image.sprite;
        playerProfileAvatarImage.GetComponent<Image>().SetNativeSize();
    }
    public void SetPlayerProfEclipse()
    {
        playerProfileEclipseImage.GetComponent<Image>().sprite = eclipseList[PlayerPrefs.GetInt("EclipseIndex")].image.sprite;
        playerProfileEclipseImage.GetComponent<Image>().SetNativeSize();
    }

    public void DisableAllHighlighters(List<GameObject> go)
    {
        foreach (var item in go)
        {
            item.SetActive(false);
        }
    }

    public void SetAvatarIndex(int ind)
    {
        DisableAllHighlighters(avatarHighlighter);
        avatarHighlighter[ind].SetActive(true);
        indexOfAvatarList = ind;
        PlayerPrefs.SetInt("AvatarIndex", ind);
    }

    public void SetEclipseIndex(int ind)
    {
        DisableAllHighlighters(eclipseHighlighter);
        eclipseHighlighter[ind].SetActive(true);
        indexOfEclipseList = ind;
        PlayerPrefs.SetInt("EclipseIndex", ind);
    }

    public void SaveAvatar()
    {
        int ind = PlayerPrefs.GetInt("AvatarIndex");
        selectedAvatarImage.sprite = avatarList[ind].image.sprite;
        if (playerNameInputField.text == null || playerNameInputField.text == "")
        {
            playerNameInputField.text = PlayerData.Instance.Name;
        }
        PlayerData.Instance.Name = playerNameInputField.text;
        Database.Instance.StorePlayerData(PlayerData.Instance);
        PlayerPrefs.SetString("PlayerName", playerNameInputField.text);
        playerNameText.text = PlayerPrefs.GetString("PlayerName");
        DisableAllHighlighters(avatarHighlighter);
        SetPlayerProfAvatar();
        PlayerPrefs.SetInt("AvatarDone", 1);
        UiManager.instance.SetPlayerProf();
    }

    public void SaveEclipse()
    {
        int ind = PlayerPrefs.GetInt("EclipseIndex");
        selectedEclipseImage.sprite = eclipseList[ind].image.sprite;
        DisableAllHighlighters(eclipseHighlighter);
        SetPlayerProfEclipse();
        PlayerPrefs.SetInt("EclipseDone", 1);
        UiManager.instance.SetPlayerProf();
    }
}
