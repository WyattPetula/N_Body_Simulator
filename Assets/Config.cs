using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Config : MonoBehaviour
{
    // Buttons, input fields, etc.
    private List<GameObject> input_areas = new List<GameObject>();

    // Storage variables
    public bool config_enabled = true;
    public GameObject body_to_spawn = null;
    public GameObject parent_body = null;
    public int num_of_bodies = 10;
    public string spawn_distribution = "Random";
    public float clump_mult = 0.01f;
    public float clump_offset = 0.8f;
    public float default_mass = 1;
    public float mass_var = 1;
    public float default_size = 1;
    public float size_var = 1;
    public float altitude_mult = 5;
    public float altitude_var = 1.075f;
    public float vertical_velocity = 0;

    public void Load_Options(){
        Transform inputs_container = transform.GetChild(0);
        foreach (Transform child in inputs_container){
            input_areas.Add(child.gameObject);
        }
        Debug.Log(input_areas);
    }
    public void Apply_Config_Changes(){
        config_enabled = input_areas[0].GetComponent<UnityEngine.UI.Toggle>().isOn;
        string spawn_name = input_areas[1].GetComponent<DropdownField>().value;
        if(spawn_name == "Sphere"){
            body_to_spawn = Resources.Load("Assets/Resources/Prefabs/Spheroid") as GameObject;
        }
        parent_body = GameObject.Find(input_areas[2].GetComponent<DropdownField>().value);
        
        num_of_bodies = int.Parse(input_areas[3].GetComponent<InputField>().text);
        spawn_distribution = input_areas[4].GetComponent<InputField>().text;
        clump_mult = float.Parse(input_areas[5].GetComponent<InputField>().text);
        clump_offset = float.Parse(input_areas[6].GetComponent<InputField>().text);
        default_mass = float.Parse(input_areas[7].GetComponent<InputField>().text);
        mass_var = float.Parse(input_areas[8].GetComponent<InputField>().text);
        default_size = float.Parse(input_areas[9].GetComponent<InputField>().text);
        size_var = float.Parse(input_areas[10].GetComponent<InputField>().text);
        altitude_mult = float.Parse(input_areas[11].GetComponent<InputField>().text);
        altitude_var = float.Parse(input_areas[12].GetComponent<InputField>().text);
        vertical_velocity = float.Parse(input_areas[13].GetComponent<InputField>().text);
    }
}
