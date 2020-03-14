using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenuUI;

    void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Entrou");
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
        }
        
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
