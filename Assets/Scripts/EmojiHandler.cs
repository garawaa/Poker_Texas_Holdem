using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiHandler : MonoBehaviour
{
    public Button[] emojiContainer;
    public GameObject spritePop;

    public void PopEmoji(int index)
    {
        spritePop.SetActive(true);
        spritePop.GetComponent<Image>().sprite = emojiContainer[index].GetComponent<Image>().sprite;
        spritePop.GetComponent<Image>().SetNativeSize();
        Invoke("DisablePopUp", 1.5f);
    }

    public void DisablePopUp()
    {
        spritePop.SetActive(false);
    }
}
