using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgonDray : MonoBehaviour
{
    public UIManager ui;

    public int maxHealth = 3;
    [SerializeField]
    private int currentHealth;

    private GameObject target;
    private bool playerInZone = false;

    public AgonDrayWeapon weapon;

    private int lastHitID = -1;

    public ParticleSystem deathParticle;

    public DragonActiveZone zone;

    // Start is called before the first frame update
    void Start()
    {
        zone.AddEnemyToList(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {
            weapon.Attack(new Vector3(target.transform.position.x, 1f, target.transform.position.z));
        }   
    }

    public void ActivateEnemy(GameObject t)
    {
        playerInZone = true;
        target = t;
    }

    public void HitDragon(int hitNum, int dmg)
    {
        if (hitNum != lastHitID)
        {
            currentHealth -= dmg;

            if (currentHealth <= 0)
            {
                Die();
            }

            lastHitID = hitNum;
        }
    }

    private void Die()
    { 

        if (deathParticle != null)
        {
            deathParticle.Play();
        }

        this.gameObject.SetActive(false);

        // Win game here
    }
}
