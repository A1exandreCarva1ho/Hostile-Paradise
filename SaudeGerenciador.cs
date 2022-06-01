using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaudeGerenciador : MonoBehaviour
{
    public Slider barra_Vida;
    public string nome;
    public float vida = 1000.0f;
    public float defesa = 9.8f;
    public float danoBase = 10.0f;
    public float velMov = 10.0f;
    public float freqAtk = 2.0f;
    public bool vivo = true;
    public GameObject alvo = null;

    public GameObject materialHolder;
    Material mat;

    Animator anim;

    float taxaDissolver = -1f;

    void Start(){
        barra_Vida.maxValue = vida;
        anim = gameObject.GetComponent<Animator>();
            if (materialHolder !=null){
                mat = materialHolder.GetComponent<SkinnedMeshRenderer>().material;
            }
    }
    void Morrer(){
        // animação de morte rolar 
        //gameObject.SetActive(false);

        StartCoroutine (Decompor());

    }

    void Update(){
        if (vivo == false){
        barra_Vida.enabled = false;
        taxaDissolver = taxaDissolver + Time.time *.00005f;
        mat.SetFloat("_Dissolver", taxaDissolver);
        }

        if (mat.GetFloat("_Dissolver")>=1){
            gameObject.SetActive(false);
        }


        barra_Vida.value = Mathf.Lerp(barra_Vida.value, vida, Time.time/1000);
        

    }

    IEnumerator Decompor(){
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(3);
        vivo = false;
    }

    void RecebeDano(float dano){
        anim.SetTrigger("Take_Damage_2");
        if (defesa < dano ){
        vida = vida - (dano - defesa);
        }
        //barra_Vida.value = vida;
        if (vida <= 0){
            Morrer();
        }

    }
    
    void OnCollisionEnter(Collision col){
        if (col.gameObject.layer  == LayerMask.NameToLayer("Projetil")){
            RecebeDano(10);
            
        }
    }



}
