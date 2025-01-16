using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Config : MonoBehaviour
{
    public GameObject config_ui_object;
    private GameObject prev_config_panel;
    private GameObject new_config;
    public GameObject scrollview_content_object;

    private void Awake()
    {
        if (prev_config_panel != null)
        {
            new_config = Instantiate(config_ui_object, prev_config_panel.transform.position - new Vector3(0, 18, 0), Quaternion.identity, scrollview_content_object.transform);
        }
        else
        {
            new_config = Instantiate(config_ui_object, scrollview_content_object.transform.position, Quaternion.identity);
        }
        prev_config_panel = new_config;
    }
}
