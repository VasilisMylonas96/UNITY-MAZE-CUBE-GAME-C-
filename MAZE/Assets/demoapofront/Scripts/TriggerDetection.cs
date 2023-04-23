using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public GameObject spotlight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            Debug.Log("Camera Entered");
            spotlight.SetActive(false);
        }
        else
            Debug.Log("Sphere Entered");
    }


    void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            Debug.Log("Camera Exit\n------------------");
            spotlight.SetActive(true);
        }
    }
}
