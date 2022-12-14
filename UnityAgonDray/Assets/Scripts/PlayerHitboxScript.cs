/*
 * Created by: Krieger
 * Created on: 12/13/2022
 * 
 * Last edited: N/A
 * 
 * Description: Tracks hit number and damage to send to enemy
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitboxScript : MonoBehaviour
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
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().HitEnemy(hitNum, damage);
        }
        else if(other.gameObject.tag == "Dragon")
        {
            other.gameObject.GetComponent<AgonDray>().HitDragon(hitNum, damage);
        }
    }
}
