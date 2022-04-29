using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    public GameObject ob;

    public float Speed;

    public Transform Cam;
    
    public Vector3 jump;
    public float jumpForce = 1.0f;
    public bool isGrounded;
    Rigidbody rb;

    Animacao anim;


    private Vector3 vector3Movews;
    private Vector3 vector3Movead;
    private bool submerso;


    void OnCollisionEnter(Collision terreno)
    {
        if (terreno.gameObject.tag == "terreno" && submerso == false){
            isGrounded = true;
            anim = ob.GetComponent<Animacao>();
            anim.Pular(false);
        } 
        
    }

    

    // Start is called before the first frame update
    void Start()
    {

        rb = ob.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {

        vector3Movews = new Vector3(0, 0, Input.GetAxis("Vertical"));
        vector3Movead = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        if(Input.GetKey(KeyCode.W)^Input.GetKey(KeyCode.S)){                // ou exclusivo (^) pra nao deixar o personagem andar com os 2 direcionais contrarios
        transform.Translate(vector3Movews * Speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D)^Input.GetKey(KeyCode.A)){
        transform.Translate(vector3Movead * Speed * Time.deltaTime);
        }


        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && isGrounded == true){
            ob.GetComponent<Sons>().Passada(true);
            if( Input.GetKey(KeyCode.LeftShift)){
                ob.GetComponent<Sons>().Corrida(true);
            }
            if( Input.GetKeyUp(KeyCode.LeftShift)){
                ob.GetComponent<Sons>().Corrida(false);
            }
        }
        else{
            ob.GetComponent<Sons>().Passada(false);
        }/*

        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 ) && isGrounded == true && Input.GetKeyDown(KeyCode.LeftShift)){
            ob.GetComponent<Sons>().Passada(false);
            ob.GetComponent<Sons>().Corrida(true);
        }
        else{
            ob.GetComponent<Sons>().Corrida(false);
        }*/


        Quaternion CharacterRotation;
        CharacterRotation = Cam.transform.rotation;
        CharacterRotation.x = 0;
        CharacterRotation.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation,CharacterRotation, .1f);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded==true && submerso == false){  
            anim.Pular(true);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if(Input.GetKey(KeyCode.Space) && submerso == true){
            transform.Translate(jump   * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftShift) && submerso == true){
            transform.Translate(-1*jump  * Time.deltaTime);
        }
        
    }

        void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "agua"){
            submerso = true;
            isGrounded = false;
            anim.Nadar(true);
            ob.GetComponent<Sons>().PularNaAgua();
        }
        
    }

    void OnTriggerStay(Collider col){
        if(col.gameObject.tag == "agua"){
            Physics.gravity = new Vector3(0, -0.01F, 0);
        }
    }   

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "agua"){
            submerso = false;
            Physics.gravity = new Vector3(0, -9.8F, 0);
            anim.Nadar(false);
            ob.GetComponent<Sons>().SairDaAgua();
        }

    }

}
