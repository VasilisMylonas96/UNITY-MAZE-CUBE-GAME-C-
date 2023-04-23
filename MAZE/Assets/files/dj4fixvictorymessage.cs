using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dj4fixvictorymessage : MonoBehaviour
{
    public AudioSource dj4;
    public AudioClip victoryhorns;//hxoi nikis 

    // Start is called before the first frame update
    public void play()
    {
        dj4.clip = victoryhorns;//SETARE HXO
        dj4.Play();//PAIKSE HXO  
    }


 }
