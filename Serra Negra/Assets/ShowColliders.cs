 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class ShowColliders : MonoBehaviour
 {
     BoxCollider boxCollider;

     void OnDrawGizmos() 
     {
         boxCollider = GetComponent<BoxCollider>();
         Gizmos.color = Color.yellow;
         Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
     }
 }