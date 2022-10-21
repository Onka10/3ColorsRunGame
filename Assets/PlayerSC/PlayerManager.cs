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
    public class PlayerManager : Singleton<PlayerManager>, IPlayer
    {
        public bool IsMove;

        [SerializeField] private Vector3 RespawnPoint = new Vector3(0, 1, 0);
        [SerializeField] private GameObject fireworks;

        public PlayerData Data => _data;
        [SerializeField] private PlayerData _data = null;

        public PlayerMaterials Mat => _material;
        [SerializeField] private PlayerMaterials _material = null;

        public IReadOnlyReactiveProperty<PlayerMaterial> NowMaterial => nowMaterial;
        private readonly ReactiveProperty<PlayerMaterial> nowMaterial = new ReactiveProperty<PlayerMaterial>();
        public IObservable<Unit> OnMiss => _miss;
        private readonly Subject<Unit> _miss = new Subject<Unit>();

        public IObservable<Unit> OnPlay => _play;
        private readonly Subject<Unit> _play = new Subject<Unit>();

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
            PlayerMaterial mat;

            if(c==ColorState.Red)  mat = _material.Red;  
            else if(c==ColorState.Blue) mat = _material.Blue;
            else mat = _material.Green;
        
            nowMaterial.Value = mat;
        }

        public void Miss()
        {
            IsMove = false;
            StartCoroutine(PlayDeathEffect()); 
        }

        IEnumerator PlayDeathEffect()  
        {
            _miss.OnNext(Unit.Default);
            yield return new WaitForSeconds(1f);
            ReStart();
        }


        void ReStart(){
            _play.OnNext(Unit.Default);
            gameObject.transform.position = RespawnPoint;
            IsMove = true;
        }

        public void Clear()
        {
            IsMove = false;
            GameObject fire = Instantiate(fireworks, gameObject.transform.position, Quaternion.identity);
            ZKeep.Z0(fire);
            GoalEffect.I.ClearText();
        }
    }
}

