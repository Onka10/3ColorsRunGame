using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Player
{
    public class PlayerAutoMove : MonoBehaviour
    {
        PlayerManager manager;
        float speed;

        void Start(){
            manager = PlayerManager.I;
            speed = manager.Data.speed;
        }

        void Update()
        {
            if(!manager.IsMove) return;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}

