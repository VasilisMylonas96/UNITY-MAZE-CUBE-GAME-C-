using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    //KOUMPIA 
    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;
    public KeyCode z1;
    public KeyCode z2;
    public KeyCode rotatebutton;
    public KeyCode CHANGECAMERA;
    public KeyCode rotatebutton1;
    public Camera cameraekswteriki;//O EAUTOS TOU THA MPOROUSA KAI CAMERA.MAIN



    
    private int CAMERAX = -1;
    private int CAMERAY=2;
   
    private int CAMERAZ=-16;
    private int rotate = 0;
    public Vector3 saveedposition;
    // Start is called before the first frame update
    void Start()
    {
        
        //CAMERAY = L1/2;
        //CAMERAZ = -2 * N1/ 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right))//RIGHT ARROW GIA DEKSIA
        {
            CAMERAX = CAMERAX + 1;
            cameraekswteriki.transform.position = new Vector3(CAMERAX, CAMERAY, CAMERAZ);
        }
        if (Input.GetKey(left))//LEFT ARROW GIA ARISTERA
        {
            CAMERAX = CAMERAX - 1;
            cameraekswteriki.transform.position = new Vector3(CAMERAX, CAMERAY, CAMERAZ);
        }
        if (Input.GetKey(up))//UP ARROW GIA PANW
        {
            CAMERAY = CAMERAY + 1;
            cameraekswteriki.transform.position = new Vector3(CAMERAX, CAMERAY, CAMERAZ);
        }
        if (Input.GetKey(down))//DOWN ARROW GIA KATW 
        {
            CAMERAY = CAMERAY - 1;
            cameraekswteriki.transform.position = new Vector3(CAMERAX, CAMERAY, CAMERAZ);
        }
        if (Input.GetKey(z1))//PAGEUP GIA MESA
        {
            CAMERAZ = CAMERAZ + 1;
            cameraekswteriki.transform.position = new Vector3(CAMERAX, CAMERAY, CAMERAZ);
        }
        if (Input.GetKey(z2))//PAGEDOWN GIA EKSW
        {
            CAMERAZ = CAMERAZ - 1;
            cameraekswteriki.transform.position=new Vector3(CAMERAX, CAMERAY, CAMERAZ);
        }
        if (Input.GetKey(rotatebutton))//R GIA ARISTERA ROTATE
        {
            rotate = rotate + 1;
            cameraekswteriki.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
        if (Input.GetKey(rotatebutton1))//T GIA DEKSIA ROTATE
        {
            rotate = rotate - 1;
            cameraekswteriki.transform.rotation = Quaternion.Euler (0, rotate, 0);
        }
        if (Input.GetKey(CHANGECAMERA))//K GIA EPANAFORA KAMERAS
        {

            //fps1.transform.GetChild(0).gameObject.SetActive(true);


            //Camera.main.enabled = false;
            //GameObject.Find("FPSController(Clone)").SetActiveRecursively(true);den douleuei wste na min kounietai kai h main camera me ta belakia psilo buged to unity 
            GameObject.Find("Camera(Clone)").SetActive(false);
           


        }






    }

}
