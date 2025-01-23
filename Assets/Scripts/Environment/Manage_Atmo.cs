using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_Atmo : MonoBehaviour
{
    private float alpha = 1;
    private float b = 0.8275025f;
    private float g = 1;
    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6556604f, b, g, alpha);
    }
    public void HeatAtmo(){
        if(alpha > 0){
            alpha -= 0.01f;
            b -= 0.01f;
            g -= 0.01f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6556604f, b, g, alpha);
        }
    }
    public void ResetAtmo(){
        alpha = 1;
        b = 0.8275025f;
        g = 1;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6556604f, b, g, alpha);
    }
}
