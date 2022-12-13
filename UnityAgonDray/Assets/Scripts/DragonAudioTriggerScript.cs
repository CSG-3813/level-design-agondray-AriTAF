using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAudioTriggerScript : MonoBehaviour
{
    private bool audioTriggered = false;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !audioTriggered)
        {
            audioTriggered = true;
            audioSource.Play();
        }
    }
}
