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
    public string orbit_type = "Circular";
    public float default_mass = 1;
    public float mass_var = 1;
    public float default_size = 1;
    public float size_var = 1;
    public float altitude_mult = 5;
    public float altitude_var = 1.075f;
    public float vertical_velocity = 0;

    // Called inside Spawn_Configs: Load config options when first instantiated
    public void Load_Options(){
        Transform inputs_container = transform.GetChild(0);
        Debug.Log("Transform: " + inputs_container);
        foreach (RectTransform input_transform in inputs_container){
            input_areas.Add(input_transform.gameObject);
        }
        Debug.Log("TOTAL ESTE: " + input_areas.Count);
    }

    // Update the storage variables with the current inputs on the UI.
    public void Apply_Config_Changes(){
        // Whether to skip the config during instantiation.
        config_enabled = input_areas[0].GetComponent<UnityEngine.UI.Toggle>().isOn;
        Debug.Log("0");

        // Object to spawn
        Dropdown name_dropdown = input_areas[1].GetComponent<Dropdown>();
        string spawn_name = name_dropdown.options[name_dropdown.value].text;
        
        if(spawn_name == "Sphere"){
            body_to_spawn = Resources.Load("Assets/Resources/Prefabs/Spheroid") as GameObject;
        }
        else {
            body_to_spawn = Resources.Load("Assets/Resources/Prefabs/Spheroid") as GameObject;
        }

        // Parent to spawn object around
        Dropdown parent_dropdown = input_areas[2].GetComponent<Dropdown>();
        parent_body = GameObject.Find(parent_dropdown.options[parent_dropdown.value].text);
        
        // Other inputs 1
        num_of_bodies = int.Parse(input_areas[3].GetComponent<InputField>().text);
        spawn_distribution = input_areas[4].GetComponent<InputField>().text;
        clump_mult = float.Parse(input_areas[5].GetComponent<InputField>().text);
        clump_offset = float.Parse(input_areas[6].GetComponent<InputField>().text);

        // Orbit to spawn objects in
        Dropdown orbit_dropdown = input_areas[7].GetComponent<Dropdown>();
        orbit_type = orbit_dropdown.options[orbit_dropdown.value].text;

        // Other inputs 2
        default_mass = float.Parse(input_areas[8].GetComponent<InputField>().text);
        mass_var = float.Parse(input_areas[9].GetComponent<InputField>().text);
        default_size = float.Parse(input_areas[10].GetComponent<InputField>().text);
        size_var = float.Parse(input_areas[11].GetComponent<InputField>().text);
        altitude_mult = float.Parse(input_areas[12].GetComponent<InputField>().text);
        altitude_var = float.Parse(input_areas[13].GetComponent<InputField>().text);
        vertical_velocity = float.Parse(input_areas[14].GetComponent<InputField>().text);

        Debug.Log("Config saved successfully");
    }
}
