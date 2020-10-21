using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    private AudioClip limboSong;
    [SerializeField]
    private AudioClip gluttonySong;
    [SerializeField]
    private AudioClip violenceSong;
    [SerializeField]
    private AudioClip heresySong;
    [SerializeField]
    private AudioClip treacherySong;

    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private GameObject controlsScreen;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void GoToMenu()
    {
        DisableActiveScreens();
        //Insert correct name
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToLimbo()
    {
        //Insert correct name
        audioManager.PlayMusicWithFade(limboSong, 0.1f);
        SceneManager.LoadScene("Limbo");
    }

    public void GoToGluttony()
    {
        //Insert correct name
        audioManager.PlayMusicWithFade(gluttonySong, 0.1f);
        SceneManager.LoadScene("GluttonyV2");
    }

    public void GoToGluttonyBoss()
    {
        //Insert correct name
        audioManager.PlayMusicWithFade(gluttonySong, 0.1f);
        SceneManager.LoadScene("Gluttony Boss");
    }

    public void GoToViolence()
    {
        //Insert correct name
        audioManager.PlayMusicWithFade(violenceSong, 0.1f);
        SceneManager.LoadScene("Violence");
    }

    public void GoToHeresy()
    {
        //Insert correct name
        audioManager.PlayMusicWithFade(heresySong, 0.1f);
        SceneManager.LoadScene("Heresy");
    }

    public void GoToTreachery()
    {
        //Insert correct name
        audioManager.PlayMusicWithFade(treacherySong, 0.1f);
        SceneManager.LoadScene("FinalBoss 1");
    }

    public void GoToWinScreen()
    {
       SceneManager.LoadScene("Win Screen");
    }

    public void GoToDeathScreen()
    {
        //Insert correct name
        SceneManager.LoadScene("Death Screen");
    }

    public void GoToDebug()
    {
        SceneManager.LoadScene("Debug Menu");
    }

    public void GoToPause()
    {
        DisableActiveScreens();
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        DisableActiveScreens();
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToControls()
    {
        DisableActiveScreens();
        controlsScreen.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void DisableActiveScreens()
    {
        if(controlsScreen != null && controlsScreen.activeSelf)
        {
            controlsScreen.SetActive(false);
        }

        if (pauseScreen != null && pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
        }
    }

    
}
