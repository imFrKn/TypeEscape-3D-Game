using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyer : MonoBehaviour
{
    public Rigidbody ob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacles")
        {
            Debug.Log("Do something else here");
            ob.transform.position = new Vector3(0.150000006f, 5.21999979f, 33.7900009f);
        }
        
    }
}
