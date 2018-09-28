using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesManager : MonoBehaviour {

    private void Awake()
    {
        EventManager.AddListener<LeaderboardAddEvent>(LeaderboardAddHandler);
        EventManager.AddListener<ShowLeaderboardEvent>(ShowLeaderboardUI);
    }
    // Use this for initialization
    void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
	}


    void SignIn() {
        Social.localUser.Authenticate(sucess => { });
    }
    // Update is called once per frame
    #region Achievements
    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, sucess => { });
    }
    public void IncrementAchievement(string id, int stepIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepIncrement, sucess => { });
    }

    public void ShowAchievementUI() {
        Social.ShowAchievementsUI();
    }
    #endregion

    #region Leaderboard
    public void LeaderboardAddHandler(LeaderboardAddEvent e) {
        AddScoreToLeaderboard("CgkI9Y_BxagCEAIQAA", e.Score);
    }
    public void AddScoreToLeaderboard(string leaderboardId, int score) {
        Social.ReportScore(score, leaderboardId, sucess => { });
    }

    public void ShowLeaderboardUI(ShowLeaderboardEvent e) {
        Social.ShowLeaderboardUI();
    }
    #endregion
}
