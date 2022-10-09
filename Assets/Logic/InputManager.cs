using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputManager :Singleton<InputManager>
{
    public IObservable<Unit> OnSpace => _space;
    private readonly Subject<Unit> _space = new Subject<Unit>();

    public IObservable<Unit> OnRight => _right;
    private readonly Subject<Unit> _right = new Subject<Unit>();

    public IObservable<Unit> OnLeft => _left;
    private readonly Subject<Unit> _left = new Subject<Unit>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("space");
            _space.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Debug.Log("R");
            _right.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Debug.Log("L");
            _left.OnNext(Unit.Default);
        }

    }
}
