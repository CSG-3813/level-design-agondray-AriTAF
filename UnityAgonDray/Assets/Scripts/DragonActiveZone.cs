using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonActiveZone : MonoBehaviour
{
    private List<AgonDray> enemiesInZone;

    private void Awake()
    {
        enemiesInZone = new List<AgonDray>();
    }

    public void AddEnemyToList(AgonDray e)
    {
        enemiesInZone.Add(e);
    }

    public void RemoveEnemyFromList(AgonDray e)
    {
        if (enemiesInZone.Contains(e))
        {
            enemiesInZone.Remove(e);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered Dragon zone");
            foreach (AgonDray e in enemiesInZone)
            {
                e.ActivateEnemy(other.gameObject);
            }
        }
    }
}
