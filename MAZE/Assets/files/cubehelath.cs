using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubehelath : MonoBehaviour
{
    public KeyCode mintransparentcube;
    public KeyCode plustransparentcube;
    public int health=3 ;
    public float trLevel = 0.5f;

   public void TakeDamage(int hit)
    {
        health =health- hit;
      
    }
    public int returnHealth() {
        return health;

    }
    public void Update()
    {
        if (Input.GetKey(mintransparentcube))
        {
            GetComponent<Renderer>().enabled = false;
        }
        if (Input.GetKey(plustransparentcube))
        {
            GetComponent<Renderer>().enabled = true;
        }


    }


}
