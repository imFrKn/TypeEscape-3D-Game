using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    // Start is called before the first frame update
    public float distance;
    public GameObject[] games;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
        transform.position += new Vector3(0, 0, distance*Time.deltaTime);
        if(transform.position.z >1000)
        {
            transform.position = new Vector3(0,0,0);
            foreach (var game in games)
            {
                game.SetActive(true);
            }
            
        }
    }
}
