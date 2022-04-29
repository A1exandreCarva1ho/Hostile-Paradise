using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{

    public Texture2D crosshair;
    public Texture2D crosshair2;
    public Rect position;

    private Texture2D ch;


    void Start(){
        Cursor.lockState = CursorLockMode.Locked; 
    }
    void Update()
    { 
        if(transform.GetComponent<ControleMira>().grab == true){
            ch = crosshair2;
        }
        else{
            ch = crosshair;
        }
        position = new Rect((Screen.width - ch.width) / 2, (Screen.height - ch.height) / 2, ch.width, ch.height);
    }
    void OnGUI()
    {
        GUI.DrawTexture(position, ch);
    }
}