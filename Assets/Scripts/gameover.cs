using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "You Score:" + player.scores;
    }
    public void Loadlevelmenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
