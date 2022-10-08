using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public enum ColorState
{
    Red,
    Green,
    Blue,
}

public class ColorManager : Singleton<ColorManager>
{
    public  IReadOnlyReactiveProperty<ColorState> OnColorStates => ColorStates;
    private readonly ReactiveProperty<ColorState> ColorStates = new ReactiveProperty<ColorState>(ColorState.Red);

    void Start()
    {
        InputManager.I.OnRight
        .Subscribe(_ => ColorChange(1))
        .AddTo(this);

        InputManager.I.OnLeft
        .Subscribe(_ => ColorChange(-1))
        .AddTo(this);

    }

    void ColorChange(int i)
    {
        if (i > 0)
        {
            if (ColorStates.Value == ColorState.Red) ColorStates.Value = ColorState.Blue;
            else if (ColorStates.Value == ColorState.Blue) ColorStates.Value = ColorState.Green;
            else if (ColorStates.Value == ColorState.Green) ColorStates.Value = ColorState.Red;
        }
        else
        {
            if (ColorStates.Value == ColorState.Red) ColorStates.Value = ColorState.Green;
            else if (ColorStates.Value == ColorState.Blue) ColorStates.Value = ColorState.Red;
            else if (ColorStates.Value == ColorState.Green) ColorStates.Value = ColorState.Blue;
        }

    }

}
