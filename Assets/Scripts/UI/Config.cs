using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Config : MonoBehaviour
{
    // Buttons, input fields, etc.
    private List<GameObject> input_areas = new List<GameObject>();

    // Storage variables
    public string config_enabled = "Active";
    public GameObject body_to_spawn;
    public GameObject parent_body;
    public int num_of_bodies = 10;
    public string spawn_distribution = "Random";
    public float clump_mult = 0.01f;
    public float clump_offset = 0.8f;
    public float orbit_type = 1;
    public float default_mass = 1;
    public float mass_var = 1;
    public float default_size = 1;
    public float size_var = 1;
    public float altitude_mult = 5;
    public float altitude_var = 1.075f;
    public float vertical_velocity = 0;

    void Start(){
        body_to_spawn = Resources.Load("Prefabs/Spheroid") as GameObject;
        parent_body = GameObject.Find("Celestial Body");
        config_enabled = "Active";
        num_of_bodies = 10;
        spawn_distribution = "Random";
        clump_mult = 0.01f;
        clump_offset = 0.8f;
        orbit_type = 1;
        default_mass = 1;
        mass_var = 1;
        default_size = 1;
        size_var = 1;
        altitude_mult = 5;
        altitude_var = 1.075f;
        vertical_velocity = 0;
    }

    // Called inside Spawn_Configs: Load config options when first instantiated
    public void Load_Options(){
        Transform inputs_container = transform.GetChild(0);
        foreach (RectTransform input_transform in inputs_container){
            input_areas.Add(input_transform.gameObject);
        }
    }

    // Update the config variables with the current inputs on the UI.
    public void Apply_Config_Changes(){
        // Whether to skip the config during instantiation.
        TMP_Dropdown c_enabler = input_areas[0].GetComponent<TMP_Dropdown>();
        config_enabled = c_enabler.options[c_enabler.value].text;

        // Object to spawn
        TMP_Dropdown name_dropdown = input_areas[1].GetComponent<TMP_Dropdown>();
        string spawn_name = name_dropdown.options[name_dropdown.value].text;
        
        if(spawn_name == "Circle"){
            body_to_spawn = Resources.Load("Prefabs/Spheroid") as GameObject;
        }
        else if(spawn_name == "Triangle"){
            body_to_spawn = Resources.Load("Prefabs/Triangle") as GameObject;
        }
        else if(spawn_name == "Square"){
            body_to_spawn = Resources.Load("Prefabs/Square") as GameObject;
        }
        else{
            body_to_spawn = Resources.Load("Prefabs/Bomb") as GameObject;
        }

        // Parent to spawn object around
        TMP_Dropdown parent_dropdown = input_areas[2].GetComponent<TMP_Dropdown>();
        parent_body = GameObject.Find(parent_dropdown.options[parent_dropdown.value].text);
        
        // Other inputs 1
        num_of_bodies = int.Parse(input_areas[3].GetComponent<TMP_InputField>().text);

        // Distribution dropdown
        TMP_Dropdown dist_dropdown = input_areas[4].GetComponent<TMP_Dropdown>();
        spawn_distribution = dist_dropdown.options[dist_dropdown.value].text;

        // Other inputs 2
        clump_mult = float.Parse(input_areas[5].GetComponent<TMP_InputField>().text);
        clump_offset = float.Parse(input_areas[6].GetComponent<TMP_InputField>().text);
        orbit_type = float.Parse(input_areas[7].GetComponent<TMP_InputField>().text);

        // Other inputs 3
        default_mass = float.Parse(input_areas[8].GetComponent<TMP_InputField>().text);
        mass_var = float.Parse(input_areas[9].GetComponent<TMP_InputField>().text);
        default_size = float.Parse(input_areas[10].GetComponent<TMP_InputField>().text);
        size_var = float.Parse(input_areas[11].GetComponent<TMP_InputField>().text);
        altitude_mult = float.Parse(input_areas[12].GetComponent<TMP_InputField>().text);
        altitude_var = float.Parse(input_areas[13].GetComponent<TMP_InputField>().text);
        vertical_velocity = float.Parse(input_areas[14].GetComponent<TMP_InputField>().text);
    }
}
