using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterDownTimmer : MonoBehaviour
{
    float currentTime =0f;
    float startingTime = 30f;
    [SerializeField]Text countDownText;
    [SerializeField] private GameObject GameOverPanel;


    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 3)
        {
            countDownText.color = Color.red;
        }



        if (currentTime <= 0) {
        currentTime = 0;
        GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }





}
