using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Goal : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] GameObject fireworks;

    void Start()
    {
        collider.OnTriggerExitAsObservable()
        .Subscribe(x =>{
            if(x.gameObject.TryGetComponent<IPlayer>(out var player)){
                player.Clear();
                Instantiate(fireworks,this.gameObject.transform.position,Quaternion.identity);
                Destroy(this.gameObject);
            }  
            
        })
        .AddTo(this); 
    }    
}
