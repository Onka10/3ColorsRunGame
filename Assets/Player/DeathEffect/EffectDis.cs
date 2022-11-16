using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDis : MonoBehaviour
{


	public GameObject Effect;
	//削除したいゲームオブジェクト
	void Start()
	{
		var main = GetComponent<ParticleSystem>().main;

		// StopActionはCallbackに設定している必要がある
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped()
	{
		//再生終了すると呼び出される
		Destroy(Effect);

	}



}
