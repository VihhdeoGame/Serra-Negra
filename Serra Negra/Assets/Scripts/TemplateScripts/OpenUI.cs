using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    private Transform display;
    private void OnMouseDown()
    {
        display.gameObject.SetActive(true);
    }
}
