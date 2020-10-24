using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioClip enemySound;
    AudioSource enemyAudio;

    string sound1 = "(Light Eating)";
    string sound2 = "(Slime)";
    string sound3 = "(Louder Eating)";
    string sound4 = "(Burping)";
    string sound5 = "(Monster Noises)";

    float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log((int)Random.Range(1, 3) - 1);
        enemySound = sounds[Random.Range(1, sounds.Length + 1) - 1];
        enemyAudio = gameObject.GetComponent<AudioSource>();

        if(enemySound.name.Equals(sound1))
        {
            Debug.Log(sound1);
        }
        else if (enemySound.name.Equals(sound2))
        {
            Debug.Log(sound2);
        }
        else if (enemySound.name.Equals(sound3))
        {
            Debug.Log(sound3);
        }
        else if (enemySound.name.Equals(sound4))
        {
            Debug.Log(sound4);
        }
        else
        {
            Debug.Log(sound5);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyAudio.isPlaying)
        {
            enemyAudio.PlayOneShot(enemySound, volume);
        }
    }
}
