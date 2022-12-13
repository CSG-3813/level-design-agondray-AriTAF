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

public class Weapon : MonoBehaviour
{
    Animator weaponAnimator;

    public int weaponDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        // trigger the attack animation from the animator
        weaponAnimator.SetTrigger("Attack");
    }
}
