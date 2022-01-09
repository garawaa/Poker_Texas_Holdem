/***************************************************************************\
Project:      Daily Rewards
Copyright (c) Niobium Studios.
Author:       Guilherme Nunes Barbosa (gnunesb@gmail.com)
\***************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

/* 
 * Timed Rewards Canvas is the User interface to show Timed rewards
 */
namespace com.niobiumstudios.dailyrewards
{
    public class TimedRewards : MonoBehaviour
    {
        public DateTime lastRewardTime;     // The last time the user clicked in a reward
        public TimeSpan timer;
        public float maxTime = 3600f; // How many seconds until the player can claim the reward

        // Delegates
        public delegate void OnCanClaim();
        public OnCanClaim onCanClaim;

        private bool canClaim;              // Checks if the user can claim the reward

        // Needed Constants
        private const string TIMED_REWARDS_TIME = "TimedRewardsTime";
        private const string FMT = "O";

        // Singleton
        private static TimedRewards _instance;
        public static TimedRewards instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TimedRewards>();
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        _instance = obj.AddComponent<TimedRewards>();
                    }
                }

                return _instance;
            }
        }

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            if (_instance == null)
            {
                _instance = this as TimedRewards;
            }
            else
            {
                Destroy(gameObject);
            }

            InitializeTimer();
        }

        // Initializes the timer in case the user already have a player preference
        private void InitializeTimer()
        {
            string lastRewardTimeStr = PlayerPrefs.GetString(TIMED_REWARDS_TIME);

            if (!string.IsNullOrEmpty(lastRewardTimeStr))
            {
                lastRewardTime = DateTime.ParseExact(lastRewardTimeStr, FMT, CultureInfo.InvariantCulture);

                timer = (lastRewardTime - DateTime.Now).Add(TimeSpan.FromSeconds(maxTime));
            }
            else
            {
                timer = TimeSpan.FromSeconds(maxTime);
            }
        }

        void Update()
        {
            if (!canClaim)
            {
                timer = timer.Subtract(TimeSpan.FromSeconds(Time.deltaTime));

                if (timer.TotalSeconds <= 0)
                {
                    canClaim = true;

                    if (onCanClaim != null)
                    {
                        onCanClaim();
                    }
                }
                else
                {
                    // I need to save the player time every tick. If the player exits the game the information keeps logged
                    // For perfomance issues you can save this information when the player switches scenes or quits the application
                    PlayerPrefs.SetString(TIMED_REWARDS_TIME, DateTime.Now.Add(timer - TimeSpan.FromSeconds(maxTime)).ToString(FMT));
                }
            }
        }

        // The player claimed the prize. We need to reset to restart the timer
        public void Claim()
        {
            PlayerPrefs.SetString(TIMED_REWARDS_TIME, DateTime.Now.ToString(FMT));
            timer = TimeSpan.FromSeconds(maxTime);

            canClaim = false;
        }

        // Resets the Timed Rewards. For debug purposes
        public void Reset()
        {
            PlayerPrefs.DeleteKey(TIMED_REWARDS_TIME);
            canClaim = false;
            timer = TimeSpan.FromSeconds(maxTime);
        }
    }
}