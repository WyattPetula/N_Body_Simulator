using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apply_Config : MonoBehaviour
{
    public void Apply_Inputs(){
		GameObject config_panel = transform.parent.parent.gameObject;
        config_panel.GetComponent<Config>().Apply_Config_Changes();
	}
}
