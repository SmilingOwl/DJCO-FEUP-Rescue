using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;
    public GameObject GameOverMenu;
    public GameObject VictoryMenu;
    public bool GameIsPaused;
    public GameObject PauseMenu;
    int points = 0;
    bool speeding = false;
    bool protectedShield = false;
    float protectedTime = 0f;
    public float maxProtectedTime = 2f;
    float speedingTime = 0f;
    public float maxSpeedingTime = 4f;
    public bool inTimeOut = false;
    float deltaTimeOut = 0f;
    public float maxTimeOut = 1f;
    public bool gameOverbool;
    public bool gameWon;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        gameOverbool = false;
        gameWon = false;
        points = 0;
        speeding = false;
        speedingTime = 0f;
        protectedShield = false;
        protectedTime = 0f;
        inTimeOut = false;
        deltaTimeOut = 0f;
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("Carregou R");
                Resume();
            }
            else
            {
                Debug.Log("Carregou P");
                Pause();
            }
        }        if (speeding) {
            speedingTime += Time.deltaTime;
            if(speedingTime >= maxSpeedingTime)
            {
                PlayerMovement2D.instance.SetSpeeding(false);
                speeding = false;
                speedingTime = 0f;
            }
        }
        if(protectedShield){
            protectedTime += Time.deltaTime;
            if(protectedTime >= maxProtectedTime){
                PlayerHealth.instance.SetProtected(false);
                protectedShield = false;
                protectedTime = 0f;
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
        ScoreManager.scoreManager.UpdateScore(points);
    }

    public void SpeedUp() {
        PlayerMovement2D.instance.SetSpeeding(true);
        speeding = true;
        speedingTime = 0f;
    }

    public bool isSpeeding() {
        return speeding;
    }

    public bool isProtected(){
        return protectedShield;
    }

    public void ProtectedWithShield(){
        PlayerHealth.instance.SetProtected(true);
        protectedShield = true;
        protectedTime = 0f;
    }

    public void setTimeOut() {
        inTimeOut = true;
    }

    public void GameOver(string reason) {
        gameOverbool = true;
        Debug.Log("Game Over! " + reason);
        GameOverMenu.SetActive(true);
    }

    public void GameWon() {
        gameWon = true;
        Debug.Log("You win!");
        VictoryMenu.SetActive(true);
    }

    public bool HasGameEnded() {
        if(gameWon || gameOverbool)
            return true;
        return false;
    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
