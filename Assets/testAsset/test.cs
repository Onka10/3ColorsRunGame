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
            //x=�X�P�[������^�C�����O�̒l����鏈��
            //y=�X�P�[������^�C�����O�̒l����鏈��
        }



        void Update()
        {

            mt1.SetFloat("TilingX", x);
            mt1.SetFloat("TilingY", y);




        }

    
}
