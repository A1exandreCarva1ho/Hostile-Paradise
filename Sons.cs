using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Sons: MonoBehaviour
{  
    public AudioClip passo;
    public AudioClip pulo_agua;

    public GameObject player;

    public AudioSource[] caixadesom;
   
    public void Start()
    {
        caixadesom = GetComponents<AudioSource>();
        caixadesom[0].clip = passo;
        caixadesom[1].clip = pulo_agua; 
    }

    public void Passada(bool p){
        if (passo != null)
        {                  
            if (p && !caixadesom[0].isPlaying)
            caixadesom[0].Play();
            caixadesom[0].loop=true;
            if(!p)
            caixadesom[0].Pause();
        }
    }

    public void Corrida(bool c){
        if(c)
        caixadesom[0].pitch = 2;

        if(!c)
        caixadesom[0].pitch = 1;
    }



    

    public void PularNaAgua(){
        if (pulo_agua != null)
            {
                caixadesom[1].PlayOneShot(pulo_agua);
            }
    }


    public void SairDaAgua(){
                if (pulo_agua != null)
            {
                caixadesom[1].Stop();
            }
    }
}
