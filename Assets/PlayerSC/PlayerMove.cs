using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerMove : MonoBehaviour
{
    public bool jumpNow=false;
    public float jumpPower=500; //調整必要 例850
    Rigidbody rbody; // リジッドボディを使うための宣言

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.gameObject.GetComponent<Rigidbody>();

        InputManager.I.OnSpace
            .Subscribe(_ => Jump())
            .AddTo(this);
            
    }

    void Jump()
    {
        //if (jumpNow == true) return;

        rbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        jumpNow = true;
        
    }

}
