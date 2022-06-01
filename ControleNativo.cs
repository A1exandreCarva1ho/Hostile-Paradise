using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action{
        public string tipo;
        public Vector3 objetivo;
        public GameObject alvo;

         public Action(string a)
        {
            tipo = a;
        }
         public Action(string a, Vector3 b)
        {
            tipo = a;
            objetivo = b;
        }
         public Action(string a, GameObject b)
        {
            tipo = a;
            alvo = b;
        }

    }

public class ControleNativo : MonoBehaviour
{

    public Transform Player;
    public Transform mao; 
    public NavMeshAgent agent;
    public Vector3 destination;
    public GameObject projectile;
    GameObject inimigo;
    public bool tem_grupo = false;
    int meu_id;

    Animator anim;
    float speed;
    
    public GameObject saudevisivel;

    int flechas = 20;
    bool emLugarFixo = true;
    /*bool andando = false;
    bool noAr = false;
    bool correndo = false;
    bool ocupado = false;
    bool atacando = false;
    bool sendoAtacado = false;
    */
    public List<Action> Agenda = new List<Action>();

    void Start(){
        anim = gameObject.GetComponent<Animator>();
        saudevisivel.SetActive(false);   
    }


    IEnumerator TempoDeEspera()
    {
        float time = Random.Range(1,4);
        yield return new WaitForSeconds(time);
    }

    void ExecutaAgenda(){

        StartCoroutine(TempoDeEspera());

        Debug.Log(Agenda.Count);
        switch (Agenda[0].tipo)
        {
        case "mover":
        var caminho =  Agenda[0].objetivo;
        caminho.y = transform.position.y;
        transform.LookAt(caminho);
        agent.SetDestination(Agenda[0].objetivo);

        if(Vector3.Distance(transform.position,Agenda[0].objetivo)<1){
            Agenda.RemoveAt(0);
        }
        break;

        case "atacar":
        inimigo = Agenda[0].alvo;
        var alvejado =  inimigo.transform.position;
        alvejado.y = transform.position.y;
        transform.LookAt(alvejado);
        tiro();
        if(Agenda[0].alvo.GetComponentInParent<SaudeGerenciador>().vida <= 0){
            PararTiro();
            Agenda.RemoveAt(0);
        }
        break;

        case "Fugir":
        
        break;
        }
    }


    public void Reposicionar(){
        destination = Player.GetComponent<Agrupamento>().posicionamento_membros[meu_id];
        Agenda.RemoveAll(x => x.tipo == "mover");
        Agenda.Add(new Action("mover",destination));
    }

    void Update()
    {
        
        if (Agenda.Count>0){
        ExecutaAgenda();
        }

        if(flechas <= 0){
        anim.SetBool("TemFlechas", false);        
        }

        if (speed < 0.1 ){
            emLugarFixo = true;
        }
        if (speed > 0.1 ){
            emLugarFixo = false;
        }

        if (inimigo != null){

            
        }

        /*  if (anim.GetCurrentAnimatorStateInfo(1).IsName("base1")){
             ocupado = false;
             Debug.Log("ah");
        }

        if(ocupado == false){
            Agir();
            ocupado = true;
        }
        

        if(tem_grupo == true){
            destination = Player.GetComponent<Agrupamento>().posicionamento_membros[meu_id];

            if(anim.GetBool("PodeMover") == true){


            Agenda.Add(new Action("mover",destination));    
            StartCoroutine(IniciaDestino());
            }
            else{
            anim.SetTrigger("Levantar");
            }

        }*/

        speed = agent.velocity.magnitude;
        anim.SetFloat("speed", speed);
    }
    public void Recrutar(int id){

        if (tem_grupo == false){
        Player.GetComponent<Agrupamento>().AdicionaMembro(gameObject, id);
        tem_grupo = true;
        meu_id = id;
        saudevisivel.SetActive(true);
        }

    }
    public void  Dispensar(){
        tem_grupo = false;
    }


    public void AtirarFlecha(GameObject alvo)
    {
        Agenda.Add(new Action("atacar", alvo));

    }

    public void tiro(){
        anim.SetBool("atirando", true);
    }

    public void SpawnaFlecha(){        
        float espalhamento = 1.6f;
        float força = 3f;
        Vector3 direcao = inimigo.transform.position - mao.position;
        Quaternion lookRotation = Quaternion.LookRotation(direcao);
        direcao.x += Random.Range(-espalhamento, espalhamento);
        direcao.y += Random.Range(-espalhamento, espalhamento);
        direcao.z += Random.Range(-espalhamento, espalhamento);
        GameObject Tiro = Instantiate(projectile, mao.position, lookRotation);
        Rigidbody rb = Tiro.GetComponent<Rigidbody>();
        rb.AddForce(direcao * força, ForceMode.Impulse);
        flechas --;
        Debug.Log(flechas);
        }

    public void PararTiro(){
      anim.SetBool("atirando",false);  
    }


    public void RestringeMovimento(){
      anim.SetBool("PodeMover",false);  

      Debug.Log("estouparado");
    }

    public void PermiteMovimento(){
      anim.SetBool("PodeMover",true);  
      Debug.Log("posso andar");
    }

    public void Desocupa() {
       // ocupado = false;
    }

        //anim.SetTrigger("Sentar");
 

       // anim.SetTrigger("Levantar");


    public void Agir(){
/*
    anim.SetTrigger("RandonMove");

        int number = Random.Range(1,8);
        switch (number)
        {
        case 1:
        anim.SetTrigger("T1");
        break;

        case 2:
        anim.SetTrigger("T2");
        break;

        case 3:
        anim.SetTrigger("T3");
        break;

        case 4:
        anim.SetTrigger("T4");
        break;

        case 5:
        anim.SetTrigger("T5");
        break;

        case 6:
        anim.SetTrigger("T6");
        break;

        case 7:
        anim.SetTrigger("T7");
        break;

        }*/
    }
}
