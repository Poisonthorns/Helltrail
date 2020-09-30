using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public bool isNotGluttony;
    void healthPotion()
    {
        print("healed");
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

        if (!isNotGluttony)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in temp)
            {
                enemy.GetComponent<EnemyHealthManager>().GainHealth(40);
            }
        }
        GameObject.Find("Health Bar").GetComponent<PlayerHealthController>().GainHealth(20);
    }
    void speedPotion()
    {

    }
    void damageUpPotion()
    {
        print("damage up");
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
