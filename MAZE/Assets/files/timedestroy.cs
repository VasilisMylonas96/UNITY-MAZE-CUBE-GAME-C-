using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedestroy : MonoBehaviour
{
    public GameObject litlecubes;
    public float timedestroylitlecube = 10;


    // Update is called once per frame
    void Update()//OTAN PERASOUN 10 SEC DLD TIMEDESTROYLITLECUBE<0 TOTE SBISE TA KIBAKIA TO SKIPT PERIEXETE SE OLA TA LITLECUBES
    {
          
    
                    if (timedestroylitlecube > 0)
                    {
                        timedestroylitlecube -= Time.deltaTime;

                    }
                    else
                    {
                        enabled = false;
                        litlecubes.SetActive(false);
                    }
    }
}

