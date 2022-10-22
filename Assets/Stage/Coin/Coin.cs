using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UniRx;

public interface ICoin
{
    void Get();
}

public class Coin : MonoBehaviour,ICoin
{
    PlayerManager manager;

    void Start()
    {
        manager = PlayerManager.I;
        manager.OnPlay
        .Subscribe(_ => Play())
        .AddTo(this);

        PositionMove.Z0(this.gameObject);
    }

    public void Get(){
        ScoreManager.I.AddScore();
        PositionMove.ZBack(this.gameObject);
    }

    void Play(){
        PositionMove.Z0(this.gameObject);
    }
}
