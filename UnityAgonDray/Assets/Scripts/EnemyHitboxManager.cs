using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitboxManager : MonoBehaviour
{
    public int hitNum = 0; // ensures enemy can't be hit by same attack multiple times
    private int damage;

    public int Attack(int dmg)
    {
        hitNum++;
        damage = dmg;
        return hitNum;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerManager>().Damage(damage, hitNum);
            Debug.Log("Enemy hit " + other.gameObject.name);
        }
    }
}
