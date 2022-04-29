using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMira : MonoBehaviour
{ 
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    public LayerMask mascara; 
    private Transform selecaoNormal;
    public bool grab; // determinará se o objeto é pegável ou não pra mudar o simbolo da crosshair

    float distancia;
    void Update(){

        if(selecaoNormal != null && selecaoNormal.CompareTag("item")){
            grab = false;
            var selecaoRenderer = selecaoNormal.GetComponentInChildren<MeshRenderer>();
            //for (int i = 0; i<selecaoRenderer.materials.Length;i++){
                      //  if (selecaoRenderer.materials[i] != null){
                      //  selecaoRenderer.materials[i] = defaultMaterial;   
                     //   }
                     selecaoRenderer.material = defaultMaterial;
                    //}
        }

        var raio = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        RaycastHit hit;


        if(Physics.Raycast(raio, out hit, 5.0f, mascara)){
            var selecao = hit.transform;
            if(selecao.CompareTag("item")){  
                grab = true;
                var selecaoRenderer = selecao.GetComponentInChildren<MeshRenderer>();
                  //  for (int i = 0; i<selecaoRenderer.materials.Length;i++){
                   //     selecaoRenderer.materials[i] = highlightMaterial;   
                        defaultMaterial=selecaoRenderer.material;
                        selecaoRenderer.material = highlightMaterial; 
                        
                        if(Input.GetKey(KeyCode.E)){
                            this.GetComponent<Inventario>().AddInventario(hit.transform.gameObject.name);
                            Destroy(hit.transform.gameObject);
                            grab = false;
                        }
                        
                   // }
                
            }
            selecaoNormal = selecao;
        }

    }
    
}
