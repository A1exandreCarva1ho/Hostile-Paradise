using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPegadas : MonoBehaviour
{

    public Transform pedir;

    public Transform peesq;

    public GameObject pegada_direita;

    public GameObject pegada_esquerda;

    public Terrain terreno;

    Vector3 posicao;

    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.W)){
            InvokeRepeating("DeixaPegadaDir", 0.0f, 1f);
            InvokeRepeating("DeixaPegadaEsq", 0.5f, 1f);
        } 

        if (Input.GetKeyUp(KeyCode.W)){
            CancelInvoke("DeixaPegadaDir");
            CancelInvoke("DeixaPegadaEsq");
        } 
    }

    void DeixaPegadaDir(){
        if(gameObject.GetComponentInParent<Movimento>().isGrounded == true){
            posicao = pedir.position;
            posicao.y = posicao.y + 0.04f;
            Instantiate(pegada_direita, posicao, pedir.rotation);
        }
    }

    void DeixaPegadaEsq(){
        if(gameObject.GetComponentInParent<Movimento>().isGrounded == true){
        posicao = peesq.position;
        posicao.y = posicao.y + 0.04f;
        Instantiate(pegada_esquerda, posicao, peesq.rotation);
        }
    }
}
