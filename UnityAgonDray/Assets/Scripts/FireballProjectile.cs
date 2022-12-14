using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int damage;

    [HideInInspector]
    public Vector3 target;

    private Rigidbody rb;
    

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void SetFireballStats(Vector3 t, int dmg, float spd)
    {
        target = t;
        damage = dmg;
        speed = spd;

        Vector3 toTarget = target - this.transform.position;
        toTarget.Normalize();
        toTarget *= speed;

        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = toTarget;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Shoot(Vector3 target)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Dragon" && other.gameObject.tag != "TriggerZone")
        {

            Debug.Log("Collided with " + other.gameObject.name + ". Target was " + target);

            if(other.gameObject.tag == "Player")
            {
                other.GetComponent<PlayerManager>().Damage(damage, Random.Range(0, 5000));
            }
            Destroy(this.gameObject);
        }
        
    }
}
