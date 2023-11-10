using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    public static TimeUI instance;

    public Slider timeSlider;

    private float timePlay = 40f;
    public float currentTime;
    public int lastScene;

    void Start()
    {
        instance = this;
        currentTime = timePlay;
        Update();
    }

    void Update()
    {
        CheckTimeLoss();
        UpDateTime();
    }

    public void UpDateTime()
    {
        float timeValue = currentTime / timePlay;
        timeSlider.value = timeValue;
    }

    //public void LossReLoad()
    //{
    //    int currentScene = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(currentScene);
    //}

    void CheckTimeLoss()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOver");
        }
    }

}
