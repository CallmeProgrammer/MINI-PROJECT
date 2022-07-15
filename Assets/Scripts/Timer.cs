using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float time;
    float msec;
    float min;
    float sec;

    private void Start()
    {
        StartCoroutine("stopwatch");
    }
    IEnumerator stopwatch()
    {
        while(true)
        {
            time += Time.deltaTime;
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}" , min, sec);

            yield return null;


        }
    }
    private void Update()
    {
        if(timer.text == string.Format("{3:00}:{0:20}" , min ,sec))
            {
            Debug.Log("Times UP");
             }
    }

}

