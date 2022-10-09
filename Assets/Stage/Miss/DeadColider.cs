using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;


public class DeadColider : MonoBehaviour
{
        [SerializeField] Collider collider;

        void Start()
        {
            collider.OnTriggerEnterAsObservable()
            .Subscribe(x =>{
                if(x.gameObject.TryGetComponent<IPlayer>(out var player))  player.GameOver();
            })
            .AddTo(this);   
        }
}
