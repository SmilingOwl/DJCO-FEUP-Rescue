using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
}
