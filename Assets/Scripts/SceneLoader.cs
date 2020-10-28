using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static SoundManager soundManager;
    public static AudioClip limboSong;
    public static AudioClip gluttonySong;
    public static AudioClip violenceSong;
    public static AudioClip heresySong;
    public static AudioClip treacherySong;

    public static GameObject pauseScreen;

    
    public static GameObject controlsScreen;

    public static void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Debug.Log("HI");
    }
    public static void GoToMenu()
    {
        DisableActiveScreens();
        //Insert correct name
        SceneManager.LoadScene("Main Menu");
        soundManager.SwitchTrackCaller(0);
    }

    public static void GoToLimbo()
    {
        //Insert correct name
        SceneManager.LoadScene("Limbo");
        soundManager.SwitchTrackCaller(1);
    }

    public static void GoToGluttony()
    {
        //Insert correct name
        soundManager.SwitchTrackCaller(2);
        SceneManager.LoadScene("GluttonyV2");
    }

    public static void GoToGluttonyBoss()
    {
        //Insert correct name
        
        SceneManager.LoadScene("FinalBoss 1");
        soundManager.SwitchTrackCaller(2);
    }

    public static void GoToViolence()
    {
        //Insert correct name
        //audioManager.PlayMusicWithFade(violenceSong, 0.1f);
        SceneManager.LoadScene("Violence");
    }

    public static void GoToHeresy()
    {
        //Insert correct name
        //audioManager.PlayMusicWithFade(heresySong, 0.1f);
        SceneManager.LoadScene("Heresy");
    }

    public static void GoToTreachery()
    {
        //Insert correct name
        //audioManager.PlayMusicWithFade(treacherySong, 0.1f);
        SceneManager.LoadScene("FinalBoss 1");
    }

    public static void GoToWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
        soundManager.SwitchTrackCaller(0);
    }

    public static void GoToDeathScreen()
    {
        //Insert correct name
        SceneManager.LoadScene("Death Screen");
        soundManager.SwitchTrackCaller(0);
    }

    public static void GoToDebug()
    {
        SceneManager.LoadScene("Debug Menu");
        soundManager.SwitchTrackCaller(0);
    }

    public static void GoToPeytonAnimation()
    {
        SceneManager.LoadScene("Peyton Animation Scene");
    }

    public static void GoToStatScreen()
    {
        SceneManager.LoadScene("StatScreen");
    }

    public static void GoToArtGallery()
    {
        SceneManager.LoadScene("ArtGallery");
    }

    public static void GoToPause()
    {
        DisableActiveScreens();
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public static void Resume()
    {
        DisableActiveScreens();
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public static void GoToControls()
    {
        DisableActiveScreens();
        controlsScreen.SetActive(true);
    }

    public static void exitGame()
    {
        Application.Quit();
    }

    public static void DisableActiveScreens()
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
