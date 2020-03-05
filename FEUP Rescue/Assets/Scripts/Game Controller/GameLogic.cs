using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public int lives = 3;
    public int max_lives = 3;
    int points = 0;
    bool speeding = false;
    float speedingTime = 0f;
    public float maxSpeedingTime = 4f;
    public bool inTimeOut = false;
    float deltaTimeOut = 0f;
    public float maxTimeOut = 1f;


    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        lives = max_lives;
        speeding = false;
        speedingTime = 0f;
        inTimeOut = false;
        deltaTimeOut = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(speeding) {
            speedingTime += Time.deltaTime;
            if(speedingTime >= maxSpeedingTime)
            {
                speeding = false;
                speedingTime = 0f;
            }
        }
        if(inTimeOut) {
            deltaTimeOut += Time.deltaTime;
            if(deltaTimeOut >= maxTimeOut)
            {
                inTimeOut = false;
                deltaTimeOut = 0f;
            }
        }
    }

    public void IncrementPoints() {
        points++;
        Debug.Log("Points: " + points);
    }

    public void IncrementLives() {
        if(lives < max_lives) {
            lives++;
            Debug.Log("Lives: " + lives);
        }
    }

    public void SpeedUp() {
        speeding = true;
        speedingTime = 0f;
    }

    public bool isSpeeding() {
        return speeding;
    }

    public void setTimeOut() {
        inTimeOut = true;
    }

    public void GameOver() {
        //do stuff
        Debug.Log("Game Over!");
    }
}
