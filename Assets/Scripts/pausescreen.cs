using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausescreen : MonoBehaviour
{
    public GameObject[] pauseObjects;
    public GameObject pausemenu;

    public void onclick()
    {
        Time.timeScale = 0;
        pausemenu.SetActive(true);
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    public void MainLoadScene(string sceneName)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            foreach (GameObject g in pauseObjects)
            {
                g.SetActive(true);
            }
            pausemenu.SetActive(false);
        }
        SceneManager.LoadScene(sceneName);
    }
    public void reload()
    {
        Application.LoadLevel(Application.loadedLevel);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            foreach (GameObject g in pauseObjects)
            {
                g.SetActive(true);
            }
            pausemenu.SetActive(false);
        }
    }
    public void pauseControl()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            foreach (GameObject g in pauseObjects)
            {
                g.SetActive(true);
            }
            pausemenu.SetActive(false);
        }
    }
}
