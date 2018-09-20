using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public GameObject IntroUI;
    public GameObject MainMenuUI;
    public GameObject LevelSelect;
    public GameObject FinishLevel;
    public GameObject PausedUI;
    public GameObject TutorialUI;
    public GameObject ButtonInGameUI;
    public GameObject TheGameUI;

    //AUDIO
    [SerializeField]
    private GameObject _GameplayBGM;

    // Use this for initialization
    private void Awake()
    {
        EventManager.AddListener<MainMenuButtonEvent>(MainMenuButton);
        EventManager.AddListener<LevelSelectButtonEvent>(LevelSelectButton);

    }

    void Start () {
        IntroUI.SetActive(true);
        InitFirstOpen();
	}

    void InitFirstOpen()
    {
        EventManager.TriggerEvent(new SFXPlayEvent(SfxType.LABIRIN, false));
        MainMenuUI.SetActive(true);
        LevelSelect.SetActive(false);
        FinishLevel.SetActive(false);
        PausedUI.SetActive(false);
        TutorialUI.SetActive(false);
        ButtonInGameUI.SetActive(false);
        TheGameUI.SetActive(false);
        _GameplayBGM.SetActive(false);

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

                LevelSelect.SetActive(true);
                //StartCoroutine(FalseTutorial());

                //_GameplayBGM.SetActive(true);

                //EventManager.TriggerEvent(new ControllerEvent(true));
                //EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case MainMenuButtonType.EXIT:

                break;
            case MainMenuButtonType.ON_FINISH:

                break;
            case MainMenuButtonType.TUTORIAL:

                break;
            case MainMenuButtonType.ON_RESTART:
                MainMenuUI.SetActive(true);
                LevelSelect.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);
                _GameplayBGM.SetActive(false);

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
                LevelSelect.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(true);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                StartCoroutine(FalseTutorial());

                _GameplayBGM.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_2:
                MainMenuUI.SetActive(false);
                LevelSelect.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                _GameplayBGM.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_3:
                MainMenuUI.SetActive(false);
                LevelSelect.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                _GameplayBGM.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_4:
                MainMenuUI.SetActive(false);
                LevelSelect.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                _GameplayBGM.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case LevelSelectButtonType.LEVEL_5:
                MainMenuUI.SetActive(false);
                LevelSelect.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                _GameplayBGM.SetActive(true);

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
        }

    }

    IEnumerator FalseTutorial() {
        yield return new WaitForSeconds(3);
        TutorialUI.SetActive(false);
    }

}
