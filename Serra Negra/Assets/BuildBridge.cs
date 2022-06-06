using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    [SerializeField]
    GameObject[] wood;
    public void Build()
    {
        for (int i = 0; i < wood.Length; i++)
        {
            wood[i].SetActive(true);
        }
    }
}
