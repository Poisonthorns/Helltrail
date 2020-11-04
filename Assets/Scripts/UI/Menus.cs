using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
   public void buttonFunction()
    {
        if(gameObject.name.Equals("Start Button"))
        {
            SceneLoader.GoToGluttony();
        }
        else if (gameObject.name.Equals("Controls Button"))
        { 
            SceneLoader.GoToControls();
        }
        else if (gameObject.name.Equals("Exit Button"))
        {
            SceneLoader.exitGame();
        }
        else if (gameObject.name.Equals("Pause Back Button"))
        {
            SceneLoader.Resume();
        }
        else if (gameObject.name.Equals("Pause Controls Back"))
        {
            SceneLoader.GoToPause();
        }
        else if (gameObject.name.Equals("Controls Back Button"))
        {
            SceneLoader.GoToMenu();
        }
        else if (gameObject.name.Equals("Peyton Animation Scene"))
        {
            SceneLoader.GoToPeytonAnimation();
        }
        else if (gameObject.name.Equals("Main Menu"))
        {
            SceneLoader.GoToMenu();
        }
        else if (gameObject.name.Equals("Limbo"))
        {
            SceneLoader.GoToLimbo();
        }
        else if (gameObject.name.Equals("FinalBoss 1"))
        {
            SceneLoader.GoToTreachery();
        }
        else if (gameObject.name.Equals("Win Screen"))
        {
            SceneLoader.GoToWinScreen();
        }
        else if (gameObject.name.Equals("Death Screen"))
        {
            SceneLoader.GoToDeathScreen();
        }
        else if (gameObject.name.Equals("GluttonyV2"))
        {
            SceneLoader.GoToGluttony();
        }
        else if (gameObject.name.Equals("Gluttony Boss"))
        {
            SceneLoader.GoToGluttonyBoss();
        }
        else if (gameObject.name.Equals("StatScreen"))
        {
            SceneLoader.GoToStatScreen();
        }
        else if (gameObject.name.Equals("ArtGallery"))
        {
            SceneLoader.GoToArtGallery();
        }
    }
}
