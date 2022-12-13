/*
 * Created by: Krieger
 * Created on: 12/13/2022
 * 
 * Last edited: N/A
 * 
 * Description: Handles all the extra stuff I added to the player
 * 
 */ 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /*****Variables*****/
    public GameObject Spear;
    private Weapon SpearWeap;
    public GameObject Sword;
    private Weapon SwordWeap;

    private Weapon ActiveWeapon;

    [SerializeField]
    private int playerHealth;
    public int playerMaxHealth;

    private bool swinging = false;
    private float swingingTime = 0;
    public float swingDuration;

    public AudioSource damageAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize values
        playerHealth = playerMaxHealth;
        SpearWeap = Spear.GetComponent<Weapon>();
        SwordWeap = Sword.GetComponent<Weapon>();

        // Deactivate both weapons unitl they're equipped
        ActiveWeapon = null;
        Spear.SetActive(false);
        Sword.SetActive(false);

        if(damageAudioSource == null)
        {
            damageAudioSource = GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!swinging)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                swinging = true;
                Attack();
                swingingTime = 0;
            }
        } 
        else
        {
            swingingTime += Time.deltaTime;
            if(swingingTime >= swingDuration)
            {
                swinging = false;
            }
        }
    }

    // Sets the character to have the spear
    public void CollectSpear()
    {
        if (ActiveWeapon == null)
        {
            Spear.SetActive(true);
            ActiveWeapon = SpearWeap;
        }
    }

    // Sets the character to have the sword and not have the spear
    public void CollectSword()
    {
        Sword.SetActive(true);
        Spear.SetActive(false);
        ActiveWeapon = SwordWeap;
    }

    // Swings weapon
    public void Attack()
    {
        if(ActiveWeapon != null)
        {
            Debug.Log("Attacking");
            ActiveWeapon.Attack();
        }
    }

    // Take damage
    public void Damage(int dmg)
    {
        playerHealth -= dmg;
        if(playerHealth <= 0)
        {
            Debug.Log("Game Over");
            // Trigger Game Over
        }
    }
}
