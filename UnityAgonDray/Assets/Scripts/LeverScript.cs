using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private bool playerInTrigger = false;
    private bool leverPulled = false;

    public DrawbridgeScript drawbridge;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        leverPulled = false;
        playerInTrigger = false;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && !leverPulled && Input.GetKeyDown(KeyCode.E))
        {
            leverPulled = true;
            drawbridge.LeverPulled();
            animator.SetBool("LeverUp", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInTrigger = true;
            Debug.Log("player entered lever trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = false;
            Debug.Log("Player has exited lever trigger");
        }
    }
}
