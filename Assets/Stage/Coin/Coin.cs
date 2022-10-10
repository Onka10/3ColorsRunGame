using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoin
{
    void Get();
}

public class Coin : MonoBehaviour,ICoin
{
    void Start()
    {
        ZKeep.Z(this.gameObject);
    }

    public void Get(){
        ScoreManager.I.AddScore();
        Destroy(this.gameObject);
    }
}
