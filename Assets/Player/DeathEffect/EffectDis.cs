using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDis : MonoBehaviour
{


	public GameObject Effect;
	//�폜�������Q�[���I�u�W�F�N�g
	void Start()
	{
		var main = GetComponent<ParticleSystem>().main;

		// StopAction��Callback�ɐݒ肵�Ă���K�v������
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped()
	{
		//�Đ��I������ƌĂяo�����
		Destroy(Effect);

	}



}
