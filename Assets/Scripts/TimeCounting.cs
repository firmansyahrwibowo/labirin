using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounting : MonoBehaviour {

    [SerializeField]
    Text _DurationText;
    [SerializeField]
    float _Time = 0;
    [SerializeField]
    bool _TimeStart;
    // Update is called once per frame
    private void Awake()
    {
        
    }
    public void InitTime() {
        _DurationText.text = "00:00";
        _Time = 0;
        _TimeStart = true;
    }
    void Update()
    {
        if (_TimeStart)
        {
            _Time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_Time / 60F);
            int seconds = Mathf.FloorToInt(_Time - minutes * 60);
            string niceTime = string.Format("{00:00}:{01:00}", minutes, seconds);
            _DurationText.text = niceTime;
        }
    }

    public void PauseTime(bool isBool)
    {
        _TimeStart = isBool;
    }
    public void StopTime() {
        _TimeStart = false;

        LevelData data = new LevelData();
        data.IDLevel = Global.Level;
        data.Score = _Time;
        data.IsClear = true;
        EventManager.TriggerEvent(new CheckDBLocalEvent(data));
    }
}
