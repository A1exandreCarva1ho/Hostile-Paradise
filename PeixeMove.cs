using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeMove : MonoBehaviour
{
    public GameObject Peixe;
    public float Raio;
     public float Velocidade;
    private Vector3 objetivo;

    private Vector3 AreaNado;

    public Quaternion trRot;
    public Quaternion obRot;

    // Update is called once per frame

    void Start(){
        AreaNado = transform.position;
        objetivo = AreaNado - Random.insideUnitSphere * Raio;
    }

    void Update()
    {
       /* Peixe.GetComponent<Animator>().SetFloat("Up", transform.eulerAngles.y); 
        Peixe.GetComponent<Animator>().SetFloat("Turn", transform.eulerAngles.x); 
        Peixe.GetComponent<Animator>().SetFloat("Forward", transform.forward.magnitude);    */

        Mover(true);

        if (Vector3.Distance(transform.position, objetivo) < 0.01f){  

            GetNewPos();
        }    

         if (Quaternion.Angle(trRot, obRot) >= 0.01f){
            Girar(true);
            Velocidade = 0.005f;
         }

          if (Quaternion.Angle(trRot, obRot) < 0.01f){
             Mover(true);
             Girar(false);
             Velocidade = 0.01f;
         }
    }

    public void Mover(bool m){
        if (m)
        transform.position = Vector3.MoveTowards(transform.position, objetivo, Velocidade);
    }

    public void Girar(bool g){

        if(g)
        transform.rotation = Quaternion.Lerp(transform.rotation , obRot, 10* 0.01f); // nao usar delta time pois da erro
    }
    public void  GetNewPos(){

        objetivo = AreaNado - Random.insideUnitSphere * Raio;
        trRot = transform.rotation;
        transform.LookAt(objetivo);
        obRot = transform.rotation;
        transform.rotation = trRot;
    }
}
