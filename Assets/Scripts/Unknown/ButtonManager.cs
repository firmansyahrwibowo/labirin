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
    GameObject _BackToMenuButton1;
    [SerializeField]
    GameObject _Left1;
    [SerializeField]
    GameObject _Right1;

    [SerializeField]
    GameObject _Level6Button;
    [SerializeField]
    GameObject _Level7Button;
    [SerializeField]
    GameObject _Level8Button;
    [SerializeField]
    GameObject _Level9Button;
    [SerializeField]
    GameObject _Level10Button;
    [SerializeField]
    GameObject _BackToMenuButton2;
    [SerializeField]
    GameObject _Left2;
    [SerializeField]
    GameObject _Right2;

    [SerializeField]
    GameObject _Level11Button;
    [SerializeField]
    GameObject _Level12Button;
    [SerializeField]
    GameObject _Level13Button;
    [SerializeField]
    GameObject _Level14Button;
    [SerializeField]
    GameObject _Level15Button;
    [SerializeField]
    GameObject _BackToMenuButton3;
    [SerializeField]
    GameObject _Left3;
    [SerializeField]
    GameObject _Right3;


    [Header("LEVEL LOCK")]
    [SerializeField]
    GameObject[] _LevelLock;

    [Header("STAR COLLECTED")]
    [SerializeField]
    Text _StarRemaining1;
    [SerializeField]
    Text _StarRemaining2;
    [SerializeField]
    Text _StarRemaining3;

    [SerializeField]
    Text _StarTotal1;
    [SerializeField]
    Text _StarTotal2;
    [SerializeField]
    Text _StarTotal3;


    MainManager _MainManager;
    
    void Awake () {
        _MainManager = GetComponent<MainManager>();

        EventManager.AddListener<InitButtonEvent>(Init);

        //Main Menu Handler
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
        _BackToMenuButton1.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu1));
        });
        _Left1.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Left_1));
        });
        _Right1.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Right_1));
        });

        _Level6Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 5;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_6));
        });
        _Level7Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 6;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_7));
        });
        _Level8Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 7;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_8));
        });
        _Level9Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 8;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_9));
        });
        _Level10Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 9;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_10));
        });
        _BackToMenuButton2.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu2));
        });
        _Left2.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Left_2));
        });
        _Right2.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Right_2));
        });

        _Level11Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 10;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_11));
        });
        _Level12Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 11;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_12));
        });
        _Level13Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 12;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_13));
        });
        _Level14Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 13;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_14));
        });
        _Level15Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 14;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_15));
        });
        _BackToMenuButton3.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu3));
        });
        _Left3.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Left_3));
        });
        _Right3.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Right_3));
        });

    }

    public void Init (InitButtonEvent e)
    {
        //Level Lock Handler
        for (int i = 0; i <= _LevelLock.Length; i++)
        {
            if (i <= Global.Level)
            {
                if (Global.StarCollect >= (Global.Level - 1) * 3)
                {
                    _LevelLock[i].SetActive(true);
                }

            }           
        }

        _StarRemaining1.text = Global.StarPerStage1.ToString();
        _StarRemaining2.text = Global.StarPerStage2.ToString();
        _StarRemaining3.text = Global.StarPerStage3.ToString();
        _StarTotal1.text = _StarTotal2.text = _StarTotal3.text = Global.StarCollect.ToString();


    }

    void StartGameButton() {

    }

    void ExitButton()
    {
        Application.Quit();
    }
}
