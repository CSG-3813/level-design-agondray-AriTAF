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
    private bool spearActive;
    private bool swordActive;
    public GameObject Spear;
    public GameObject Sword;

    [SerializeField]
    private int playerHealth;
    public int playerMaxHealth;

    private bool swinging = false;
    private float swingingTime = 0;
    public float swingDuration;

    // Start is called before the first frame update
    void Start()
    {
        spearActive = false;
        swordActive = false;
        Spear.SetActive(false);
        Sword.SetActive(false);
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!swinging)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                swinging = true;
                Attack();
                swingingTime = 0;
            }
        } 
        else
        {
            
        }
    }

    // Sets the character to have the spear
    public void CollectSpear()
    {

    }

    // Sets the character to have the sword and not have the spear
    public void CollectSword()
    {

    }

    // Swings weapon
    public void Attack()
    {

    }

    // Take damage
    public void Damage()
    {

    }
}
