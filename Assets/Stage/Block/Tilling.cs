using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilling : MonoBehaviour
{
    [SerializeField] Renderer renderer;
    [SerializeField] Transform transform;
    
    [SerializeField] float x;
    [SerializeField] float y;

    void Start()
    {
        // renderer = this.GetComponent<Renderer>();
        // transform = this.GetComponent<Transform>();
        SetTill();
    }

    public void SetTill(){
        //x=スケールからタイリングの値を取る処理
        // Debug.Log(transform);
        renderer.material.SetFloat("TilingX", transform.localScale.x);
        //y=スケールからタイリングの値を取る処理
        renderer.material.SetFloat("TilingY", transform.localScale.y);
    }

}
