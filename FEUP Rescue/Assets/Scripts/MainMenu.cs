using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        GameLogic.instance.SetGameOver();
        Application.Quit();
    }

    public void click()
    {
        GameLogic.instance.SetGameOver();
        SceneManager.LoadScene("Menu");
    }
}
