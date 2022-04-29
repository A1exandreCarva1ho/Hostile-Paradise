using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aderencia : MonoBehaviour
{
    public GameObject ob;
    void OnCollisionEnter(Collision alvo){

        ContactPoint contact = alvo.contacts[0];
        Vector3 position = contact.point;

        Destroy(ob.GetComponent<Rigidbody>());
        Destroy(ob.GetComponent<CapsuleCollider>());
        transform.localPosition = position;
        transform.SetParent(alvo.transform, true);


       
    }
}
