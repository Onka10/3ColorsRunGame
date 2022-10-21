using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

[RequireComponent(typeof(Collider))]
public class DeadColider : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Collider>().OnTriggerEnterAsObservable()
        .Subscribe(x =>{
            if(x.gameObject.TryGetComponent<IPlayer>(out var player))  player.Miss();
        })
        .AddTo(this);   
        ZKeep.Z0(this.gameObject);
    }
}
