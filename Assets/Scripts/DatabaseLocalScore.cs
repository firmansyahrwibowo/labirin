using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DatabaseLocalScore : MonoBehaviour {

    Backeend _Backend;
	// Use this for initialization
	void Awake () {
        _Backend = GetComponent<Backeend>();
        EventManager.AddListener<CheckDBLocalEvent>(CheckDBLocal);
	}

    private void CheckDBLocal(CheckDBLocalEvent e)
    {
        LevelData data = _Backend.DBLocalData.Find(x => x.IDLevel == e.highScore.IDLevel); //DATA SAVE
        if (data != null)
        {
            if (data.Score >= e.highScore.Score)
            {
                data.Score = e.highScore.Score;
                EventManager.TriggerEvent(new SaveDBLocalEvent(null));
            }
        }
        else
        {
            EventManager.TriggerEvent(new SaveDBLocalEvent(e.highScore));
        }
    }
}
