using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearInventory : MonoBehaviour
{
    GameObject inventory;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("IManager");
        if(inventory != null)
            Destroy(inventory);
    }
}
