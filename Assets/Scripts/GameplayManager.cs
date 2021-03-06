﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameplayManager : MonoBehaviour
{

    [SerializeField]
    GameObject _Ball;

    BallBehaviour _BallManager;

    [SerializeField]
    Vector2 _LabirinDefaultPos;

    [SerializeField]
    GameObject _WinUI;

    [SerializeField]
    int _ThisLevel;
    [SerializeField]
    int _NextLevel;

    public List<Level> _Level;

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

    [Header("Level Title Image")]
    [SerializeField]
    Sprite[] _LevelTittleImage;

    [SerializeField]
    GameObject _TransitionObject;
    Animator _Transition;

    [SerializeField]
    GameObject _Tutorial1;
    [SerializeField]
    GameObject _Tutorial2;
    [SerializeField]
    GameObject _TiltController;


    public bool IsEndLevel=false;

    private void Awake()
    {
        _Transition = _TransitionObject.GetComponent<Animator>();
        _TimeCounting = GetComponent<TimeCounting>();

        EventManager.AddListener<OnNextLevel>(GoToNextLevel);
        EventManager.AddListener<StartGameplayEvent>(StartGameInit);
        EventManager.AddListener<ObstacleEvent>(ObstacleHandler);
        EventManager.AddListener<GetStarEvent>(GetStarHandler);
        EventManager.AddListener<SetDataLevelEvent>(SetDataLevel);
        EventManager.AddListener<Tutorial1GameEvent>(SetTutorial1);
        EventManager.AddListener<Tutorial2GameEvent>(SetTutorial2);


        // Pause Handler
        _PauseButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(true);
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));

            AnalyticsEvent.Custom("Pause Button");

        });
        _ResumeButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnPause(false);
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));

            AnalyticsEvent.Custom("Resume Button");

        });
        _RestartButton.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = _ThisLevel;
            OnPause(false);
            Reset();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));

            AnalyticsEvent.Custom("Restart Button");

        });

        // Win Handler
        _WinRestart.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = _ThisLevel;
            OnPause(false);
            _WinUI.SetActive(false);
            Reset();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP_BACK, false));

            AnalyticsEvent.Custom("Restart Button");

        });
        _NextLevelButton.AddComponent<Button>().onClick.AddListener(delegate {
            NextLevel();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));
            EventManager.TriggerEvent(new BGMEvent(PlayType.RESTART));

            AnalyticsEvent.Custom("NextLevel Button");

            if (_ThisLevel==1)
            {
                EventManager.TriggerEvent(new Tutorial1GameEvent(true));
                _TiltController.SetActive(false);
            }
            if (_ThisLevel==3)
            {
                EventManager.TriggerEvent(new Tutorial2GameEvent(true));
                _TiltController.SetActive(false);
            }
        });
        _WinQuitButton.AddComponent<Button>().onClick.AddListener(delegate {
            Global.Level = _NextLevel;
            OnQuit();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP_BACK, false));
            EventManager.TriggerEvent(new BGMEvent(PlayType.MAIN_BGM));

            AnalyticsEvent.Custom("Quit Button");

        });

        _QuitButton.AddComponent<Button>().onClick.AddListener(delegate {
            OnQuit();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP_BACK, false));
            EventManager.TriggerEvent(new BGMEvent(PlayType.MAIN_BGM));

            AnalyticsEvent.Custom("Quit Button");

        });

        _BallManager = _Ball.AddComponent<BallBehaviour>();
    }

    public void SetDataLevel(SetDataLevelEvent e)
    {
        for (int i = 0; i < _Level.Count; i++) {
            if (_Level[i].Id == e.Data.IDLevel)
            {
                _Level[i].IsClear = e.Data.IsClear;
                Global.StarCollect += 3;
                switch (_Level[i].Stage) {
                    case 1:
                        Global.StarPerStage1 += 3;
                        break;
                    case 2:
                        Global.StarPerStage2 += 3;
                        break;
                    case 3:
                        Global.StarPerStage3 += 3;
                        break;
                    case 4:
                        Global.StarPerStage4 += 3;
                        break;
                    case 5:
                        Global.StarPerStage5 += 3;
                        break;
                    case 6:
                        Global.StarPerStage6 += 3;
                        break;
                }
            }
        }
    }

    private void StartGameInit(StartGameplayEvent e)
    {
        Time.timeScale = 1f;
        _ThisLevel = Global.Level;
        _NextLevel = _ThisLevel + 1;

        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);

        //LEVEL INIT
        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Level)
            {
                EventManager.TriggerEvent(new ChangeLabirinControlEvent(_Level[i].Labirin.transform));
                _Level[i].Labirin.SetActive(true);
            }
            else
                _Level[i].Labirin.SetActive(false);
        }

        SetTextLevel();
        _TimeCounting.InitTime();
        OnPause(false);
        Reset();
        EventManager.TriggerEvent(new AchievementAddEvent(2));
    }
    
    private void OnPause(bool isPause)
    {
        if (isPause)
        {
            EventManager.TriggerEvent(new ControllerEvent(false));
            EventManager.TriggerEvent(new BGMEvent(PlayType.PAUSE));
            _PauseUI.SetActive(true);
            _TimeCounting.PauseTime(false);
            Time.timeScale = 0.001f;
        }
        else
        {
            EventManager.TriggerEvent(new ControllerEvent(true));
            EventManager.TriggerEvent(new BGMEvent(PlayType.UNPAUSE));
            _PauseUI.SetActive(false);
            _TimeCounting.PauseTime(true);
            Time.timeScale = 1f;
        }
    }

    private void GoToNextLevel(OnNextLevel e)
    {
        if (_NextLevel > _Level.Count - 1)
        {
            _NextLevel = 0;
            IsEndLevel = true;
        }
        
        EventManager.TriggerEvent(new ControllerEvent(false));
        _TimeCounting.StopTime();
        //LEADERBOARD ADD CHALLENGE
        if (_ThisLevel == 29)
        {
            Debug.Log("LEVEL 30 = " + _TimeCounting.GetTime());
            EventManager.TriggerEvent(new LeaderboardAddEvent(_TimeCounting.GetTime(), LeaderboardType.CHALLENGE_1));
        }

        //_WinUI.SetActive(true);
        _TransitionObject.SetActive(true);
        _Transition.CrossFade("FadeIn", 0);

        StartCoroutine(WinTransition());

        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Level)
            {
                if ((_Level[i].IsClear == false) && (_Level[i].Stage == 1))
                {
                    Global.StarCollect += 3;
                    Global.StarPerStage1 += 3;
                    Debug.Log(Global.StarCollect);
                    _Level[i].IsClear = true;
                }

                if ((_Level[i].IsClear == false) && (_Level[i].Stage == 2))
                {
                    Global.StarCollect += 3;
                    Global.StarPerStage2 += 3;
                    Debug.Log(Global.StarCollect);
                    _Level[i].IsClear = true;
                }

                if ((_Level[i].IsClear == false) && (_Level[i].Stage == 3))
                {
                    Global.StarCollect += 3;
                    Global.StarPerStage3 += 3;
                    Debug.Log(Global.StarCollect);
                    _Level[i].IsClear = true;
                }

                if ((_Level[i].IsClear == false) && (_Level[i].Stage == 4))
                {
                    Global.StarCollect += 3;
                    Global.StarPerStage4 += 3;
                    Debug.Log(Global.StarCollect);
                    _Level[i].IsClear = true;
                }

                if ((_Level[i].IsClear == false) && (_Level[i].Stage == 5))
                {
                    Global.StarCollect += 3;
                    Global.StarPerStage5 += 3;
                    Debug.Log(Global.StarCollect);
                    _Level[i].IsClear = true;
                }

                if ((_Level[i].IsClear == false) && (_Level[i].Stage == 6))
                {
                    Global.StarCollect += 3;
                    Global.StarPerStage6 += 3;
                    Debug.Log(Global.StarCollect);
                    _Level[i].IsClear = true;
                }


            }
        }

        if (IsEndLevel == true)
        {
            _NextLevelButton.SetActive(false);
        }

        EventManager.TriggerEvent(new BGMEvent(PlayType.STOP));
        EventManager.TriggerEvent(new SFXPlayEvent(SfxType.LABIRIN, true));
    }

    void NextLevel()
    {
        Global.Level = _NextLevel;
        EventManager.TriggerEvent(new ControllerEvent(true));

        //_WinUI.SetActive(false);
        _Transition.CrossFade("FadeOut", 0);
        StartCoroutine(ReverseWinTransition());

        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);

        //LEVEL INIT
        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Level)
            {
                EventManager.TriggerEvent(new ChangeLabirinControlEvent(_Level[i].Labirin.transform));
                _Level[i].Labirin.SetActive(true);

            }
            else
                _Level[i].Labirin.SetActive(false);

        }


        OnPause(false);
        _TimeCounting.InitTime();
        SetTextLevel();
        Reset();

        _ThisLevel = Global.Level;
        _NextLevel = _ThisLevel + 1;
    }

    void ObstacleHandler(ObstacleEvent e)
    {
        _BallManager.ResetBehaviour();
        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);
        for (int i = 0; i < _Level.Count; i++)
        {
            if (i==Global.Level)
            {
                _Ball.transform.position = _Level[i].BallDefaultPosition.position;
            }
           
        }
            
    }

    void GetStarHandler(GetStarEvent e) {
        Star[e.Number].SetActive(true);
    }

    void SetTextLevel() {
        _LevelImage.sprite = _LevelTittleImage[Global.Level];
        _LevelImage.SetNativeSize();
        _WinUILevelImage.sprite = _LevelTittleImage[Global.Level];
        _WinUILevelImage.SetNativeSize();
    }

    void OnQuit() {
        OnPause(false);
        EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu1));
    }

    private void Reset()
    {
        _BallManager.ResetBehaviour();
        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
            Star[i].SetActive(false);
        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Level)
                _Ball.transform.position = _Level[i].BallDefaultPosition.position;
        }
           
    }

    IEnumerator WinTransition()
    {
        yield return new WaitForSeconds(1);
        _WinUI.SetActive(true);
    }

    IEnumerator ReverseWinTransition()
    {
        EventManager.TriggerEvent(new BlockSpamEvent(true));
        _WinUI.SetActive(false);
        yield return new WaitForSeconds(1);
        _TransitionObject.SetActive(false);
        EventManager.TriggerEvent(new BlockSpamEvent(false));
    }

    void SetTutorial1(Tutorial1GameEvent e) {
        _Tutorial1.SetActive(e.IsActive);
        _TiltController.SetActive(e.IsActive);
    }

    void SetTutorial2(Tutorial2GameEvent e) {
        _Tutorial2.SetActive(e.IsActive);
        _TiltController.SetActive(e.IsActive);
    }

}
