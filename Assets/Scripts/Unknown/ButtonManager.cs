using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelSelectData
{
    public LevelSelectButtonType ButtonType;
    public GameObject Object;
    public int GlobalLevel;
}

public class ButtonManager : MonoBehaviour {
    [SerializeField]
    GameObject _MainMenuPlayButton;
    [SerializeField]
    GameObject _TutorialButton;
    [SerializeField]
    GameObject _MainMenuExitButton;

    [SerializeField]
    LevelSelectData [] _LevelSelectData;

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

    [SerializeField]
    GameObject _Level16Button;
    [SerializeField]
    GameObject _Level17Button;
    [SerializeField]
    GameObject _Level18Button;
    [SerializeField]
    GameObject _Level19Button;
    [SerializeField]
    GameObject _Level20Button;
    [SerializeField]
    GameObject _BackToMenuButton4;
    [SerializeField]
    GameObject _Left4;
    [SerializeField]
    GameObject _Right4;

    [SerializeField]
    GameObject _Level21Button;
    [SerializeField]
    GameObject _Level22Button;
    [SerializeField]
    GameObject _Level23Button;
    [SerializeField]
    GameObject _Level24Button;
    [SerializeField]
    GameObject _Level25Button;
    [SerializeField]
    GameObject _BackToMenuButton5;
    [SerializeField]
    GameObject _Left5;
    [SerializeField]
    GameObject _Right5;

    [SerializeField]
    GameObject _Level26Button;
    [SerializeField]
    GameObject _Level27Button;
    [SerializeField]
    GameObject _Level28Button;
    [SerializeField]
    GameObject _Level29Button;
    [SerializeField]
    GameObject _Level30Button;
    [SerializeField]
    GameObject _BackToMenuButton6;
    [SerializeField]
    GameObject _Left6;
    [SerializeField]
    GameObject _Right6;

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
    Text _StarRemaining4;
    [SerializeField]
    Text _StarRemaining5;
    [SerializeField]
    Text _StarRemaining6;


    [SerializeField]
    Text _StarTotal1;
    [SerializeField]
    Text _StarTotal2;
    [SerializeField]
    Text _StarTotal3;
    [SerializeField]
    Text _StarTotal4;
    [SerializeField]
    Text _StarTotal5;
    [SerializeField]
    Text _StarTotal6;


    MainManager _MainManager;
    
    void Awake () {
        _MainManager = GetComponent<MainManager>();

        EventManager.AddListener<InitButtonEvent>(Init);

        //Main Menu Handler
        _MainMenuPlayButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new MainMenuButtonEvent(MainMenuButtonType.START_GAME));
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
        });

        _TutorialButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new MainMenuButtonEvent(MainMenuButtonType.TUTORIAL));
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
        });

        _MainMenuExitButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP_BACK, false));
            ExitButton();
        });


        //BENTUK SEDERHANA LEVEL HANDLER
        foreach (LevelSelectData data in _LevelSelectData)
        {
            data.Object.AddComponent<Button>().onClick.AddListener(delegate
            {
                ButtonAction(data);
            });
        }
        #region LevelHandler used to be
        /*
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

        _Level16Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 15;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_16));
        });
        _Level17Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 16;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_17));
        });
        _Level18Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 17;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_18));
        });
        _Level19Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 18;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_19));
        });
        _Level20Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 19;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_20));
        });
        _BackToMenuButton4.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu4));
        });
        _Left4.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Left_4));
        });
        _Right4.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Right_4));
        });

        _Level21Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 20;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_21));
        });
        _Level22Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 21;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_22));
        });
        _Level23Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 22;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_23));
        });
        _Level24Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 23;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_24));
        });
        _Level25Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 24;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_25));
        });
        _BackToMenuButton5.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu5));
        });
        _Left5.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Left_5));
        });
        _Right5.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Right_5));
        });

        _Level26Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 25;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_26));
        });
        _Level27Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 26;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_27));
        });
        _Level28Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 27;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_28));
        });
        _Level29Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 28;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_29));
        });
        _Level30Button.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = 29;
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.LEVEL_30));
        });
        _BackToMenuButton6.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu6));
        });
        _Left6.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Left_6));
        });
        _Right6.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Right_6));
        });
        */
        #endregion
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
        _StarRemaining4.text = Global.StarPerStage4.ToString();
        _StarRemaining5.text = Global.StarPerStage5.ToString();
        _StarRemaining6.text = Global.StarPerStage6.ToString();
        _StarTotal1.text = _StarTotal2.text = _StarTotal3.text = _StarTotal4.text = _StarTotal5.text = _StarTotal6.text = Global.StarCollect.ToString();


    }

    public void ButtonAction (LevelSelectData data)
    {
        if (data.GlobalLevel != -1)
        {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, true));
            Global.Level = data.GlobalLevel;
        }
        else
        {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.LEFT_RIGHT, true));
        }
        EventManager.TriggerEvent(new LevelSelectButtonEvent(data.ButtonType));
    }

    void StartGameButton() {

    }

    void ExitButton()
    {
        Application.Quit();
    }
}
