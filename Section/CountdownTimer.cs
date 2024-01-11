using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;   
    public float totalTime = 30f;  
    private float currentTime;    


    private void Start()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        currentTime = totalTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText.text = "Hết thời gian! Bạn đã thua";
        }
    }
}