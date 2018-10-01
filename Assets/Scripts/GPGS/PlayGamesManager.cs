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
            UnlockAchievement(1);
        });
    }
    // Update is called once per frame
    #region Achievements
    public void UnlockAchievement(int id)
    {
        switch (id) {
            case 1:
                Social.ReportProgress(GPGSIds.achievement_tulus_labirin, 100, (bool sucess) => { });
                break;
            case 2:
                Social.ReportProgress(GPGSIds.achievement_star_collect, 100, (bool sucess) => { });
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
        Debug.Log(e.Score);
        Social.ReportScore(e.Score, GPGSIds.leaderboard_leaderboard, (bool sucess) => {

        });
    }

    public void ShowLeaderboardUI(ShowLeaderboardEvent e) {
        Social.ShowLeaderboardUI();
    }
    #endregion
}
