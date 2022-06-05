using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCamp : MonoBehaviour
{
    Rigidbody body;
    BoxCollider boxCollider;
    [SerializeField]
    GameObject particles;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }
    public void TurnOff()
    {
        particles.SetActive(false);
        boxCollider.enabled = false;
        body.detectCollisions = false;
    }
}
