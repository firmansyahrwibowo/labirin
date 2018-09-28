using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LevelData {
    public int IDLevel;
    public float Score;
    public bool IsClear;
}

public class Backeend : MonoBehaviour {
    
    public List<LevelData> DBLocalData = new List<LevelData>();

    //public Dictionary<string, int> DictionaryDBData = new Dictionary<string, int>();
    
    void Awake () {
        EventManager.AddListener<SaveDBLocalEvent>(SaveHighScore);
    }

    void Start()
    {
        //PlayerPrefs.SetString("DBLocalLevel.fyr", "");
        LoadAllHighScore();
        for (int i = 0; i < DBLocalData.Count; i++)
            EventManager.TriggerEvent(new SetDataLevelEvent(DBLocalData[i]));

        Global.Level = DBLocalData.Count;
    }

    #region Save
    public void SaveHighScore(SaveDBLocalEvent e)
    {
        string fileName = "";
        string filePath = "";
        string json = "";
        
        fileName = "DBLocalLevel.fyr";

        if (e != null)
            DBLocalData.Add(e.LevelData);
        json = JsonHelper.ToJson(DBLocalData.ToArray(), true);        //JsonUtility.ToJson(scoreData);

        PlayerPrefs.SetString(fileName, json);

        LoadAllHighScore();
        
        //File.WriteAllText(filePath, json);
        
    }

    void CalculateScore() {
        float score = 0;
        for (int i = 0; i < DBLocalData.Count; i++)
            score += DBLocalData[i].Score;

        float avg = score / DBLocalData.Count;
        Debug.Log(avg);
        EventManager.TriggerEvent(new LeaderboardAddEvent(Mathf.FloorToInt(avg)));

    }
    #endregion

    #region LOAD
    public void LoadAllHighScore( )
    {
        string path = "";
        string fileName = "";

        fileName = "DBLocalLevel.fyr";

        if (PlayerPrefs.GetString (fileName) != "")
        {
            string data = PlayerPrefs.GetString(fileName);
            DBLocalData = new List<LevelData>();
            string json = data;
            LevelData[] dataLevel = JsonHelper.FromJson<LevelData>(json);
            DBLocalData = dataLevel.ToList();
        }

    }
    #endregion

    #region ARRAY_JSON
    public class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.data;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.data = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.data = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }
    }
    [Serializable]
    private class Wrapper<T>
    {
        public T[] data;
    }
    #endregion
}
