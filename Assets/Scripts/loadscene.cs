using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public static float speeds;
    public static string words;
    public float speed;
    public string word;
    public TMP_InputField cusword;
    public GameObject w;
    public GameObject s;
    public void LoadScene(string sceneName)
    {
        speeds = speed;
        words = word;
        SceneManager.LoadScene(sceneName);
    }
    public void showstart()
    {
        w.SetActive(true);
        s.SetActive(true);
    }
    public void customlevel(string sceneName)
    {
        words = cusword.text;
        speed = speeds;
        SceneManager.LoadScene(sceneName);
    }
    public void Loadlevelmenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void exitgame()
    {
        Application.Quit();
    }
}