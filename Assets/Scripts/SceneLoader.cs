using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    private AudioClip menuSong;
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

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void GoToMenu()
    {
        //Insert correct number
        audioManager.PlayMusicWithFade(menuSong, 0.1f);
        SceneManager.LoadScene(0);
    }

    public void GoToGluttony()
    {
        //Insert correct number
        audioManager.PlayMusicWithFade(gluttonySong, 0.1f);
        SceneManager.LoadScene(2);
    }

    public void GoToViolence()
    {
        //Insert correct number
        audioManager.PlayMusicWithFade(violenceSong, 0.1f);
        SceneManager.LoadScene(3);
    }

    public void GoToHeresy()
    {
        //Insert correct number
        audioManager.PlayMusicWithFade(heresySong, 0.1f);
        SceneManager.LoadScene(4);
    }

    public void GoToTreachery()
    {
        //Insert correct number
        audioManager.PlayMusicWithFade(treacherySong, 0.1f);
        SceneManager.LoadScene(5);
    }

    public void GoToIceSpell()
    {
        //Insert correct number
        audioManager.PlayMusicWithFade(treacherySong, 0.1f);
        SceneManager.LoadScene(6);
    }

    public void GoToWinScreen()
    {
       // SceneManager.LoadScene(2);
    }

    public void GoToDeathScreen()
    {
        //Insert correct number
        SceneManager.LoadScene(2);
    }

    public void GoToGame()
	{
        //Insert correct number
        audioManager.PlayMusicWithFade(limboSong, 0.1f);
        SceneManager.LoadScene(1);
    }

    public void GoToDebug()
    {
        SceneManager.LoadScene(13);
    }
}
