using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalEffect : Singleton<GoalEffect>
{
    [SerializeField] GameObject obj;
    [SerializeField] Text text;
    [SerializeField] Text onegai;

    public void ClearText(){
        obj.SetActive(true);
        onegai.enabled = false;
        StartCoroutine("Go");
        text.text = ScoreManager.I.Score.Value.ToString();
    }

    IEnumerator Go()
    {
        yield return new WaitForSeconds(1);
        onegai.enabled =true;
    }
}