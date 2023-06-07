using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using static UnityEngine.GraphicsBuffer;

public class player : MonoBehaviour
{
    public AudioSource breaksound;
    public AudioSource clicksound;
    public TextMeshProUGUI word3d;
    public TextMeshProUGUI score;
    public TextMeshProUGUI wordtodestroy;
    string path = "Assets/Resources/test.txt";
    private GameObject ob;
    private string words = loadscene.words;
    private string[] word; 
    private string key = null;
    private int i = 0;
    public ParticleSystem destroy;
    float p = 4f;
    bool found = false;
    bool gamepause = false;
    bool des = false;
    float speed = loadscene.speeds;
    int j = 0;
    int wordindex = 0;
    public static int scores = 0;
    Vector3 target;
    //RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
        word = words.Split(' ');
        wordtodestroy.text = "Type word to destroy wall: " + word[wordindex];
    }

    // Update is called once per frame
    void Update()
    {
        if (wordindex < word.Length)
        {
            //Debug.Log(word3d.text);
            if (found == false)
            {
                word3d.transform.position = new Vector3(transform.position.x + 4f + 1f, transform.position.y + 0.3f, transform.position.z + 7.73f);
            }
            else
            {
                float step = speed * Time.deltaTime;
                word3d.transform.position = Vector3.MoveTowards(word3d.transform.position, target, step);
            }
            if (gamepause == false)
            {
                if (Input.anyKeyDown)
                {
                    clicksound.Play();
                    if (j == 1)
                    {
                        word3d.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                        j = 0;
                    }
                    if (i > word[wordindex].Length)
                    {
                        i = -1;
                        p = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        Debug.Log(key);
                        key = key.Remove(key.Length - 1);
                        Debug.Log(key);
                        word3d.text = key;
                        i = i-2;
                    }
                    else
                    {
                        //if (Input.inputString == word[wordindex][i].ToString())
                        {
                            found = false;
                            key = key + Input.inputString;
                            word3d.text = key;
                            p = p + 3f;
                            if (key == word[wordindex])
                            {
                                scores = scores + 10;
                                RaycastHit[] hits;
                                hits = Physics.RaycastAll(transform.position, transform.forward, 100);
                                for (int i = 0; i < hits.Length; i++)
                                {
                                    RaycastHit hit = hits[i];
                                    if (hit.transform.gameObject.CompareTag("Obstacles"))
                                    {
                                        breaksound.Play();
                                        hit.transform.gameObject.SetActive(false);
                                        target = hit.transform.position;
                                        //word3d.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                                        word3d.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                                        j = 1;
                                        found = true;
                                        gamepause = true;
                                        wordindex++;
                                        Instantiate(destroy.gameObject, hit.transform.position, hit.transform.rotation);
                                        score.text = "Score: " + scores;
                                    }
                                }
                                i = -1;
                                key = null;
                                p = 0;
                            }

                        }
                        /*else
                        //{
                            i = -1;
                            p = 0;
                            key = null;
                        }*/
                    }
                    i++;
                }
            }
            else
            {
                Debug.Log(transform.position.z % 100);
                if ((int)transform.position.z % 100 == 0)
                {
                    gamepause = false;
                    wordtodestroy.text = "Type word to destroy wall: " + word[wordindex];
                }
            }
        }
        else
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
