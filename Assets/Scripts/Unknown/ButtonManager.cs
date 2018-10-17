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
[System.Serializable]
public class LevelLockData
{
    public GameObject LevelButton;
    public GameObject LevelLabel;
}

public class ButtonManager : MonoBehaviour {
    [SerializeField]
    GameObject _MainMenuPlayButton;
    [SerializeField]
    GameObject _HighscoreButton;
    [SerializeField]
    GameObject _AchievementButton;
    [SerializeField]
    GameObject _MainMenuExitButton;

    [SerializeField]
    LevelSelectData [] _LevelSelectData;
    
    [Header("LEVEL LOCK")]
    [SerializeField]
    LevelLockData [] _LevelLockData;

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

    Backeend _Backend;
    
    void Awake () {
        _MainManager = GetComponent<MainManager>();
        _Backend = GetComponent<Backeend>();
        EventManager.AddListener<InitButtonEvent>(Init);

        //Main Menu Handler
        _MainMenuPlayButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, true));
            EventManager.TriggerEvent(new MainMenuButtonEvent(MainMenuButtonType.START_GAME));
        });

        _HighscoreButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
            EventManager.TriggerEvent(new ShowLeaderboardEvent());
        });
        
        _AchievementButton.AddComponent<Button>().onClick.AddListener(delegate {
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
            EventManager.TriggerEvent(new ShowAchievementEvent());
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
    }

    public void Init (InitButtonEvent e)
    {
        Global.Level = _Backend.DBLocalData.Count;
        //Level Lock Handler
        for (int i = 0; i < _LevelLockData.Length; i++)
        {
            if (i <= Global.Level)
            {
                if (Global.StarCollect >= (Global.Level - 1) * 3)
                {
                    //_LevelLock[i].SetActive(true);
                    _LevelLockData[i].LevelButton.SetActive(true);
                    _LevelLockData[i].LevelLabel.SetActive(true);
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
