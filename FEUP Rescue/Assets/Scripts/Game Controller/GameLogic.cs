using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public int lives = 3;
    public int max_lives = 3;
    int points = 0;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        lives = max_lives;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
