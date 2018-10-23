using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public enum AnalyticsType
{
    PLAYING_GAME,
}

public class AnalyticsManager : MonoBehaviour {

    AnalyticsTracker _Analytics;
    AnalyticsEventTracker _AnalyticsTracker;
    PlayGamesManager _PlayGamesManager;
	// Use this for initialization
	void Awake () {
        EventManager.AddListener<AnalyticsGameEvent>(AnalyticsHandler);
        _Analytics = GetComponent<AnalyticsTracker>();
        _AnalyticsTracker = GetComponent<AnalyticsEventTracker>();
        _PlayGamesManager = GetComponent<PlayGamesManager>();

    }

    private void AnalyticsHandler(AnalyticsGameEvent e)
    {
        //_Analytics.eventName = e.Type;
        //_Analytics.TriggerEvent();
        //_AnalyticsTracker.name = e.Type;
        Analytics.CustomEvent(e.Type, new Dictionary<string, object>
        {
            { "Username", _PlayGamesManager.UserName },
            { "Play","Played"},
            { "Exit", "Exited"}
        });
    }
    
}
