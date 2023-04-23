using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAndClicks : MonoBehaviour
{

    public GameObject light;
    public GameObject Cube;

    private GameObject Sphere;
    private GameObject Capsule;
    private GameObject Cylinder;

    private bool lightOn = true;
    public Text myText;
    private int jumps;

    private Transform CubeTransform;
    private bool firstCubePositionTaken = false;

    public int offset = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumps++;
            myText.text = "Jumps: " + jumps;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (lightOn == true)
            {
                light.SetActive(false);
                lightOn = false;
            }
            else
            {
                light.SetActive(true);
                lightOn = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Cube.AddComponent<Rigidbody>();
            Cube.transform.position = new Vector3(32.1f + offset, 50.0f, -13.5f);
            Cube.transform.GetComponent<MeshRenderer>().material.color = Color.cyan;

            if (firstCubePositionTaken == false)
            {
                CubeTransform = Cube.transform;
                firstCubePositionTaken = true;
            }
            offset -= 1;
        }

        if (firstCubePositionTaken == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Left CLick
            {
                Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Sphere.AddComponent<Rigidbody>();
                Sphere.transform.position = new Vector3(CubeTransform.position.x - 10, 60, CubeTransform.position.z - 20);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1)) // Right Click
            {
                Capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                Capsule.AddComponent<Rigidbody>();
                Capsule.transform.position = new Vector3(CubeTransform.position.x - 10, 60, CubeTransform.position.z - 20);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse2)) // Middle Click
            {
                Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                Cylinder.AddComponent<Rigidbody>();
                Cylinder.transform.position = new Vector3(CubeTransform.position.x - 10, 60, CubeTransform.position.z - 20);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Left CLick
            {
                Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Sphere.AddComponent<Rigidbody>();
                Sphere.transform.position = new Vector3(50, 60, -20);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1)) // Right Click
            {
                Capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                Capsule.AddComponent<Rigidbody>();
                Capsule.transform.position = new Vector3(50, 60, -20);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse2)) // Middle Click
            {
                Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                Cylinder.AddComponent<Rigidbody>();
                Cylinder.transform.position = new Vector3(50, 60, -20);
            }
        }
    }
}