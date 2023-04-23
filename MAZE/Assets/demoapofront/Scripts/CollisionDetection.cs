using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            Debug.Log("Cube - Entered called.");
        else if (collision.gameObject.name == "Wall1")
            Debug.Log("Wall 1 - Entered called.");
        else if (collision.gameObject.name == "Wall2")
            Debug.Log("Wal 2 - Entered called.");
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            Debug.Log("Cube Stay occuring....");
        else if (collision.gameObject.name == "Wall1")
            Debug.Log("Wall 1 - Stay occuring....");
        else if (collision.gameObject.name == "Wall2")
            Debug.Log("Wall 2 - Stay occuring....");
       
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            Debug.Log("Cube - Exit called.");
        else if (collision.gameObject.name == "Wall1")
            Debug.Log("Wall 1 - Exit called.");
        else if (collision.gameObject.name == "Wall2")
            Debug.Log("Wall 2 - Exit called.");
    }
}
