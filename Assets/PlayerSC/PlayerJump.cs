using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
        public class PlayerJump : MonoBehaviour
    {
        bool jumpNow=false;
        float jumpPower;
        Rigidbody rBody; // リジッドボディを使うための宣言

        // Start is called before the first frame update
        void Start()
        {
            rBody = this.gameObject.GetComponent<Rigidbody>();

            InputManager.I.OnSpace
                .Subscribe(_ => Jump())
                .AddTo(this);

            // Playerと衝突したら、Playerは死亡する
            this.OnCollisionEnterAsObservable()
                .Select(hit => hit.gameObject.tag)
                .Where(tag => tag == "wall")
                .Subscribe(_ => jumpNow = false)
                .AddTo(this);

            jumpPower = PlayerManager.I.Data.jumpPower;

        }

        void Jump()
        {
            if (jumpNow == true) return;

            rBody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            jumpNow = true;
            
        }

    }
}

