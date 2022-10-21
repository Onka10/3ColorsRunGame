using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] MeshRenderer mesh;
        PlayerManager manager;

        void Start(){
            manager = PlayerManager.I;

            manager.NowMaterial
            .Subscribe(m => SetMaterial(m))
            .AddTo(this);

            manager.OnMiss
            .Subscribe(_ => Miss())
            .AddTo(this);

            manager.OnPlay
            .Subscribe(_ => Play())
            .AddTo(this);
        }

        void SetMaterial(PlayerMaterial m){
            mesh.material = m.Player;
        }

        void Miss(){
            mesh.enabled = false;
            GameObject miss = Instantiate(manager.NowMaterial.Value.Death, gameObject.transform.position, Quaternion.identity);
            ZKeep.Z0(miss);
        }

        void Play(){
            mesh.enabled = true;
        }

    }
}

