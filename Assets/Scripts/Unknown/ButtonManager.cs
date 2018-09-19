using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour {
    [SerializeField]
    GameObject _MainMenuPlayButton;
    [SerializeField]
    GameObject _TutorialButton;
    [SerializeField]
    GameObject _MainMenuExitButton;

    MainManager _MainManager;
    
    void Awake () {
        _MainManager = GetComponent<MainManager>();
        
        _MainMenuPlayButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new MainMenuButtonEvent(MainMenuButtonType.START_GAME));
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CLICK, false));
        });

        _TutorialButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new MainMenuButtonEvent(MainMenuButtonType.TUTORIAL));
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CLICK, false));
        });

        _MainMenuExitButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CANCEL, false));
            ExitButton();
        });
    }
    
    void StartGameButton() {

    }

    void ExitButton()
    {
        Application.Quit();
    }
}
