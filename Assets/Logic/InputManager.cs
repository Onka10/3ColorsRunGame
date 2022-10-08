using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputManager :Singleton<InputManager>
{
    public IObservable<Unit> OnSpace => _space;
    private readonly Subject<Unit> _space = new Subject<Unit>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            _space.OnNext(Unit.Default);
        }

    }
}
