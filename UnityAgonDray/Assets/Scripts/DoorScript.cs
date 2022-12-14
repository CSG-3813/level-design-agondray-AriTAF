using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator doorAnimator;
    public bool isBigDoor = false;
    public DrawbridgeScript drawbridge;

    private bool playerInTrigger = false;
    private bool doorOpen = false;
    private bool playerHasKey;

    // Start is called before the first frame update
    void Start()
    {
        playerInTrigger = false;
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && !doorOpen && playerHasKey && Input.GetKeyDown(KeyCode.E))
        {
            doorOpen = true;
            doorAnimator.SetTrigger("OpenDoor");
            if (isBigDoor)
            {
                drawbridge.BigDoorOpened();
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = true;
            Debug.Log("player entered door trigger");
            playerHasKey = other.GetComponent<PlayerManager>().hasKey;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = false;
            Debug.Log("Player has exited door trigger");
        }
    }
}
