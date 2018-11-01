﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    //public GameObject IntroUI;
    public GameObject MainMenuUI;
    public GameObject LevelSelect1;
    public GameObject LevelSelect2;
    public GameObject LevelSelect3;
    public GameObject LevelSelect4;
    public GameObject LevelSelect5;
    public GameObject LevelSelect6;
    public GameObject FinishLevel;
    public GameObject PausedUI;
    public GameObject TutorialUI;
    public GameObject Tutorial1UI;
    public GameObject Tutorial2UI;
    public GameObject ButtonInGameUI;
    public GameObject TheGameUI;
    public GameObject Transition;
    public GameObject TiltController;
    public GameObject IntroUI;
    public PlayGamesManager Gpgs;
    public GameObject Ball;
    public GameObject BallChallenge;
    public GameObject Goal;
    public GameObject GoalChallenge;
    public GameObject WinUI;
    public GameObject WinUIChallenge;
    [SerializeField]
    GameObject _BlockObject;
    [SerializeField]
    GameObject _Challenge2;


    // Use this for initialization
    private void Awake()
    {
        EventManager.AddListener<MainMenuButtonEvent>(MainMenuButton);
        EventManager.AddListener<LevelSelectButtonEvent>(LevelSelectButton);
        EventManager.AddListener<BlockSpamEvent>(BlockSpamHandler);


        TutorialUI.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
            FalseTutorial();
        });

        Tutorial1UI.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
            FalseTutorial1();
        });

        Tutorial2UI.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
            FalseTutorial2();
        });

    }

    void Start () {
        IntroUI.SetActive(true);
        InitFirstOpen();
	}

    void InitFirstOpen()
    {
        MainMenuUI.SetActive(true);
        LevelSelect1.SetActive(false);
        LevelSelect2.SetActive(false);
        LevelSelect3.SetActive(false);
        LevelSelect4.SetActive(false);
        LevelSelect5.SetActive(false);
        LevelSelect6.SetActive(false);
        FinishLevel.SetActive(false);
        PausedUI.SetActive(false);
        TutorialUI.SetActive(false);
        ButtonInGameUI.SetActive(false);
        TheGameUI.SetActive(false);

        Ball.SetActive(false);
        Goal.SetActive(false);
        BallChallenge.SetActive(false);
        GoalChallenge.SetActive(false);

        Transition.SetActive(false);
        EventManager.TriggerEvent(new BGMEvent(PlayType.STOP));
        EventManager.TriggerEvent(new BGMEvent(PlayType.MAIN_BGM));
        EventManager.TriggerEvent(new ControllerEvent(false));
    }

    public void MainMenuButton (MainMenuButtonEvent e) {
        switch (e.Type)
        {
            case MainMenuButtonType.START_GAME:
                MainMenuUI.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                LevelSelect1.SetActive(true);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("Start Button");

                EventManager.TriggerEvent(new BGMEvent(PlayType.STOP));
                EventManager.TriggerEvent(new InitButtonEvent());

                AnalyticsEvent.Custom("User Data", new Dictionary<string, object>
                {
                { "user_name", Gpgs.UserName },
                { "play_count", +1 }
                });

                break;
            case MainMenuButtonType.ON_RESTART:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.STOP));
                EventManager.TriggerEvent(new ControllerEvent(false));
                break;
            case MainMenuButtonType.CHALLENGE_2:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TiltController.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(false);
                Goal.SetActive(false);
                BallChallenge.SetActive(true);
                GoalChallenge.SetActive(true);

                AnalyticsEvent.Custom("Challenge Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartChallengeEvent());
                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));
                break;
        }
    }

    public void LevelSelectButton(LevelSelectButtonEvent e)
    {
        switch (e.Type)
        {
            case LevelSelectButtonType.LEVEL_1:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(true);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                TiltController.SetActive(false);                
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                AnalyticsEvent.Custom("Level1 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));
                break;
            case LevelSelectButtonType.LEVEL_2:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(true);
                Tutorial2UI.SetActive(false);
                TiltController.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level2 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_3:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level3 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_4:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(true);
                TiltController.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level4 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_5:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level5 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.Back_ToMenu1:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("BackToMenu Button");

                EventManager.TriggerEvent(new BGMEvent(PlayType.STOP));
                EventManager.TriggerEvent(new InitButtonEvent());
                break;
            case LevelSelectButtonType.Left_1:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(true);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("LeftLevelSelect Button");

                break;
            case LevelSelectButtonType.Right_1:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(true);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                  TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("RightLevelSelect Button");

                break;


            case LevelSelectButtonType.LEVEL_6:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level6 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_7:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level7 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_8:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level8 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_9:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level9 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_10:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level10 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.Back_ToMenu2:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());

                AnalyticsEvent.Custom("BackToMenu Button");

                break;
            case LevelSelectButtonType.Left_2:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(true);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("LeftLevelSelect Button");

                break;
            case LevelSelectButtonType.Right_2:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(true);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("RightLevelSelect Button");

                break;


            case LevelSelectButtonType.LEVEL_11:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level11 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_12:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level12 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_13:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level13 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_14:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level14 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_15:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level15 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.Back_ToMenu3:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());

                AnalyticsEvent.Custom("BackToMenu Button");

                break;
            case LevelSelectButtonType.Left_3:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(true);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("LeftLevelSelect Button");

                break;
            case LevelSelectButtonType.Right_3:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(true);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("RightLevelSelect Button");

                break;


            case LevelSelectButtonType.LEVEL_16:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level16 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_17:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level17 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_18:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level18 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_19:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level19 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_20:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level20 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.Back_ToMenu4:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());

                AnalyticsEvent.Custom("BackToMenu Button");

                break;
            case LevelSelectButtonType.Left_4:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(true);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("LeftLevelSelect Button");

                break;
            case LevelSelectButtonType.Right_4:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(true);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("RightLevelSelect Button");

                break;


            case LevelSelectButtonType.LEVEL_21:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level21 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_22:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level22 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_23:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level23 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_24:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level24 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_25:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level25 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.Back_ToMenu5:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());

                AnalyticsEvent.Custom("BackToMenu Button");

                break;
            case LevelSelectButtonType.Left_5:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(true);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("LeftLevelSelect Button");

                break;
            case LevelSelectButtonType.Right_5:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(true);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("RightLevelSelect Button");

                break;


            case LevelSelectButtonType.LEVEL_26:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level26 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_27:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level27 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_28:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level28 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_29:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level29 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_30:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                Ball.SetActive(true);
                Goal.SetActive(true);
                BallChallenge.SetActive(false);
                GoalChallenge.SetActive(false);

                EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));

                AnalyticsEvent.Custom("Level30 Button");

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.Back_ToMenu6:
                MainMenuUI.SetActive(true);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("BackToMenu Button");

                break;
            case LevelSelectButtonType.Left_6:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(true);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("LeftLevelSelect Button");

                break;
            case LevelSelectButtonType.Right_6:
                MainMenuUI.SetActive(false);
                LevelSelect1.SetActive(true);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                Tutorial1UI.SetActive(false);
                Tutorial2UI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);

                AnalyticsEvent.Custom("RightLevelSelect Button");

                break;
        }

    }

    void BlockSpamHandler(BlockSpamEvent e) {
            _BlockObject.SetActive(e.IsTrue);
    }

    void FalseTutorial() {
        TutorialUI.SetActive(false);
        TiltController.SetActive(true);
    }

    void FalseTutorial1()
    {
        Tutorial1UI.SetActive(false);
        TiltController.SetActive(true);
    }
    void FalseTutorial2()
    {
        Tutorial2UI.SetActive(false);
        TiltController.SetActive(true);
    }

}
