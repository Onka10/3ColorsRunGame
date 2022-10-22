using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : Singleton<ScoreManager>
{
    public  IReadOnlyReactiveProperty<int> Score => _score;
    private readonly ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
    public void AddScore(){
        _score.Value += 1;
    }

    public void Reset(){
        _score.Value = 0;
    }
}
