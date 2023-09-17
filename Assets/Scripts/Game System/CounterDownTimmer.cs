using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CounterDownTimmer : MonoBehaviour
{
    float currentTime =0f;
    float startingTime = 75f;
    [SerializeField]Text countDownText;
    
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject WinningPanel;

    private GameObject _player;
    private CollectionCounter _counter;
    public bool winnig;
    public bool losing;
    

    private void Start()
    {
        _player = GameObject.Find("Character_Tody");
        _counter = _player.GetComponent<CollectionCounter>();
        currentTime = startingTime;
        Time.timeScale = 1.0f;
    }

    
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 3)
        {
            countDownText.color = Color.red;
        }

        Victory();
    }
    
    void Victory()
    {
        if (_counter.quantityZero == true)
        {
            winnig = true;
            Time.timeScale = 0;
            WinningPanel.SetActive(true);
            Debug.Log("You Win!");
        } else if (currentTime <= 0 && _counter.quantityZero == false)
        {
            currentTime = 0;
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
            losing = true;
            Debug.Log("You Lost!");
        }
    }


}
