using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    Text score;
    void Start() {
        score = this.gameObject.GetComponent<Text>();

        ScoreManager.I.Score
        .Subscribe(s => score.text = s.ToString())
        .AddTo(this);  
    }
}
