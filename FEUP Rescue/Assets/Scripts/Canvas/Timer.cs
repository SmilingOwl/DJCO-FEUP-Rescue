using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    private float time;
    public TextMeshProUGUI text;
    private bool stop;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop)
            return;
        time += Time.deltaTime;
        int minutes = (int) (time / 60);
        string minutes_to_write = "" + minutes;
        if(minutes >= 0 && minutes < 10)
            minutes_to_write = "0" + minutes;
        
        int seconds = (int) (time % 60);
        string seconds_to_write = "" + seconds;
        if(seconds >= 0 && seconds < 10)
            seconds_to_write = "0" + seconds;

        text.text = minutes_to_write + ":" + seconds_to_write;
    }

    void StopTimer() {
        stop = true;
    }

    public int GetTimerPoints() {
        int minutes = (int) (time / 60);
        if(minutes >= 5)
            return 0;
        else if(minutes >= 4)
            return 10;
        else if(minutes >= 3)
            return 20;
        else if(minutes >= 2)
            return 30;
        else if(minutes >= 1)
            return 40;
        else
            return 50;
    }
}
