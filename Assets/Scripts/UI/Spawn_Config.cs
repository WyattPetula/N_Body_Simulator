using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Config : MonoBehaviour
{
    public GameObject config_prefab;
    public GameObject content_panel;

    public void Instantiate_Config()
    {
        Instantiate(config_prefab, content_panel.transform);
    }
}
