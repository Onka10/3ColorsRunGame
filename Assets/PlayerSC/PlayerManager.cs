using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public interface IPlayer
{
    void Miss();

    void Clear();
}


namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>,IPlayer
    {
        public bool IsMove;

        [SerializeField] Vector3 Respawn = new Vector3(0,1,0);

        [SerializeField]Material red;
        [SerializeField]Material green;
        [SerializeField]Material blue;
        [SerializeField]MeshRenderer mesh; 

        public PlayerData Data => _data;
		[SerializeField] private PlayerData _data = null;
        
        void Start()
        {
            this.gameObject.GetComponent<Collider>()
            .OnTriggerEnterAsObservable()
            .Throttle(TimeSpan.FromMilliseconds(10))
            .Subscribe(x =>{
                if(x.gameObject.TryGetComponent<ICoin>(out var coin))  coin.Get();
            })
            .AddTo(this);

            ColorManager.I.OnColorStates
            .Subscribe(c => ColorChange(c))
            .AddTo(this);

            InputManager.I.OnR
            .Subscribe(_ => Miss())
            .AddTo(this);

            IsMove = true;
        }

        void ColorChange(ColorState c){
            if(c==ColorState.Red) mesh.material = red;   
            else if(c==ColorState.Blue) mesh.material = blue;
            else if(c==ColorState.Green) mesh.material = green;
        }

        public void Miss(){
            // Destroy(this.gameObject);
            this.gameObject.transform.position = Respawn;
        }

        public void Clear(){
            IsMove = false;
        }
    }
}

