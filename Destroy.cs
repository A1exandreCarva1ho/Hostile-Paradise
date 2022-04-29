using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;


public class Destroy : MonoBehaviour
{
    public GameObject explosao;

    void OnCollisionEnter(Collision collision)
    {

            GameObject exp = Instantiate(explosao, transform.position, Quaternion.identity); 
            exp.GetComponent<ParticleSystem>().Play();          
            Destroy(this.gameObject);
    }
}

