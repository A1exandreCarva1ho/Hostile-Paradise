
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    //[RequireComponent(typeof(AudioSource))]
    public class Atirar : MonoBehaviour
    {
        public Camera cam;
        public Transform mao;                      //Ponto que determina o disparo (ponta da 2°arma)
        public LayerMask mascara;                   //verifica se tem algo colidindo se nao atira pro infinito Layers pra não acertar o layer (player)

        public float speed = .01f;                   //velocidade do míssil
        public float firerate = .1f;                //velocidade de taxa de tiro da arma simples
        public float danoBala = .2f;
        public float espalhamento = 0.02f;          //taxa pela qual o tiro se espalha após sair da arma

        /*public AudioClip mySound;
        public AudioClip mySound2;
        public AudioSource mySource;
        public AudioSource mySource2;
        private AudioSource[] sons;
        */

        public GameObject tiroParede;               //Marca do tiro na parede

        public GameObject tela;

        //public GameObject luzdotiro;
        
        public GameObject tracante;                 //tracejado da bala no ar
        public GameObject projectile;               //Prefab do míssil

        public GameObject player;

        public GameObject ob;
        Animacao anim;

        Slider slider;

        float força;

        void Start()
        {
                cam = Camera.main;
                /*sons = GetComponents<AudioSource>();
                mySource = sons[0];
                mySource2 = sons[1];
                mySource.clip = mySound;
                mySource2.clip = mySound2;*/   
                anim = ob.GetComponent<Animacao>();
                slider = tela.GetComponentInChildren<Slider>(); 
        }

        void PoderFlecha(){
            slider.value = slider.value + 0.01f;
            if (slider.value > 1)
            slider.value = 1;
        }



        void Update()
        {
                if (Input.GetKeyDown(KeyCode.Mouse0)){

                    if (player.GetComponent<Inventario>().GetItemEquipado() == 2){
                        InvokeRepeating("PoderFlecha", .01f, .02f);
                        anim.atirando = true;
                    }
                }


                if (Input.GetKeyUp(KeyCode.Mouse0)){
                    if (player.GetComponent<Inventario>().GetItemEquipado() == 2){
                        CancelInvoke("PoderFlecha");
                        força = slider.value;
                        if(slider.value>0.4f){
                            AtirarFlecha();
                        }
                        slider.value = 0;
                        anim.atirando = false;
                    }
                }

        }

   
        public void AtirarFlecha()
        {
            /*if (mySound != null)
            {
                mySource.PlayOneShot(mySound);
            }*/

            Ray crosshair = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            Vector3 aimPoint;

            if (Physics.Raycast(crosshair, out hit, Mathf.Infinity, mascara))
            {
                aimPoint = hit.point;
            }
            else
            {
                aimPoint = crosshair.origin + crosshair.direction * 100;
            }

            Vector3 direcao = aimPoint - mao.position;

            direcao.x += Random.Range(-espalhamento, espalhamento);
            direcao.y += Random.Range(-espalhamento, espalhamento);
            direcao.z += Random.Range(-espalhamento, espalhamento);
            GameObject Tiro = Instantiate(projectile, mao.position, cam.transform.rotation);
            Rigidbody rb = Tiro.GetComponent<Rigidbody>();
             rb.AddForce(direcao * speed * força, ForceMode.Impulse);
            
         }

    }