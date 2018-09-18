using System;
using System.Collections;
using System.Collections.Generic;
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
        if (_Backend.DictionaryDBData.ContainsKey(e.highScore.IDLevel))
        {
            int score = _Backend.DictionaryDBData[e.highScore.IDLevel];
            if (e.highScore.Score <= score)
            {
                _Backend.DictionaryDBData[e.highScore.IDLevel] = e.highScore.Score;
                EventManager.TriggerEvent(new SaveDBLocalEvent(e.highScore));
            }

        }
        else
        { 
            _Backend.DictionaryDBData.Add(e.highScore.IDLevel, e.highScore.Score);
            EventManager.TriggerEvent(new SaveDBLocalEvent(e.highScore));
        }
    }
}
