using System;
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

    [Header("PAUSE BUTTON")]
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

    [SerializeField]
    Text _TextLevel;
    [SerializeField]
    Text _WinUILevel;

    TimeCounting _TimeCounting;

    [SerializeField]
    GameObject[] Star;
    

    private void Awake()
    {
        _TimeCounting = GetComponent<TimeCounting>();

        EventManager.AddListener<OnNextLevel>(GoToNextLevel);
        EventManager.AddListener<StartGameplayEvent>(StartGameInit);
        EventManager.AddListener<ObstacleEvent>(ObstacleHandler);
        EventManager.AddListener<GetStarEvent>(GetStarHandler);

        _NextLevelButton.AddComponent<Button>().onClick.AddListener(delegate {
            NextLevel();
        });

        // Pause Handler
        _PauseButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(true);
        });
        _ResumeButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
        });
        _RestartButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
            Reset();
        });
        _WinRestart.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
            _WinUI.SetActive(false);
            Reset();
        });
        _QuitButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnQuit();
        });
        _WinQuitButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnQuit();
        });

        _BallManager = _Ball.AddComponent<BallBehaviour>();
    }
    
    private void StartGameInit(StartGameplayEvent e)
    {
        Time.timeScale = 1f;
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
        for (int i = 0; i < _Level.Length; i++)
            _Level[i].transform.position = _LabirinDefaultPos;
    }

    void GetStarHandler(GetStarEvent e) {
        Star[e.Number].SetActive(true);
    }

    void SetTextLevel() {
        _TextLevel.text = "LEVEL " + (Global.Level+1).ToString();
        _WinUILevel.text = "LEVEL " + (Global.Level + 1).ToString();
    }

    void OnQuit() {
        Application.Quit();
    }

    private void Reset()
    {
        _Ball.transform.position = _BallDefaultPos;
        _BallManager.ResetBehaviour();
        for (int i = 0; i < _Level.Length; i++)
            _Level[i].transform.position = _LabirinDefaultPos;
    }


}
