/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//using GUIAnimator;
/* 
 * Daily Rewards Canvas is the User interface to show Daily rewards using Unity 4.6
 */
namespace com.niobiumstudios.dailyrewards
{
    public class DailyRewardsInterface : MonoBehaviour
    {

        // Prefab containing the daily reward
        //public GameObject dailyRewardPrefab;
        public GameObject[] dailyRewardsPrefabs;
        public GameObject dailyRewardsPanel,doubleRewardBtn;
        // Rewards panel
        public GameObject panelReward;
        public Text txtReward;
        public TMP_Text infoText;
        // Claim Button
        public Button btnClaim;

        // How long until next claim
        public Text txtTimeDue, DailyRewardBtnText;

        // The Grid that contains the rewards
     //   public GridLayoutGroup dailyRewardsGroup;

        void Start ()
        {
            DailyRewards.instance.CheckRewards();

            DailyRewards.instance.onClaimPrize += OnClaimPrize;
            DailyRewards.instance.onPrizeAlreadyClaimed += OnPrizeAlreadyClaimed;

            UpdateUI();
        }

        void OnDestroy()
        {
            DailyRewards.instance.onClaimPrize -= OnClaimPrize;
            DailyRewards.instance.onPrizeAlreadyClaimed -= OnPrizeAlreadyClaimed;
        }

        // Clicked the claim button
        public void OnClaimClick()
        {
            DailyRewards.instance.ClaimPrize(DailyRewards.instance.availableReward);
            Debug.Log(DailyRewards.instance.availableReward);

            UpdateUI();
        }

        public void UpdateUI()
        {
            //   foreach (Transform child in dailyRewardsGroup.transform)
            //   {
            ////       Destroy(child.gameObject);
            //   }
           
            bool isRewardAvailableNow = false;

            for (int i = 0; i < DailyRewards.instance.rewards.Count; i++)
            {
                int reward = DailyRewards.instance.rewards[i];
                int day = i + 1;

                GameObject dailyRewardGo = dailyRewardsPrefabs[i]/*.GetComponent<GUIAnim>().enabled=true*/; // GameObject.Instantiate(dailyRewardPrefab) as GameObject;

                DailyRewardUI dailyReward = dailyRewardGo.GetComponent<DailyRewardUI>();


                dailyReward.day = day;


                dailyReward.isAvailable = day == DailyRewards.instance.availableReward;
                dailyReward.isClaimed = day <= DailyRewards.instance.lastReward;

                if (dailyReward.isAvailable)
                {
                    isRewardAvailableNow = true;
                    Invoke("showDailyRewardsPanel", 1f);
                   // dailyRewardsPanel.SetActive(true);
                }

                //print("Last Reward: " + DailyRewards.instance.lastReward);
                if (i == DailyRewards.instance.lastReward)
                {
                    //dailyReward.GetComponent<GUIAnim>().enabled = true;
                    dailyReward.transform.GetChild(0).gameObject.SetActive(true);
                    //dailyReward.greenImg.SetActive(false);
                    //dailyReward.stamp.SetActive(false);
                    //dailyReward.blueImg.SetActive(false);
                    //dailyReward.redImg.SetActive(true);
                    //dailyReward.shinner.SetActive(true);
                }


                btnClaim.gameObject.SetActive(isRewardAvailableNow);
                //txtTimeDue.gameObject.SetActive(!isRewardAvailableNow);

                dailyReward.Refresh();
            }

        }
        void showDailyRewardsPanel()
        {
            dailyRewardsPanel.SetActive(true);
        }
        void Update()
        {
            if (txtTimeDue.IsActive())
            {
                TimeSpan difference = (DailyRewards.instance.lastRewardTime - DailyRewards.instance.timer).Add(new TimeSpan(0, 24, 0, 0));
                
                // Is the counter below 0? There is a new reward then
                if (difference.TotalSeconds <= 0)
                {
                    txtTimeDue.text = "00:00:00";
                    DailyRewardBtnText.text = "00:00:00";
                    DailyRewards.instance.CheckRewards();
                    UpdateUI();
                    return;
                }
                string formattedTs = string.Format("{0:D2}:{1:D2}:{2:D2}", difference.Hours, difference.Minutes, difference.Seconds);

                txtTimeDue.text = /*"Return in " +*/ formattedTs /*+ " to claim your reward"*/;

            }
            if (DailyRewardBtnText.IsActive())
            {
                TimeSpan difference = (DailyRewards.instance.lastRewardTime - DailyRewards.instance.timer).Add(new TimeSpan(0, 24, 0, 0));
               
                // Is the counter below 0? There is a new reward then
                if (difference.TotalSeconds <= 0)
                {
                    DailyRewardBtnText.text = "00:00:00";
                    //DailyRewardBtnText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", difference.Hours, difference.Minutes, difference.Seconds);
                    //DailyRewards.instance.CheckRewards();
                    //UpdateUI();
                    return;
                }
                DailyRewardBtnText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", difference.Hours, difference.Minutes, difference.Seconds);

            }
        }

