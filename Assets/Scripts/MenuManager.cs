using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public TMP_Text BestScoreTxt;
    public TMP_InputField InputName;

    void Start()
    {
        try
        {
           if(File.Exists(Application.persistentDataPath + "/saveData.json"))
           {
                DataManager.Instance.LoadInfo();
                BestScoreTxt.text = "Best Score: " + DataManager.Instance.inputName + ": " + DataManager.Instance.highScore;
           }
        } catch( System.Exception ex )
        {
            Debug.LogException(ex);
        }
        InputName.text = DataManager.Instance.inputName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReadInputField(string name)
    {
        DataManager.Instance.currentName = name;
    }
}
