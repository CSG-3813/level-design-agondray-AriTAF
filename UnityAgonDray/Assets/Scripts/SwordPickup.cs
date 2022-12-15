using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
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
        Debug.Log("Trigger entered by " + other.gameObject);

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerManager>().CollectSword();
            this.gameObject.SetActive(false);
        }
    }
}
