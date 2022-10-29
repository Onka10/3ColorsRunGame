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
        Rigidbody rb;

        void Start(){
            manager = PlayerManager.I;
            speed = manager.Data.speed;
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if(!manager.IsMove) return;
            // transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            rb.velocity = new Vector3(speed,rb.velocity.y,rb.velocity.z);
        }
    }
}

