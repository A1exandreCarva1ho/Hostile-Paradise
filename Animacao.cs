using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{
    public GameObject obj;
    Animator anim;

    private int itemEquipadoId = 0;

    public bool atirando;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        

        anim.SetFloat("MouseVertical", Camera.main.GetComponent<CameraScript>().currentY);

        if ((Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))) // ou exclusivo (^) pra nao deixar andar em 2 direcoes contrarias
        {
            anim.SetBool("EstaAndando", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("EstaCorrendo", true);
                ControleVelocidade();
            }

            else
            {
                anim.SetBool("EstaCorrendo", false);
                ControleVelocidade();
            }
        }
        if (!Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.A)))
        {     
            anim.SetBool("EstaAndando", false);
            anim.SetBool("EstaCorrendo", false);
        }

        if(atirando){
            anim.SetBool("EstaAtirando",true);
        }
        if(!atirando){
            anim.SetBool("EstaAtirando",false);
        }


        if(Input.GetKeyDown(KeyCode.Mouse1)){
                if (itemEquipadoId == 1 || itemEquipadoId == 2){
                anim.SetBool("AtaqueFrontal",true);
                }
            }

        if(Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel")>0f||Input.GetAxis("Mouse ScrollWheel")<0f){
            itemEquipadoId = obj.GetComponent<Inventario>().GetItemEquipado();
            anim.SetInteger("IdArma", itemEquipadoId);
        }
        

    }

    public void FimAtaque(){
        anim.SetBool("AtaqueFrontal",false);
    }


    public void Pular(bool x){

        if(x==true){
        anim.SetBool("EstaPulando",true);
        }
        if(x==false){
        anim.SetBool("EstaPulando",false);
        }
    }


    void ControleVelocidade(){
        if (anim.GetBool("EstaCorrendo")==true){
            obj.GetComponent<Movimento>().Speed = 4;
        }
        if (anim.GetBool("EstaCorrendo")==false){
            obj.GetComponent<Movimento>().Speed = 2;
        }
    }

    public void Nadar(bool x){
        if(x)
        anim.SetBool("EstaNadando", true);
        if(!x)
        anim.SetBool("EstaNadando", false);
    }    


}
