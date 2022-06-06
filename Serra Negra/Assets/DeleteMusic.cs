using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMusic : MonoBehaviour
{
    [SerializeField]string nameTag;
    public void Destroy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(nameTag);
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);            
        }
    }

}
