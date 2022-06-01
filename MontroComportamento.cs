using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MontroComportamento : MonoBehaviour
{
    public Transform arenaMonstro;

    public float range = 200;
    Animator anim;
    public NavMeshAgent agent;

    Vector3 destino;


    Vector3 pontoAleatorio;

    bool TemObjetivo = true;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        pontoAleatorio = new Vector3(Random.Range(-range,range),transform.position.y,Random.Range(-range,range)) + arenaMonstro.position; 
    }

    void Update()
    {

        if (TemObjetivo){
            destino = pontoAleatorio;
            agent.SetDestination(destino);
        }

        if(Vector3.Distance(transform.position,destino)<5 && TemObjetivo == true){
            StartCoroutine(EscolheDestino());
            Debug.Log("trocandoRota");
        }

        if(gameObject.GetComponent<SaudeGerenciador>().vida <= 0){
            agent.isStopped = true;
        }
        
        anim.SetFloat("Speed",agent.velocity.magnitude);

    }

    IEnumerator EscolheDestino(){
        TemObjetivo = false;
        yield return new WaitForSeconds (Random.Range(4,10));
        pontoAleatorio = new Vector3(Random.Range(-range,range),transform.position.y,Random.Range(-range,range)) + arenaMonstro.position;
        TemObjetivo = true;
    }

}
