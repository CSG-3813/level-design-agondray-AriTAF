/*
 * Created by: Krieger
 * Created on: 12/13/2022
 * 
 * Last edited: 12/14/2022
 * 
 * Description: Handles weapon behavior
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator weaponAnimator;

    public int weaponDamage = 1;

    private void Start()
    {
        if(weaponAnimator == null)
        {
            weaponAnimator = GetComponent<Animator>();
        }
    }

    public void Attack()
    {
        // trigger the attack animation from the animator
        weaponAnimator.SetTrigger("Attack");
    }
}
