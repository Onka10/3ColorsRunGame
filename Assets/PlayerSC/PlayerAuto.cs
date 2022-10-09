using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Player
{
    public class PlayerAuto : MonoBehaviour
    {
        public PlayerManager manager;
        public float speed = 5f;   // 横に移動する速度

        Rigidbody rbody; // リジッドボディを使うための宣言


        void Start(){
            // リジッドボディ2Dをコンポーネントから取得して変数に入れる
            rbody = this.gameObject.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if(!manager.IsMove) return;
            //リジッドボディに一定の速度を入れる（横移動の速度, リジッドボディのyの速度）
            //rbody.velocity = new Vector3(speed, 0, 0);
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}

