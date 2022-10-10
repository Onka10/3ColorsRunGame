using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Collider))]
public class Goal : MonoBehaviour
{
    [SerializeField] GameObject fireworks;

    void Start()
    {
        this.gameObject.GetComponent<Collider>().OnTriggerExitAsObservable()
        .Subscribe(x =>{
            if(x.gameObject.TryGetComponent<IPlayer>(out var player)){
                player.Clear();
                Instantiate(fireworks,this.gameObject.transform.position,Quaternion.identity);
                Destroy(this.gameObject);
            }  
            
        })
        .AddTo(this);

        ZKeep.Z(transform.root.gameObject);
    }    
}
