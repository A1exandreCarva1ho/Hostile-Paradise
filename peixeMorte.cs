using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peixeMorte : MonoBehaviour
{
    Rigidbody rb;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision arma){

        if(arma.gameObject.layer == 6){
            rb.isKinematic = false;
            rb.useGravity = true;
            GetComponent<Animator>().enabled = false;
            GetComponent<PeixeMove>().enabled = false;
            rb.AddForce(0,-1,0,ForceMode.Impulse);
            gameObject.tag = "item";
        }
       
    }
}
