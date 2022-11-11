using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScene(string MainMenu)
    {
        SceneManager.LoadScene(Kitchen);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
