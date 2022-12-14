/*
 * Created by: Krieger
 * Created on: 12/13/2022
 * 
 * Last edited: N/A
 * 
 * Description: Script for a zone containing enemies. Keeps a list of enemies in the zone and notifies
 *              each Enemy when the player enters and exits
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveZone : MonoBehaviour
{
    private List<Enemy> enemiesInZone;

    private void Awake()
    {
        enemiesInZone = new List<Enemy>();
    }

    public void AddEnemyToList(Enemy e)
    {
        enemiesInZone.Add(e);
    }

    public void RemoveEnemyFromList(Enemy e)
    {
        if (enemiesInZone.Contains(e))
        {
            enemiesInZone.Remove(e);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(Enemy e in enemiesInZone)
            {
                e.ActivateEnemy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Enemy e in enemiesInZone)
            {
                e.DeactivateEnemy();
            }
        }
    }
}
