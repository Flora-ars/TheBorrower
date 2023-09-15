using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //audio var player
    private AudioSource audioSourcePlayer;
    [SerializeField] private AudioClip footSteps;
    [SerializeField] private AudioClip collecting;
    private GameObject _player;
    private CollectionCounter _counter;
    private bool checkIsCollected;
    private GameObject _collectSound;
    private AudioSource audioSourceCollectSound;

    //audio var enviroment
    private AudioSource soundManager;
    [SerializeField] private AudioClip natureBirds;
    
    

void Start()
    {
        _player = GameObject.Find("Player_Tody");
        audioSourcePlayer = _player.GetComponent<AudioSource>();
        _counter = _player.GetComponent<CollectionCounter>();
        _collectSound = GameObject.Find("CollectSound");
        audioSourceCollectSound = _collectSound.GetComponent<AudioSource>();
        
        
        soundManager = GetComponent<AudioSource>();
        soundManager.clip = natureBirds;
        soundManager.loop = true;
        soundManager.volume = .5f;
        soundManager.Play();

    }
    private void Update()
    {
        checkIsCollected = _counter.isCollected;
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
                audioSourcePlayer.volume = .5f;
                audioSourcePlayer.pitch = -1.2f;
                audioSourcePlayer.spatialBlend = .8f;
                audioSourcePlayer.Play();
            }
        }else
        {
            audioSourcePlayer.Stop();
        }

        if (checkIsCollected == true)
        {
            if (!audioSourceCollectSound.isPlaying)
            {
                audioSourceCollectSound.PlayOneShot(collecting, .8f);
            }
            /*audioSourceCollectSoud.clip = collecting;
            audioSourceCollectSoud.loop = false;
            audioSourceCollectSoud.volume = .8f;
            audioSourceCollectSoud.Play();*/
            
            
        }
        
    }
}
