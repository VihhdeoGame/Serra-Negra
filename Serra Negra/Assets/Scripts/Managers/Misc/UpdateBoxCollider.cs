using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBoxCollider : MonoBehaviour
{
    BoxCollider2D box;
    Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<RectTransform>().rect.size;
        box = GetComponent<BoxCollider2D>();
        box.size = size;
    }
    
}
