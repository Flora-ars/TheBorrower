using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //audio var player
    private AudioSource audioSourcePlayer;
    [SerializeField] private AudioClip footSteps;
    private GameObject _player;

    //audio var enviroment
    private AudioSource soundManager;
    [SerializeField] private AudioClip natureBirds;



    void Start()
    {
        _player = GameObject.Find("Character_Tody");
        audioSourcePlayer = _player.GetComponent<AudioSource>();


        soundManager = GetComponent<AudioSource>();
        soundManager.clip = natureBirds;
        soundManager.loop = true;
        soundManager.volume = .5f;
        soundManager.Play();

    }
    private void Update()
    {
        ActiveSoundEffects();

    }

    void ActiveSoundEffects()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        float speed = inputVector.magnitude;

        if (speed > 0.1f)
        {
            if (!audioSourcePlayer.isPlaying)
            {
                audioSourcePlayer.clip = footSteps;
                audioSourcePlayer.loop = true;
                audioSourcePlayer.priority = 128;
                audioSourcePlayer.volume = 1f;
                audioSourcePlayer.pitch = -1.2f;
                audioSourcePlayer.spatialBlend = .8f;
                audioSourcePlayer.Play();
            }
        }
        else
        {
            audioSourcePlayer.Stop();
        }
    }

}