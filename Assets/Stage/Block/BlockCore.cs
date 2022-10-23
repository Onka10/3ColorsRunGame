using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniRx;

public class BlockCore : MonoBehaviour
{
    [SerializeField] ColorState color = ColorState.Red;
    [SerializeField] private BlockMaterial _material = null;
    Material ON;
    Material OFF;
    [SerializeField] Collider missCollider;
    [SerializeField] Collider missCollider2;

    //キャッシュ
    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {   
        SetMesh();

        ColorManager.I.OnColorStates
        .Subscribe(c => MoveStage(c))
        .AddTo(this);
    }

    void MoveStage(ColorState c){
        Vector3 pos = this.gameObject.transform.position;
        if(color == c){
            pos.z = 0;
            mesh.material = ON;
            missCollider.enabled = true;
            missCollider2.enabled = true;
            
        }        
        else{
            pos.z = 2;
            mesh.material = OFF;
            missCollider.enabled = false;
            missCollider2.enabled = false;
        } 
        this.gameObject.transform.position = pos;
    }

    void SetMesh(){
        mesh = this.gameObject.GetComponent<MeshRenderer>();
        BlockMaterials selected;
        selected = _material.Blue;
        if(color == ColorState.Red) selected = _material.Red;
        else if(color == ColorState.Green) selected = _material.Green;
        ON = selected.On;
        OFF = selected.Off;
        mesh.material = OFF;
    }

    // [ContextMenu("更新")]
    public void Do(){
        SetMesh();
    }
}