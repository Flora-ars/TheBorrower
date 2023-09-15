using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionCounter : MonoBehaviour
{
    private int counterStrawberry = 6;
    private int counterMushroom = 7;
    private int counterAcorn = 6;
    [SerializeField] private TextMeshProUGUI StrawberryCounterText;
    [SerializeField] private TextMeshProUGUI MushroomCounterText;
    [SerializeField] private TextMeshProUGUI AcornCounterText;
    
    public bool isCollected;
    

    void Start() //funciona
    {
        StrawberryCounterText.text = " " + counterStrawberry; 
        MushroomCounterText.text = " " + counterMushroom;
        AcornCounterText.text = " " + counterAcorn;
    }

    private void Update()
    {
        isCollected = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Strawberry"))
        {
            isCollected = true;
            Destroy(other.gameObject);
            counterStrawberry--;
            StrawberryCounterText.text = " " + counterStrawberry;
            Debug.Log("counterStrawberry");
        } else if (other.CompareTag("Mushroom"))
        {
            isCollected = true;
            Destroy(other.gameObject);
            counterMushroom--;
            MushroomCounterText.text = " " + counterMushroom;
            Debug.Log("counterMushroom");
        } else if (other.CompareTag("Acorn")) 
        {
            isCollected = true;
            Destroy(other.gameObject);
            counterAcorn--;
            AcornCounterText.text = " " + counterAcorn;
            Debug.Log("counterAcorn");
        }
        else
        {
            isCollected = false;
        }
        

    }

}
