using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNCloseWindow : MonoBehaviour
{

    public GameObject UI;
    private GameObject Cube;

    public string N;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text PlaceHolder = UI.transform.Find("Panel").Find("InputField").GetComponent<InputField>().placeholder.GetComponent<Text>();

        if (PlaceHolder == null)
            return;
        // Press the space key to change the Text message.
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Placeholder: "+PlaceHolder.text.ToString());
            Debug.Log("Text: "+ UI.transform.Find("Panel").Find("InputField").GetComponent<InputField>().text);
            UI.SetActive(false);
            for (int i = 0; i < 10; i++)
            {
                Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                Cube.transform.position = new Vector3(0, 0, i * 2.0f);
            }
            for (int i = 0; i < 10; i++)
            {
                Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                Cube.transform.position = new Vector3(i * 2.0f, 0, 0);
            }
        }
    }
}
