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

    void Start() //funciona
    {
        StrawberryCounterText.text = " " + counterStrawberry; 
        MushroomCounterText.text = " " + counterMushroom;
        AcornCounterText.text = " " + counterMushroom;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Strawberry"))
        {
            Destroy(other.gameObject);
            counterStrawberry--;
            StrawberryCounterText.text = " " + counterStrawberry;
            Debug.Log("counterStrawberry");
        }
        if (other.CompareTag("Mushroom"))
        {
            Destroy(other.gameObject);
            counterMushroom--;
            MushroomCounterText.text = " " + counterMushroom;
            Debug.Log("counterMushroom");
        }
        if (other.CompareTag("Acorn")) 
        {
            Destroy(other.gameObject);
            counterAcorn--;
            AcornCounterText.text = " " + counterAcorn;
            Debug.Log("counterAcorn");
        }

    }

}
