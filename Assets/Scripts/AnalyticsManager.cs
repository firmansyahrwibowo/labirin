using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public enum AnalyticsType
{
    PLAYING_GAME,
    EXIT_GAME
}

public class AnalyticsManager : MonoBehaviour {

    AnalyticsTracker _Analytics;
    AnalyticsEventTracker _AnalyticsTracker;
	// Use this for initialization
	void Awake () {
        EventManager.AddListener<AnalyticsGameEvent>(AnalyticsHandler);
        _Analytics = GetComponent<AnalyticsTracker>();
        _AnalyticsTracker = GetComponent<AnalyticsEventTracker>();

    }

    private void AnalyticsHandler(AnalyticsGameEvent e)
    {
        //_Analytics.eventName = e.Type;
        //_Analytics.TriggerEvent();
        //_AnalyticsTracker.name = e.Type;
        Analytics.CustomEvent(e.Type, new Dictionary<string, object>
        {
            { "Username", "Test" },
            { "Play", 1},
            { "Exit", 1}
        });
    }
    
}
