using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgonDrayWeapon : Weapon
{
    public GameObject fireballPrefab;
    private GameObject activeFireball;

    public float fireballSpeed = 5f;
    public int fireballDamage = 3;

    private void Start()
    {
        activeFireball = null;
    }

    public void Attack(Vector3 target)
    {
        // trigger the attack animation from the animator
        if(activeFireball == null)
        {
            Debug.Log("Creating fireball");
            activeFireball = Instantiate(fireballPrefab, this.transform);
            activeFireball.GetComponent<FireballProjectile>().SetFireballStats(target, fireballDamage, fireballSpeed);
            activeFireball.SetActive(true);
            
        }
        
    }
}
