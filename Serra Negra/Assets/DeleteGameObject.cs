using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObject : MonoBehaviour
{
    public void DeleteObject()
    {
        Destroy(this.gameObject);
    }
}
