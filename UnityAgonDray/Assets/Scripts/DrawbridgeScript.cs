using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawbridgeScript : MonoBehaviour
{
    private int leverCount = 0;
    public int totalLevers = 2;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BigDoorOpened()
    {
        animator.SetTrigger("CloseDrawbridge");
    }

    public void LeverPulled()
    {
        leverCount++;

        if(leverCount == totalLevers)
        {
            animator.SetTrigger("OpenDrawbridge");
            Debug.Log("Opened gate");
        }
    }
}
