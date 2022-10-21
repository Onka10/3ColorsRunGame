using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Collider))]
public class Goal : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Collider>().OnTriggerExitAsObservable()
        .Subscribe(x =>{
            if(x.gameObject.TryGetComponent<IPlayer>(out var player)){
                player.Clear();
                Destroy(this.gameObject);
            }  
            
        })
        .AddTo(this);

        ZKeep.Z0(transform.root.gameObject);
    }    
}
