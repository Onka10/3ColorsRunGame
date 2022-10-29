using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
   
        public Material mt1;

        public float x;
        public float y;

        void Start()
        {

            mt1 = this.GetComponent<Renderer>().material;
            //x=スケールからタイリングの値を取る処理
            //y=スケールからタイリングの値を取る処理
        }



        void Update()
        {

            mt1.SetFloat("TilingX", x);
            mt1.SetFloat("TilingY", y);




        }

    
}
