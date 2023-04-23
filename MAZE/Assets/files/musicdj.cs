using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicdj : MonoBehaviour
{
    public AudioSource MusicSoursegame;
    public KeyCode playbutton;
    public KeyCode stopbutton;

    public AudioClip musicgame;
    public AudioClip musicgame1;
    private float changemusictime = 0;//gia na exoume  delay stin enalgh mousikis (gia ta bugs
    private int numberofmusic = 0;//gia tin allagi mousikis
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//APLA SETARW TO ENA KOMATI KAI TO ALLO KOMATI ME TO IDIO PLIKTRO P DEN XREIAZETAI KATI GIA EKSIGISI
    {
        if (changemusictime < 0)//EPANAFORA DELAY METABLITIS
        {
            changemusictime = 0;
        }
        if (changemusictime > 0)
        {
            changemusictime -= Time.deltaTime;//GIA TIN KATHISTERISI TON HITS NA MHN METRAEI APEIRA 
        }
        if (Input.GetKey(playbutton) && changemusictime == 0)
        {
            changemusictime = 1;
            MusicSoursegame.enabled = true;
            if (numberofmusic == 0)
            {

                MusicSoursegame.clip = musicgame;
                MusicSoursegame.Play();
                numberofmusic = 1;
            }
            else
            {
                MusicSoursegame.clip = musicgame1;
                MusicSoursegame.Play();
                numberofmusic = 0;

            }

        }
        if (Input.GetKey(stopbutton))
        {
            MusicSoursegame.Stop();
        }
    }
}
