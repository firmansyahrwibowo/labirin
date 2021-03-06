﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

public class PlayGamesManager : MonoBehaviour {
    public string UserName;

    private void Awake()
    {
        EventManager.AddListener<LeaderboardAddEvent>(LeaderboardAddHandler);
        EventManager.AddListener<AchievementAddEvent>(UnlockAchievement);
        EventManager.AddListener<ShowLeaderboardEvent>(ShowLeaderboardUI);
        EventManager.AddListener<ShowAchievementEvent>(ShowAchievementUI);
    }
    // Use this for initialization
    void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
    }


    void SignIn() {
        Social.localUser.Authenticate(sucess => {
            UnlockAchievement(new AchievementAddEvent(1));
            UserName = Social.localUser.userName;
        });
    }

    // Update is called once per frame
    #region Achievements
    public void UnlockAchievement(AchievementAddEvent e)
    {
        switch (e.Id) {
            case 1:
                Social.ReportProgress(GPGSIds.achievement_tulus_labirin, 100, (bool sucess) => { });
                break;
            case 2:
                Social.ReportProgress(GPGSIds.achievement_selamat_bermain, 100, (bool sucess) => { });
                break;
        }
    }
    public void IncrementAchievement(string id, int stepIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepIncrement, sucess => { });
    }

    public void ShowAchievementUI(ShowAchievementEvent e) {
        Social.ShowAchievementsUI();
    }
    #endregion

    #region Leaderboard
    public void LeaderboardAddHandler(LeaderboardAddEvent e) {
        long score = Convert.ToInt64(e.Score);
        switch (e.Type)
        {
            case LeaderboardType.GENERAL:
                Debug.Log("GLOBAL : " + e.Score);
                Social.ReportScore(score, GPGSIds.leaderboard_peringkat, (bool sucess) =>
                {

                });
                break;
            case LeaderboardType.CHALLENGE_1:
                Debug.Log("CHALLENGE : " + e.Score);
                Social.ReportScore(score, GPGSIds.leaderboard_tantangan_1, (bool sucess) =>
                {

                });
                break;
            case LeaderboardType.CHALLENGE_2:
                Debug.Log("GLOBAL : " + e.Score);
                Social.ReportScore(score, GPGSIds.leaderboard_tantangan_2, (bool sucess) =>
                {

                });
                break;
            case LeaderboardType.CHALLENGE_3:
                Debug.Log("GLOBAL : " + e.Score);
                Social.ReportScore(score, GPGSIds.leaderboard_tantangan_3, (bool sucess) =>
                {

                });
                break;
            case LeaderboardType.CHALLENGE_4:
                break;
        }
    }

    public void ShowLeaderboardUI(ShowLeaderboardEvent e) {
        Social.ShowLeaderboardUI();
    }
    #endregion
}
