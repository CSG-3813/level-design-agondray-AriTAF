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

    public bool hasKey;

    [SerializeField]
    private Weapon ActiveWeapon;

    [SerializeField]
    private int playerHealth;
    public int playerMaxHealth;
    private int lastHitNum = -1;

    private bool swinging = false;
    private float swingingTime = 0;
    public float swingDuration;

    public GameObject attackHitbox;

    public AudioSource damageAudioSource;

    public UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize values
        playerHealth = playerMaxHealth;
        SpearWeap = Spear.GetComponent<Weapon>();
        SwordWeap = Sword.GetComponent<Weapon>();
        hasKey = false;

        // Deactivate both weapons unitl they're equipped
        ActiveWeapon = null;
        Spear.SetActive(false);
        Sword.SetActive(false);
        attackHitbox.SetActive(false);

        if(damageAudioSource == null)
        {
            damageAudioSource = GetComponent<AudioSource>();
        }

        UpdateUIManager();
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
                attackHitbox.SetActive(false);
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
        Debug.Log("Sword collected");
        Spear.SetActive(false);
        Sword.SetActive(true);
        ActiveWeapon = SwordWeap;
    }

    // Swings weapon
    public void Attack()
    {
        if(ActiveWeapon != null)
        {
            ActiveWeapon.Attack();
            attackHitbox.SetActive(true);
            attackHitbox.GetComponent<PlayerHitboxScript>().Attack(ActiveWeapon.weaponDamage);
        }
    }

    // Take damage
    public void Damage(int dmg, int hitNum)
    {
        if(hitNum != lastHitNum)
        {
            playerHealth -= dmg;
            lastHitNum = hitNum;
            UpdateUIManager();

            if(playerHealth <= 0)
            {
                Debug.Log("Game Over");
                // Trigger Game Over


                ui.GameOver();
            }
            else if(playerHealth < 3)
            {
                ui.SetDialogueUI("That one stung a bit.");
            }

        }
        
    }

    // Obtain the key to the door, called by the key pickup
    public void ObtainKey()
    {
        hasKey = true;
    }

    public void UpdateUIManager()
    {
        ui.SetHealthUI(new string(playerHealth + "/" + playerMaxHealth));
    }
}
