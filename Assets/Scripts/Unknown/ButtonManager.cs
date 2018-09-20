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

    [Header("LEVEL BUTTON")]
    [SerializeField]
    GameObject _Level1Button;
    [SerializeField]
    GameObject _Level2Button;
    [SerializeField]
    GameObject _Level3Button;
    [SerializeField]
    GameObject _Level4Button;
    [SerializeField]
    GameObject _Level5Button;
    [SerializeField]
    GameObject _BackToMenuButton;

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

        //Level Select Handler
        _Level1Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 0;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_1));
        });
        _Level2Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 1;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_2));
        });
        _Level3Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 2;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_3));
        });
        _Level4Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 3;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_4));
        });
        _Level5Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 4;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_5));
        });


    }

    void StartGameButton() {

    }

    void ExitButton()
    {
        Application.Quit();
    }
}
