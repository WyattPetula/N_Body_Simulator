using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Config : MonoBehaviour
{
    public void Remove_Config()
    {
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
