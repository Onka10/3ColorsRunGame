using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SEManager : Singleton<SEManager>
{
    AudioSource _audioSource;


    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    //うちわけ1:jump、2:CC
    public List<AudioClip> SE = new List<AudioClip>(5);

    public void Jump(){
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[0]);
    } 

    public void CC(){
        _audioSource.volume = 0.3f;
        _audioSource.PlayOneShot(SE[1]);
    } 
}