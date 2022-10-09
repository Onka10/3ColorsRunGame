using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public interface IPlayer
{
    void GameOver();
}


namespace Player
{
    public class PlayerManager : MonoBehaviour,IPlayer
    {
        public bool IsMove;
        [SerializeField] Collider collider;
        
        void Start()
        {
            collider.OnTriggerEnterAsObservable()
            .Throttle(TimeSpan.FromMilliseconds(10))
            .Subscribe(x =>{
                if(x.gameObject.TryGetComponent<ICoin>(out var coin))  coin.Get();
            })
            .AddTo(this);   

            IsMove = true;
        }

        public void GameOver(){
            Destroy(this.gameObject);
        }
    }
}

