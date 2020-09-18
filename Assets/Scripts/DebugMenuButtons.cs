using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DebugMenuButtons : MonoBehaviour
{
    public void GoToScene()
    {
        string sceneName = gameObject.name;
        SceneManager.LoadScene(sceneName);
    }
}
