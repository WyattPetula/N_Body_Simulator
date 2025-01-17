using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawn_Config : MonoBehaviour
{
    public GameObject config_prefab;
    public GameObject content_panel;

    public static int config_index = 0;

    public void Instantiate_Config()
    {
        // Create a new configation.
        GameObject new_config = Instantiate(config_prefab, content_panel.transform);

        // Load each button, input field, and dropdown child into this config panel's Config script.
        new_config.GetComponent<Config>().Load_Options();

        // Label the new config with a number.
        GameObject config_text_panel = new_config.transform.GetChild(0).gameObject;
        config_text_panel.GetComponent<TextMeshProUGUI>().text = "Configuration " + config_index.ToString();
        config_index++;
    }
}
