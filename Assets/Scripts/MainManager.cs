using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public GameObject IntroUI;
    public GameObject Opening;
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
    public GameObject ButtonInGameUI;
    public GameObject TheGameUI;
    public GameObject Transition;

    [SerializeField]
    GameObject _BlockObject;

    //AUDIO
    [SerializeField]
    private GameObject _GameplayBGM;

    // Use this for initialization
    private void Awake()
    {
        EventManager.AddListener<MainMenuButtonEvent>(MainMenuButton);
        EventManager.AddListener<LevelSelectButtonEvent>(LevelSelectButton);
        EventManager.AddListener<BlockSpamEvent>(BlockSpamHandler);
    }

    void Start () {
        IntroUI.SetActive(true);
        Opening.SetActive(true);
        InitFirstOpen();
	}

    void InitFirstOpen()
    {
        EventManager.TriggerEvent(new SFXPlayEvent(SfxType.LOGO_TULUS, false));
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
        _GameplayBGM.SetActive(false);
        Transition.SetActive(false);

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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                LevelSelect2.SetActive(false);
                LevelSelect3.SetActive(false);
                LevelSelect4.SetActive(false);
                LevelSelect5.SetActive(false);
                LevelSelect6.SetActive(false);
                LevelSelect1.SetActive(true);
                Transition.SetActive(false);

                EventManager.TriggerEvent(new InitButtonEvent());
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                _GameplayBGM.SetActive(false);
                Transition.SetActive(false);

                EventManager.TriggerEvent(new ControllerEvent(false));
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
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                StartCoroutine(FalseTutorial());

                _GameplayBGM.SetActive(true);

                Transition.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_2:
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

                _GameplayBGM.SetActive(true);

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

                _GameplayBGM.SetActive(true);

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
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                _GameplayBGM.SetActive(true);

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

                _GameplayBGM.SetActive(true);

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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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


                _GameplayBGM.SetActive(true);

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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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


                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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


                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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


                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                EventManager.TriggerEvent(new InitButtonEvent());
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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


                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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

                _GameplayBGM.SetActive(true);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
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
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                Transition.SetActive(false);
                break;
        }

    }

    void BlockSpamHandler(BlockSpamEvent e) {
            _BlockObject.SetActive(e.IsTrue);
    }

    IEnumerator FalseTutorial() {
        yield return new WaitForSeconds(3);
        TutorialUI.SetActive(false);
    }

}
