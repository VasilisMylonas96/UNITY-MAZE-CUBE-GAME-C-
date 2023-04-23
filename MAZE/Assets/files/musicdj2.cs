using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class musicdj2 : MonoBehaviour
{
    public AudioSource dj2;//gia tous eixous

    public AudioClip cutcube;//hxoi
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playcut() {
        dj2.enabled = true;
        dj2.clip = cutcube;
        dj2.Play();

    }
}
