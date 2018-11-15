using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class ChallengeManager : MonoBehaviour
{
    [SerializeField]
    GameObject _Ball;

    BallBehaviour1 _BallManager;

    [SerializeField]
    Vector2 _LabirinDefaultPos;

    [SerializeField]
    GameObject _WinUI;

    [SerializeField]
    int _ThisLevel;

    public List<Challenge> _Level;

    [Header("WIN BUTTON")]
    [SerializeField]
    GameObject _WinRestart;
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
    Sprite[] _ChallengeTittleImage;

    [SerializeField]
    GameObject _TransitionObject;
    Animator _Transition;

    [SerializeField]
    GameObject _TiltController;

    [SerializeField]
    Transform _BallDefaultPosition;

    [SerializeField]
    GameObject _Labirin;

    private void Awake()
    {
        _Transition = _TransitionObject.GetComponent<Animator>();
        _TimeCounting = GetComponent<TimeCounting>();

        EventManager.AddListener<OnFinishChallenge>(FinishChallenge);
        EventManager.AddListener<StartChallengeEvent>(StartChallengeInit);
        EventManager.AddListener<ObstacleEvent>(ObstacleHandler);
        EventManager.AddListener<GetStarEvent>(GetStarHandler);

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
            //_Labirin.SetActive(true);
            //EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));
            Global.Challenge = _ThisLevel;
            OnPause(false);
            Reset();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP, false));

            AnalyticsEvent.Custom("Restart Button");

        });

        // Win Handler
        _WinRestart.AddComponent<Button>().onClick.AddListener(delegate {
            //_Labirin.SetActive(true);
            //EventManager.TriggerEvent(new BGMEvent(PlayType.PLAY));
            Global.Challenge = _ThisLevel;
            OnPause(false);
            _WinUI.SetActive(false);
            Reset();
            EventManager.TriggerEvent(new SFXPlayEvent(SfxType.TAP_BACK, false));

            AnalyticsEvent.Custom("Restart Button");

        });

        _WinQuitButton.AddComponent<Button>().onClick.AddListener(delegate {
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

        _BallManager = _Ball.AddComponent<BallBehaviour1>();


    }

    private void StartChallengeInit(StartChallengeEvent e)
    {
        Time.timeScale = 1f;
        _ThisLevel = Global.Challenge;

        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
        {
            Star[i].SetActive(false);
        }

        // LEVEL INIT
        //_Labirin.SetActive(true);

        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Challenge)
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
    }

    void SetTextLevel()
    {
        _LevelImage.sprite = _ChallengeTittleImage[Global.Challenge];
        _LevelImage.SetNativeSize();
        //_LevelImage.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        _WinUILevelImage.sprite = _ChallengeTittleImage[Global.Challenge];
        _WinUILevelImage.SetNativeSize();
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

    private void Reset()
    {
        _BallManager.ResetBehaviour();
        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
        {
            Star[i].SetActive(false);
        }

        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Challenge)
                _Ball.transform.position = _Level[i].BallDefaultPosition.position;
        }

        //_Ball.transform.position = _BallDefaultPosition.position;
    }

    void ObstacleHandler(ObstacleEvent e)
    {
        _BallManager.ResetBehaviour();
        //STAR INIT
        for (int i = 0; i < Star.Length; i++)
        {
            Star[i].SetActive(false);
        }
        for (int i = 0; i < _Level.Count; i++)
        {
            if (i == Global.Challenge)
            {
                _Ball.transform.position = _Level[i].BallDefaultPosition.position;
            }

        }

        //_Ball.transform.position = _BallDefaultPosition.position;
    }

    void GetStarHandler(GetStarEvent e)
    {
        Star[e.Number].SetActive(true);
    }

    void OnQuit()
    {
        OnPause(false);
        EventManager.TriggerEvent(new LevelSelectButtonEvent(LevelSelectButtonType.Back_ToMenu1));
    }

    private void FinishChallenge(OnFinishChallenge e)
    {
        EventManager.TriggerEvent(new ControllerEvent(false));
        _TimeCounting.StopTime();

        _TransitionObject.SetActive(true);
        _Transition.CrossFade("FadeIn", 0);

        StartCoroutine(WinTransition());

        Debug.Log("Challenge = " + _TimeCounting.GetTime());
        EventManager.TriggerEvent(new LeaderboardAddEvent(_TimeCounting.GetTime(), LeaderboardType.CHALLENGE_2));
        EventManager.TriggerEvent(new BGMEvent(PlayType.STOP));
        EventManager.TriggerEvent(new SFXPlayEvent(SfxType.LABIRIN, true));
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
}
