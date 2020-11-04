using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayCredits());
    }

 IEnumerator delayCredits()
 {
        yield return new WaitForSeconds(15);
        SceneLoader.GoToCredits();
 }
}
