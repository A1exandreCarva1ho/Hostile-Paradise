using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegaLista : MonoBehaviour
{
    public GameObject isto;
    public GameObject jogador;
    private string texto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texto = jogador.GetComponent<Inventario>().OlhaInventario();
        isto.GetComponent<Text>().text = texto;

    }
}