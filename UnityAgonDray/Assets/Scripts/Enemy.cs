/*
 * Created by: Krieger
 * Created on: 12/13/2022
 * 
 * Last edited: 12/14/2022
 * 
 * Description: Handles behavior for basic enemies
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    [SerializeField]
    private int currentHealth;

    [Space(20)]
    [Header("Attacks")]
    public Weapon weapon;
    public float attackTime = 0.9f;
    public float attackRange = 1f;
    public float attackActiveStartTime = 2.5f;
    public float attackActiveEndTime = 2f;
    private float attackCooldown = 0f;
    private bool isAttackOnCooldown = false;
    private bool isAttackActive = false;
    private bool attackFinished = false;
    public GameObject attackHitbox;
    private EnemyHitboxManager attackHitboxManager;

    [Space(20)]
    [Header("Movement")]
    public float maxMoveSpeed = 1.0f;
    public float attackSpeedPenalty = .7f;
    private float moveSpeed;
    public GameObject enemyActiveZoneObject;
    private EnemyActiveZone activeArea;
    public bool playerInActiveArea = false;
    private GameObject target;
    public bool lookAtTarget = true;

    [Space(20)]
    [Header("Drops")]
    public bool hasDrops = false;
    public List<GameObject> drops;
    public ParticleSystem deathParticle;

    private Rigidbody rb;
    private int lastHitID = -1;

    // Start is called before the first frame update
    void Start()
    {
        activeArea = enemyActiveZoneObject.GetComponent<EnemyActiveZone>();
        currentHealth = maxHealth;
        activeArea.AddEnemyToList(this);
        moveSpeed = maxMoveSpeed;
        rb = GetComponent<Rigidbody>();

        if(drops == null)
        {
            drops = new List<GameObject>();
        }

        attackHitboxManager = attackHitbox.GetComponent<EnemyHitboxManager>();
        attackHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (isAttackOnCooldown) // if the enemy is currently attacking
        {
            attackCooldown -= Time.deltaTime;
            if(attackCooldown <= 0)
            {
                isAttackOnCooldown = false;
                moveSpeed = maxMoveSpeed;
            }
            else if(isAttackActive && attackCooldown <= attackActiveEndTime)
            {
                attackHitbox.SetActive(false);
                isAttackActive = false;
                attackFinished = true;
            }
            else if(!isAttackActive && !attackFinished && attackCooldown <= attackActiveStartTime)
            {
                isAttackActive = true;
                attackHitbox.SetActive(true);
                attackHitboxManager.Attack(weapon.weaponDamage);
            }
        }

        if (playerInActiveArea)
        {
            // Go after player and attack when in range
            Vector3 toTarget = target.transform.position - transform.position;
            if(toTarget.magnitude <= attackRange && !isAttackOnCooldown)
            {
                Attack();
            }

            toTarget.Normalize();
            toTarget *= moveSpeed;

            rb.velocity = toTarget;

            if (lookAtTarget)
            {
                transform.LookAt(
                    new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                transform.Rotate(0, -90, 0);
            }
            
        }
    }

    public void ActivateEnemy(GameObject player)
    {
        target = player;
        playerInActiveArea = true;
    }

    public void DeactivateEnemy()
    {
        target = null;
        playerInActiveArea = false;
    }

    public void HitEnemy(int hitNum, int dmg)
    {
        if(hitNum != lastHitID)
        {
            currentHealth -= dmg;

            if(currentHealth <= 0)
            {
                Die();
            }

            lastHitID = hitNum;
        }
    }

    private void Attack()
    {
        moveSpeed -= attackSpeedPenalty;
        weapon.Attack();
        
        attackCooldown = attackTime;
        isAttackOnCooldown = true;
        attackFinished = false;
    }

    private void Die()
    {
        if (hasDrops)
        {
            foreach(GameObject drop in drops)
            {
                Instantiate(drop);
            }
        }

        if(deathParticle != null)
        {
            deathParticle.Play();
        }

        this.gameObject.SetActive(false);
    }
}
