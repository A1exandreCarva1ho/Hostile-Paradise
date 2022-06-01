using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiraPedra : MonoBehaviour
{

    public GameObject pedregulho;
    public GameObject alvo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I)){

            Vector3 direcao  = alvo.transform.position - gameObject.transform.position;

            GameObject Pedra = Instantiate(pedregulho, gameObject.transform.position, gameObject.transform.rotation);
            Pedra.transform.forward = direcao;
            Rigidbody rb = Pedra.GetComponent<Rigidbody>();
            rb.AddForce(direcao * 6 ,ForceMode.Impulse);
        }
    }
}
