using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public string hitTransformBefore;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100) && hit.transform.name != "Floor")
        {
            //Visible only on Scene Mode
            Debug.DrawLine(ray.origin, hit.point, Color.red, 2.5f);
            print("Hit Something - " + hit.transform.name);
            print("Found an object - distance: " + hit.distance);
            
            if (hit.transform.name != hitTransformBefore)
            {
                if (Random.Range(0, 4) == 0) 
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                else if (Random.Range(1, 4) == 1)
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
                else if (Random.Range(1, 4) == 2)
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.green;
                else if (Random.Range(1, 4) == 3)
                    hit.transform.GetComponent<MeshRenderer>().material.color = Color.cyan;

                print("Color: " + hit.transform.GetComponent<MeshRenderer>().material.color);
            }
            
        }

        if(hit.transform != null)
            hitTransformBefore = hit.transform.name;
      

    }

}
