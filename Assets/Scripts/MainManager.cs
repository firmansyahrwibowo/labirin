using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public GameObject IntroUI;
    public GameObject MainMenuUI;
    public GameObject FinishLevel;
    public GameObject PausedUI;
    public GameObject TutorialUI;
    public GameObject ButtonInGameUI;
    public GameObject TheGameUI;

    // Use this for initialization
    private void Awake()
    {
        EventManager.AddListener<MainMenuButtonEvent>(MainMenuButton);
    }

    void Start () {
        IntroUI.SetActive(true);
        InitFirstOpen();
	}

    void InitFirstOpen() {
        MainMenuUI.SetActive(true);
        FinishLevel.SetActive(false);
        PausedUI.SetActive(false);
        TutorialUI.SetActive(false);
        ButtonInGameUI.SetActive(false);
        TheGameUI.SetActive(false);

        EventManager.TriggerEvent(new ControllerEvent(false));
    }

    public void MainMenuButton (MainMenuButtonEvent e) {
        switch (e.Type)
        {
            case MainMenuButtonType.START_GAME:
                MainMenuUI.SetActive(false);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(true);
                ButtonInGameUI.SetActive(true);
                TheGameUI.SetActive(true);

                StartCoroutine(FalseTutorial());

                EventManager.TriggerEvent(new ControllerEvent(true));
                EventManager.TriggerEvent(new StartGameplayEvent());
                break;
            case MainMenuButtonType.EXIT:

                break;
            case MainMenuButtonType.ON_FINISH:

                break;
            case MainMenuButtonType.TUTORIAL:

                break;
            case MainMenuButtonType.ON_RESTART:
                MainMenuUI.SetActive(true);
                FinishLevel.SetActive(false);
                PausedUI.SetActive(false);
                TutorialUI.SetActive(false);
                ButtonInGameUI.SetActive(false);
                TheGameUI.SetActive(false);

                EventManager.TriggerEvent(new ControllerEvent(false));
                break;
        }
    }

    IEnumerator FalseTutorial() {
        yield return new WaitForSeconds(3);
        TutorialUI.SetActive(false);
    }

}
