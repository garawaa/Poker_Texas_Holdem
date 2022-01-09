/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using UnityEngine.UI;
//using GUIAnimator;
/* 
 * Daily Reward Object UI representation
 */
namespace com.niobiumstudios.dailyrewards
{
    public class DailyRewardUI : MonoBehaviour
    {
        //public Text txtDay;
        //public Text txtReward;
        //public Image imgBackground;
        public GameObject claimedSprit;
        public int day;
        public int reward;
        public bool isClaimed;
        public bool isAvailable;

        //public Color availableColor;
        //public Color claimedColor;

        //public GameObject stamp,blueImg, greenImg, redImg, shinner;
        public bool isNextDay;

        public void Refresh()
        {
            //Debug.Log("refresh_");
            //Saad   txtDay.text = "Day " + day.ToString();
            /* txtDay.text = day.ToString();*/ //Saad
                                               //txtReward.text = reward.ToString();

            if (isAvailable)
            {
                //GetComponent<GUIAnim>().enabled = true;
                // imgBackground.color = availableColor;
                //greenImg.SetActive(false);
                //stamp.SetActive(false);
                //blueImg.SetActive(false);
                //redImg.SetActive(true);
                //shinner.SetActive(true);
            }

            if (isClaimed)
            {
                claimedSprit.SetActive(true);
                //imgBackground.color = claimedColor;
                // blueImg.SetActive(false);
                // redImg.SetActive(false);
                // shinner.SetActive(false);
                // greenImg.SetActive(true);
                // stamp.SetActive(true);

            }

        }
    }
}