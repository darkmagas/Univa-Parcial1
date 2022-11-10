using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch: MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("DarumaShuffle_Oto�o");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Daruma Shuffle_Titulo");
    }
}
