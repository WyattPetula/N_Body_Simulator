using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDefenses : MonoBehaviour
{
    public GameObject bomb;
    private int bomb_count = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.B) && bomb_count > 0)
        {
            Instantiate(bomb, gameObject.transform.position - new Vector3(0, 1, 0), Quaternion.identity);
            bomb_count -= 1;
        }
    }
}
