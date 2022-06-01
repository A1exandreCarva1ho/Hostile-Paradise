using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Agrupamento : MonoBehaviour
{
    public GameObject inimigo = null;
    public Transform lider;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;
    public Transform pos9;
    public Transform pos10;
    public Transform pos11;
    public Transform pos12;
    public Transform pos13;
    public Transform pos14;
    public Transform pos15;

    public List<Vector3> posicionamento_membros = new List<Vector3>();

    // string comando_atual = "aguarda_instrução";


    public class MembroGrupo {
        public Vector3 posicionamento_membros;
        public GameObject nativo;
        public int id;

         public MembroGrupo(Vector3 vec, GameObject go, int i)
        {
            posicionamento_membros = vec;
            nativo = go;
            id = i;
        }
    }
    
    public List<MembroGrupo> membros = new List<MembroGrupo>();

    void Start(){
        posicionamento_membros.Add(pos1.position);
        posicionamento_membros.Add(pos2.position);
        posicionamento_membros.Add(pos3.position);
        posicionamento_membros.Add(pos6.position);
        posicionamento_membros.Add(pos7.position);
        posicionamento_membros.Add(pos8.position);
        posicionamento_membros.Add(pos11.position);
        posicionamento_membros.Add(pos12.position);
        posicionamento_membros.Add(pos13.position);
        posicionamento_membros.Add(pos4.position);
        posicionamento_membros.Add(pos5.position);
        posicionamento_membros.Add(pos9.position);
        posicionamento_membros.Add(pos10.position);
        posicionamento_membros.Add(pos14.position);
        posicionamento_membros.Add(pos15.position);
    }

    public void AdicionaMembro(GameObject nativo, int id){
        MembroGrupo membro = new MembroGrupo(pos1.position, nativo, id);
        if(membros.Count<=15){
            membros.Add(membro);
        }
    }

    public void RemoveMembro(){
      // tamanho_grupo=tamanho_grupo-1;
    }
    
    public void AtaqueEmGrupo(GameObject x){
        for (int i = 0; i<membros.Count;i++){
            membros[i].nativo.GetComponent<ControleNativo>().AtirarFlecha(x);
        }
        
    }

    public void ReposicionarGrupo(){
        for (int i = 0; i<membros.Count;i++){
            membros[i].nativo.GetComponent<ControleNativo>().Reposicionar();
        }
    }

    void Update()
    {

        if (Vector3.Distance(posicionamento_membros[5], lider.position)>7.5){
        posicionamento_membros[0]  = pos1.position;
        posicionamento_membros[1]  = pos2.position;
        posicionamento_membros[2]  = pos3.position;
        posicionamento_membros[3]  = pos4.position;
        posicionamento_membros[4]  = pos5.position;
        posicionamento_membros[5]  = pos6.position;
        posicionamento_membros[6]  = pos7.position;
        posicionamento_membros[7]  = pos8.position;
        posicionamento_membros[8]  = pos9.position;
        posicionamento_membros[9]  = pos10.position;
        posicionamento_membros[10] = pos11.position;
        posicionamento_membros[11] = pos12.position;
        posicionamento_membros[12] = pos13.position; 
        posicionamento_membros[13] = pos14.position;
        posicionamento_membros[14] = pos15.position;
        ReposicionarGrupo();
        }

    }
}
