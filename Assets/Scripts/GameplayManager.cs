﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    GameObject _Ball;
    BallBehaviour _BallManager;
    [SerializeField]
    Vector2 _BallDefaultPos;
    [SerializeField]
    Vector2 _LabirinDefaultPos;

    [SerializeField]
    GameObject _WinUI;
    // Use this for initialization
    [SerializeField]
    GameObject [] _Level;

    [Header("WIN BUTTON")]
    [SerializeField]
    GameObject _WinRestart;
    [SerializeField]
    GameObject _NextLevelButton;
    [SerializeField]
    GameObject _WinQuitButton;

    [Header("PAUSE BUTTON")]
    [SerializeField]
    GameObject _PauseUI;
    [SerializeField]
    GameObject _PauseButton;
    [SerializeField]
    GameObject _ResumeButton;
    [SerializeField]
    GameObject _RestartButton;
    [SerializeField]
    GameObject _QuitButton;

    [Header("LEVEL IMAGE")]
    [SerializeField]
    Image _LevelImage;
    [SerializeField]
    Image _WinUILevelImage;

    TimeCounting _TimeCounting;

    [SerializeField]
    GameObject[] Star;

    [Header("Level Image")]
    [SerializeField]
    Sprite[] _LevelTittleImage;

    private void Awake()
    {
        _TimeCounting = GetComponent<TimeCounting>();

        EventManager.AddListener<OnNextLevel>(GoToNextLevel);
        EventManager.AddListener<StartGameplayEvent>(StartGameInit);
        EventManager.AddListener<ObstacleEvent>(ObstacleHandler);
        EventManager.AddListener<GetStarEvent>(GetStarHandler);

        _NextLevelButton.AddComponent<Button>().onClick.AddListener(delegate {
            NextLevel();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CLICK, false));
        });

        // Pause Handler
        _PauseButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(true);
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CLICK, false));
        });
        _ResumeButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CLICK, false));
        });
        _RestartButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
            Reset();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CLICK, false));
        });
        _WinRestart.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
            _WinUI.SetActive(false);
            Reset();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CANCEL, false));
        });
        _QuitButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnQuit();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CANCEL, false));
        });
        _WinQuitButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnQuit();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.CANCEL, false));
        });

       
        _BallManager = _Ball.AddComponent<BallBehaviour>();
    }
    
    private void StartGameInit(StartGameplayEvent e)
    {
        Time.timeScale = 1f;

        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);

        //LEVEL INIT
        for (int i = 0; i < _Level.Length; i++)
        {
            if (i == Global.Level)
            {
                EventManager.TriggerEvent(new ChangeLabirinControlEvent(_Level[i].transform));
                _Level[i].SetActive(true);
            }
            else
                _Level[i].SetActive(false);
        }

        SetTextLevel();
        _TimeCounting.InitTime();
        OnPause(false);
        Reset();
    }
    
    private void OnPause(bool isPause)
    {
        if (isPause)
        {
            EventManager.TriggerEvent(new ControllerEvent(false));
            _PauseUI.SetActive(true);
            _TimeCounting.PauseTime(false);
            Time.timeScale = 0.001f;
        }
        else
        {
            EventManager.TriggerEvent(new ControllerEvent(true));
            _PauseUI.SetActive(false);
            _TimeCounting.PauseTime(true);
            Time.timeScale = 1f;
        }
    }

    private void GoToNextLevel(OnNextLevel e)
    {
        EventManager.TriggerEvent(new ControllerEvent(false));
        _TimeCounting.StopTime();
        _WinUI.SetActive(true);
        EventManager.TriggerEvent(new SFXPlayEvent(SfxType.LABIRIN, true));
    }

    void NextLevel()
    {
        EventManager.TriggerEvent(new ControllerEvent(true));
        _WinUI.SetActive(false);
        Global.Level++;
        if (Global.Level > 4)
            Global.Level = 0;

        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);

        //LEVEL INIT
        for (int i = 0; i < _Level.Length; i++)
        {
            if (i == Global.Level)
            {
                EventManager.TriggerEvent(new ChangeLabirinControlEvent(_Level[i].transform));
                _Level[i].SetActive(true);
            }
            else
                _Level[i].SetActive(false);
        }

        OnPause(false);
        _TimeCounting.InitTime();
        SetTextLevel();
        Reset();
    }

    void ObstacleHandler(ObstacleEvent e)
    {
        _Ball.transform.position = _BallDefaultPos;
        _BallManager.ResetBehaviour();
        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);
        for (int i = 0; i < _Level.Length; i++)
            _Level[i].transform.position = _LabirinDefaultPos;
    }

    void GetStarHandler(GetStarEvent e) {
        Star[e.Number].SetActive(true);
    }

    void SetTextLevel() {
        _LevelImage.sprite = _LevelTittleImage[Global.Level];
        _LevelImage.SetNativeSize();
        _WinUILevelImage.sprite = _LevelTittleImage[Global.Level];
        _WinUILevelImage.SetNativeSize();
        //_TextLevel.text = "LEVEL " + (Global.Level+1).ToString();
        //_WinUILevel.text = "LEVEL " + (Global.Level + 1).ToString();
    }

    void OnQuit() {
        Application.Quit();
    }

    private void Reset()
    {
        _Ball.transform.position = _BallDefaultPos;
        _BallManager.ResetBehaviour();
        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);
        for (int i = 0; i < _Level.Length; i++)
            _Level[i].transform.position = _LabirinDefaultPos;
    }


}
