using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public bool isNotGluttony;

    [SerializeField]
    private AudioSource potionUsed;

    public AudioClip healthSound;
    public AudioClip defenseSound;
    public AudioClip speedSound;
    public AudioClip damageSound;
    public AudioClip rangeSound;

    public void Start()
    {
        potionUsed = GetComponent<AudioSource>();
    }

    void healthPotion()
    {
        print("healed");

        potionUsed.volume = 0.0f;
        potionUsed.clip = healthSound;
        potionUsed.Play();
        StartCoroutine(SoundManager.Fade(potionUsed, 0.75f, 1.0f));
        //potionUsed.PlayOneShot(healthSound);

        if(!isNotGluttony)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in temp)
            {
                enemy.GetComponent<EnemyHealthManager>().GainHealth(40);
            }
        }
        GameObject.Find("Player Health Bar").GetComponent<PlayerHealthController>().GainHealth(20);

    }
    void defensePotion()
    {
        print("defense");

        //potionUsed.PlayOneShot(defenseSound);
        potionUsed.volume = 0.0f;
        potionUsed.clip = defenseSound;
        potionUsed.Play();
        StartCoroutine(SoundManager.Fade(potionUsed, 0.75f, 1.0f));

        if (!isNotGluttony)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in temp)
            {
                enemy.GetComponent<EnemyHealthManager>().GainHealth(40);
            }
        }
        GameObject.Find("Player Health Bar").GetComponent<PlayerHealthController>().GainHealth(20);
    }
    void speedPotion()
    {
        print("speed");

        //potionUsed.PlayOneShot(speedSound);
        potionUsed.volume = 0.0f;
        potionUsed.clip = speedSound;
        potionUsed.Play();
        StartCoroutine(SoundManager.Fade(potionUsed, 0.75f, 1.0f));
    }
    void damageUpPotion()
    {
        print("damage up");

        //potionUsed.PlayOneShot(damageSound);
        potionUsed.volume = 0.0f;
        potionUsed.clip = damageSound;
        potionUsed.Play();
        StartCoroutine(SoundManager.Fade(potionUsed, 0.75f, 1.0f));

        if (!isNotGluttony)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in temp)
            {
                enemy.GetComponent<EnemyAttackManager>().attackDamage += 20;
            }
        }
        GameObject.Find("Player").GetComponent<PlayerCombatController>().additionalDamage += 20;
        StartCoroutine(PotionExpire(4 , 20));
    }

    void rangeUpPotion()
    {
        print("range up");

        //potionUsed.PlayOneShot(rangeSound);
        potionUsed.volume = 0.0f;
        potionUsed.clip = rangeSound;
        potionUsed.Play();
        StartCoroutine(SoundManager.Fade(potionUsed, 0.75f, 1.0f));
    }
    IEnumerator PotionExpire(int type, int seconds)
    {
       

        yield return new WaitForSeconds(seconds);
        switch (type)
        {
            case 1:
                print("no");
                break;
            case 2:
                print("notyet speed");
                break;
            case 3:
                print("defense expired");

                break;
            case 4:
                print("damage up expired");
                GameObject.Find("Player").GetComponent<PlayerCombatController>().additionalDamage -= 20;

                break;
            default:
                break;
        }


    }
    void allOfTheAbovePotion()
    {

    }
    public void useItem(int id)
    {
        print(id);
        switch (id)
        {
            case 1:
                healthPotion();
                break;
            case 2:
                speedPotion();
                break;
            case 3:
                defensePotion();
                break;
            case 4:
                damageUpPotion();
                break;
            case 5:
                allOfTheAbovePotion();
                break;
            default:
                break;
        }
    }
}
