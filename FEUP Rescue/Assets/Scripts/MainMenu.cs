using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Enter");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Yay");
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
