using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCounter : MonoBehaviour
{
    private int counterStrawberry = 8;
    private int counterMushroom = 8;
    private int counterAcorn = 7;
    [SerializeField] private TextMeshProUGUI StrawberryCounterText;
    [SerializeField] private TextMeshProUGUI MushroomCounterText;
    [SerializeField] private TextMeshProUGUI AcornCounterText;
    [SerializeField] private AudioClip collecting;
    private GameObject _collectSound;
    private AudioSource audioSourceCollectSound;

    ///

    private int quantityObjects;
    public bool quantityZero;
    public bool isCollected=false;

    void Start()
    {
        StrawberryCounterText.text = " " + counterStrawberry;
        MushroomCounterText.text = " " + counterMushroom;
        AcornCounterText.text = " " + counterMushroom;
        _collectSound = GameObject.Find("CollectSound");///////
        audioSourceCollectSound = _collectSound.GetComponent<AudioSource>();

        quantityZero = false;
    }

    private void Update()
    {
        CounterObjects();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Strawberry") || other.CompareTag("Mushroom") || other.CompareTag("Acorn"))
        {
            isCollected = true;
            Destroy(other.gameObject);
            audioSourceCollectSound.PlayOneShot(collecting, .8f); /////////////
            if (other.CompareTag("Strawberry"))
            {
                counterStrawberry--;
                StrawberryCounterText.text = " " + counterStrawberry;
                Debug.Log("counterStrawberry");
            }
            else if (other.CompareTag("Mushroom"))
            {
                counterMushroom--;
                MushroomCounterText.text = " " + counterMushroom;
                Debug.Log("counterMushroom");
            }
            else if (other.CompareTag("Acorn"))
            {
                counterAcorn--;
                AcornCounterText.text = " " + counterAcorn;
                Debug.Log("counterAcorn");
            }
        }
    }

    void CounterObjects()
    {
        quantityObjects = counterMushroom + counterAcorn + counterStrawberry;
        if (quantityObjects == 0)
        {
            quantityZero = true;
        }
        else
        {
            quantityZero = false;
        }
    }
}

