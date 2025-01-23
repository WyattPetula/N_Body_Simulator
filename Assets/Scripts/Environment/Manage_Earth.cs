using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_Earth : MonoBehaviour
{
    private float saturation = 1;
    void Start(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(15/360,saturation/100,1); 
    }

    public void HeatEarth(){
        if(saturation < 100){
            saturation++;
            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(15/360, saturation/100, 1);
        }
    }
    public void ResetEarth(){
        saturation = 1;
        gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(15/360,saturation/100,1);
    }
}