        // Delegate
        private void OnClaimPrize(int day)
        {
            //infoText.text = day.ToString()+"P ";
            switch (day)
            {
                case 1:
                    if (MainMenuManager.instance)
                    {
                       // infoText.text += " asd ";
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);

                    }
                    doubleRewardBtn.SetActive(true);
                    //panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by 500 coins";
                    break;
                case 2:
                    if (MainMenuManager.instance)
                    {
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);
                       
                    }
                      
                    //doubleRewardBtn.SetActive(true);
                    panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by 100 Gems";
                    break;
                case 3:
                   
                    PlayerPrefs.SetInt("Player3", 1);
                    if (MainMenuManager.instance)
                    {
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);

                    }
                    //doubleRewardBtn.SetActive(false);
                    //panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by SpaceShip";
                    break;
                case 4:
                    if (MainMenuManager.instance)
                    {
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);

                    }
                    //doubleRewardBtn.SetActive(true);
                    //panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by 250 Gems";
                    break;
                case 5:
                    if (MainMenuManager.instance)
                    {
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);

                    }

                    //panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by 1000 coins and 500 gems";
                    break;
                case 6:
                    if (MainMenuManager.instance)
                    {
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);

                    }
                    PlayerPrefs.SetInt("Player4", 1);
                    //panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by Red Car Textures";
                 
                    //PlayerPrefs.SetInt("UnlockPlayer" + 6, 1);
                    break;
                case 7:
                    if (MainMenuManager.instance)
                    {
                        MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[day - 1]);

                    }

                    //panelReward.GetComponentInChildren<Text>().text = "You are Rewarded by 1000 Gems and 5000 Coins";
                    break;
                //default:
                //    txtReward.text = DailyRewards.instance.rewards[day - 1] + " Stars Rewarded";
                //    doubleRewardBtn.SetActive(true);
                    //if (MainMenuManager.instance)
                    //    MainMenuManager.instance.RewardStars(DailyRewards.instance.rewards[day - 1]);
                    //break;
            }
            panelReward.SetActive(true);
            //dailyRewardsPrefabs[day - 1].GetComponent<GUIAnim>().enabled = false;
            dailyRewardsPrefabs[day - 1].transform.GetChild(0).gameObject.SetActive(false);

            PlayerPrefs.SetInt("Day", day);
        }

        // Delegate
        private void OnPrizeAlreadyClaimed(int day)
        {
            // Do Something with the prize already claimed
        }

        // Close the Rewards panel
        public void OnCloseRewardsClick()
        {
            panelReward.SetActive(false);
        }

        // Resets player preferences
        public void OnResetClick()
        {
            DailyRewards.instance.Reset();
            DailyRewards.instance.lastRewardTime = System.DateTime.MinValue;
            DailyRewards.instance.CheckRewards();

            UpdateUI();
        }

        // Simulates the next day
        public void OnAdvanceDayClick()
        {
            DailyRewards.instance.timer = DailyRewards.instance.timer.AddDays(1);
            DailyRewards.instance.CheckRewards();
            UpdateUI();
        }

        // Simulates the next hour
        public void OnAdvanceHourClick()
        {
            DailyRewards.instance.timer = DailyRewards.instance.timer.AddHours(1);
            DailyRewards.instance.CheckRewards();
            UpdateUI();
        }
        public void DoubleRewardOnClick()
        {
            //if (ConsoliAds.Instance)
            //{
            //    if (ConsoliAds.Instance.IsRewardedVideoAvailable(0))
            //    {
            //        ConsoliAds.Instance.ShowRewardedVideo(0);
            //        ConsoliAds.onRewardedVideoAdCompletedEvent += () => MainMenuManager.instance.RewardCoins(DailyRewards.instance.rewards[PlayerPrefs.GetInt("Day", 1) - 1]);
            //    }
            //}

        }

    }
}