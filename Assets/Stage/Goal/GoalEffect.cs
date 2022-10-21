using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalEffect : Singleton<GoalEffect>
{
    [SerializeField] Text obj;

    void Start(){
        obj = gameObject.GetComponent<Text>();
        obj.enabled = false;
    }

    public void ClearText(){
        obj.enabled = true;
        obj.text = ScoreManager.I.Score.Value.ToString();
        
    }
}
