using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ColorViewer : MonoBehaviour
{
    [SerializeField] Image Now;
    [SerializeField] Image R;
    [SerializeField] Image L;

    Color Red = new Color(255,0,195);
    Color Green = new Color(255,235,0);
    Color Blue = new Color(0,255,200);

    private void Start() {
        ColorManager.I.OnColorStates
        .Subscribe(c => Load(c))
        .AddTo(this);
    }

    void Load(ColorState c){
        if (c == ColorState.Red){
            Now.color = Red;
            R.color = Blue;
            L.color = Green;

        }
        else if (c == ColorState.Green){
            Now.color = Green;
            R.color = Red;
            L.color = Blue;

        }
        else if (c == ColorState.Blue){
            Now.color = Blue;
            R.color = Green;
            L.color = Red;

        }
    }
}
