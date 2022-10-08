using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerMove : MonoBehaviour
{
    public bool jumpNow=false;
    public float jumpPower=50; //調整必要 例850
    Rigidbody rbody; // リジッドボディを使うための宣言

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.gameObject.GetComponent<Rigidbody>();

        InputManager.I.OnSpace
            .Subscribe(_ => Jump())
            .AddTo(this);

        // Playerと衝突したら、Playerは死亡する
        this.OnCollisionEnterAsObservable()
            .Select(hit => hit.gameObject.tag)
            .Where(tag => tag == "wall")
            .Subscribe(_ => jumpNow = false)
            .AddTo(this);

    }

    void Jump()
    {
        if (jumpNow == true) return;

        rbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        jumpNow = true;
        
    }

}
