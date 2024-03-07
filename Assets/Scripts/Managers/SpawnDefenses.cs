using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefenses : MonoBehaviour
{
    public GameObject shipGraphics;
    public GameObject bomb;
    private int bomb_count = 3;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.B) && bomb_count > 0)
        {
            Vector3 spawnPos = shipGraphics.transform.position - shipGraphics.transform.up;
            Instantiate(bomb, spawnPos, gameObject.transform.rotation);
            bomb_count -= 1;
        }
    }
}
