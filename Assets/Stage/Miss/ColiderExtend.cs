using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ColiderExtend : MonoBehaviour
{
    [SerializeField] Transform transform;
    BoxCollider collider;
    void Start()
    {
        collider = this.gameObject.GetComponent<BoxCollider>();

        ColliderFix();
    }

    void ColliderFix(){
        // Vector3 size = transform.localScale;
        // size.x *= 0.8f;
        // size.y *= 0.8f;
        // collider.size = size;

    }
}
