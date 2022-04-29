using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CordaArco : MonoBehaviour
{
    public Transform pontaA;
    public Transform pontaB;
    public Transform dedinho;
    private LineRenderer linha;
    private Vector3 pos;
    private Vector3 defpos;

    private bool tensionado = false;
    void Start()
    {
    linha = GetComponent<LineRenderer>();
    pos = linha.GetPosition(1);
    defpos=pos;
    }

    public void PegaCorda(){
         tensionado = true;
    }

    void Update()
    {
        linha.SetPosition(0, pontaA.position);

        if (tensionado)
        linha.SetPosition(1, dedinho.position);

        if (!tensionado)
        linha.SetPosition(1, pontaA.position);

        linha.SetPosition(2, pontaB.position);

        if(Input.GetMouseButtonUp(0)){
            tensionado = false;
        }
    }
}
