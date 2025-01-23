using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefenses : MonoBehaviour
{
    public GameObject shipGraphics;
    public GameObject bomb;
    void Update()
    {
        // Spawn bombs from the player.
        if(Input.GetKeyDown(KeyCode.B))
        {
            Vector3 spawnPos = shipGraphics.transform.position - shipGraphics.transform.up;
            Instantiate(bomb, spawnPos, gameObject.transform.rotation);
        }
    }
}
