using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class HighScore {
    public string IDLevel;
    public int Score;
}

public class Backeend : MonoBehaviour {

    [SerializeField]
    private List<HighScore> _DBLocalData = new List<HighScore>();

    public Dictionary<string, int> DictionaryDBData = new Dictionary<string, int>();

    string _BackeendDir = "_Data";

    void Awake () {
        EventManager.AddListener<SaveDBLocalEvent>(SaveHighScore);
    }

    void Start()
    {
        if (!Directory.Exists(_BackeendDir))
            Directory.CreateDirectory(_BackeendDir);

        LoadAllHighScore();

        for (int i = 0; i < _DBLocalData.Count; i++) {
            DictionaryDBData.Add(_DBLocalData[i].IDLevel, _DBLocalData[i].Score);
        }
    }

    #region Save
    public void SaveHighScore(SaveDBLocalEvent e)
    {
        string fileName = "";
        string filePath = "";
        string json = "";
        
        fileName = "DBLocalScore.fyr";


        filePath = _BackeendDir +"/"+fileName;

        _DBLocalData = new List<HighScore>();
        foreach (var item in DictionaryDBData) {
            HighScore hs = new HighScore();
            hs.IDLevel = item.Key;
            hs.Score = item.Value;
            _DBLocalData.Add(hs);
        }

        //Game1HighScore.Add(data);
        json = JsonHelper.ToJson(_DBLocalData.ToArray(), true);        //JsonUtility.ToJson(scoreData);

        File.WriteAllText(filePath, json);
        
    }
    #endregion

    #region LOAD
    public void LoadAllHighScore( )
    {
        string path = "";
        string fileName = "";
        
        fileName = "DBLocalScore.fyr";
        
        string filePath = _BackeendDir + "/" + fileName;

        if (File.Exists(filePath))
        {
            _DBLocalData = new List<HighScore>();
            string json = File.ReadAllText(filePath);
            HighScore[] highScore = JsonHelper.FromJson<HighScore>(json);
            _DBLocalData = highScore.ToList();
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
