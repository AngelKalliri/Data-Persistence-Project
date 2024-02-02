using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string inputName;
    public string currentName;
    public int highScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }
    
    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.name = currentName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

    
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            inputName = data.name;
            highScore = data.score;
        }
    }

    public bool OverrideHighScore(int score)
    {
        if (score > highScore)
        {
            return true;
        }
        return false;
    }
}
