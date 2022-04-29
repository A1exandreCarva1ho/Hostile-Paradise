using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
public GameObject Jogador; 
public GameObject MaoArco;
public GameObject MaoLanca;  

public GameObject Spawn;
public GameObject Arma; 

public GameObject ArcoMedio;
public GameObject Bola;
private string itemEquipado = "";
private float mw = 0;
private string maovazia = "empty";
List<string> itens = new List<string>();

public void Start(){
itens.Add(maovazia);
} 


    public class Invent {
        private string nome;

        private bool singular;
        private Texture2D foto;
        private int quant;

    }

    public Invent elem1 = new Invent();

    public string OlhaInventario (){
        if (itens.Count >0){
        string x = itens[0];
        return x;
        }
        else {
        return " ";
        }
    }
    public void AddInventario (string a){         // adiciona os itens coletados ao meu inventário em uma lista.
        string nome = a;
        itens.Add(a);
        itemEquipado = itens[0]; 


        if (itemEquipado.Contains("ArcoMedio")){
            Jogador.GetComponent<LineRenderer>().enabled=true;
            Jogador.GetComponent<CordaArco>().enabled=true;  
            MaoArco.SetActive(true);      
        }

        if (itemEquipado.Contains("lança")){        
            MaoLanca.SetActive(true);
        }

    }

    public void RodaInventario (int x){

        List<string> itens2 = new List<string>();

        if (itens.Count!=0){
            if (x==1){                          //scroll pra frente
                var a = itens[0];
                itens.RemoveAt(0);
                itens.Add(a);

            }

            if(x==-1){                         //scroll pra trás
                var a = itens[itens.Count-1];
                itens2.Add(a);
                itens.RemoveAt(itens.Count-1);
                itens2.AddRange(itens);
                itens = itens2;
            }

            itemEquipado = itens[0];     
            
            if (itemEquipado.Contains("ArcoMedio")){
                Jogador.GetComponent<LineRenderer>().enabled=true;
                Jogador.GetComponent<CordaArco>().enabled=true;
                MaoArco.SetActive(true);  

            }
            if (!itemEquipado.Contains("ArcoMedio")){
                Jogador.GetComponent<LineRenderer>().enabled=false;
                Jogador.GetComponent<CordaArco>().enabled=false;
                MaoArco.SetActive(false);  

            }

            if (itemEquipado.Contains("lança")){        
                MaoLanca.SetActive(true); 
            }

            if (!itemEquipado.Contains("lança")){        
                MaoLanca.SetActive(false);
            }

        }
    }


    public int GetItemEquipado(){

        if (itemEquipado.Contains("ArcoMedio")){
            return 2;
        }
        if (itemEquipado.Contains("lança")){
            return 1;
        }
        else 
        return 0;
    }

    public Texture2D inventario;
    Rect position;

    void Update()
    {
            if (Input.GetKeyUp(KeyCode.F)){

                if (itens.Count > 0){
                    if (itens[0].Contains("Sphere")){
                        GameObject NovoArma = Instantiate(Bola, Spawn.transform.position, Quaternion.identity);
                    }
                    if (itens[0].Contains("lança")){
                        GameObject NovoArma = Instantiate(Arma, Spawn.transform.position, Quaternion.identity);
                        MaoLanca.SetActive(false);
                    }  
                    if (itens[0].Contains("Arco")){
                        GameObject NovoArma = Instantiate(ArcoMedio, Spawn.transform.position, Quaternion.identity);
                        Jogador.GetComponent<LineRenderer>().enabled=false;
                        Jogador.GetComponent<CordaArco>().enabled=false; 
                        MaoArco.SetActive(false);
                    }

                    if (itens[0] != maovazia){                 
                        itens.RemoveAt(0);
                    }
                }
            }
        position = new Rect((Screen.width - inventario.width) / 2, ((Screen.height - inventario.height) / 2) + 240 , inventario.width, inventario.height);
        
        mw = Input.GetAxis("Mouse ScrollWheel");

        if (mw<0){
        RodaInventario (-1); //scroll pra trás
        mw=0;
        }

        if (mw>0){
        RodaInventario (1); //scroll pra frente
        mw=0;
        }


    }
    void OnGUI()
    {
        GUI.DrawTexture(position, inventario);
    }

}
