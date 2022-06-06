using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameCanvas : MonoBehaviour
{
    [SerializeField]
    private GenericCanvas[] canvases;
    public GenericCanvas[] Canvases{get{return canvases;}}
    private void Awake() 
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].FirstInitialize(this);
        }
    }
}
