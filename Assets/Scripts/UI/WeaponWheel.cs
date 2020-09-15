using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    public Image[] selectedWeaponIcons;
    int selected = 0;

    private AudioSource wheelNoises;
    public AudioClip weaponSelected;

    // Start is called before the first frame update
    void Start()
    {
        selectedWeaponIcons[0].enabled = true;

        for(int currentImage = 1; currentImage < selectedWeaponIcons.Length; currentImage++)
        {
            selectedWeaponIcons[currentImage].enabled = false;
        }

        wheelNoises = gameObject.GetComponent<AudioSource>();
       
    }

   public void selectNext(int currentSelection, int newSelection)
    {
        selectedWeaponIcons[currentSelection].enabled = false;
        selectedWeaponIcons[newSelection].enabled = true;
        selected = newSelection;

        wheelNoises.PlayOneShot(weaponSelected, 1.0f);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
