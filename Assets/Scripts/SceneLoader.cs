using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToMenu()
    {
        //Insert correct number
        SceneManager.LoadScene(0);
    }

    public void GoToDeathScreen()
    {
        //Insert correct number
        SceneManager.LoadScene(2);
    }

    public void GoToGame()
	{
        //Insert correct number
        SceneManager.LoadScene(1);
    }
}
