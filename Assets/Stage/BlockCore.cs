using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BlockCore : MonoBehaviour
{
    [SerializeField] ColorState color;
    [SerializeField] Material ON;
    [SerializeField] Material OFF;

    //キャッシュ
    [SerializeField] MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        ColorManager.I.OnColorStates
        .Subscribe(c => MoveStage(c))
        .AddTo(this);
    }

    void MoveStage(ColorState c){
        Vector3 pos = this.gameObject.transform.position;
        if(color == c){
            pos.z = 0;
            mesh.material = ON; 
            
        }        
        else{
            mesh.material = OFF;
            pos.z = 2;
        } 

        
        this.gameObject.transform.position = pos;
    }
}
