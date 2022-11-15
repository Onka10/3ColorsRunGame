using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ColiderExtend : MonoBehaviour
{
    [SerializeField] Transform transform;
    BoxCollider collider;
    [SerializeField] Space space = Space.TopDown;

    enum Space{
        TopDown,
        Side
    }
    void Start()
    {
        collider = this.gameObject.GetComponent<BoxCollider>();

        ColliderFix();
    }

    void ColliderFix(){
        Vector3 ScaleSize = transform.localScale;
        Vector3 ColCenter = collider.center;
        Vector3 tmp;

        if(space == Space.TopDown){
            var y = 0.3f / ScaleSize.y;
            tmp = new Vector3(1,y,1);
            collider.size = tmp;
            return;
        }else if(space == Space.Side){
            var x = 0.3f / ScaleSize.x;
            tmp = new Vector3(x,1,1);
            collider.size = tmp;
            return;
        }
    }
}
