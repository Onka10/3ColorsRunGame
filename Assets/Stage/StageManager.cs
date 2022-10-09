using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ColorManager.I.OnColorStates
        //     .Subscribe(c => MoveStage(c))
        //     .AddTo(this);
    }

    void MoveStage(ColorState c)
    {

    }
}
