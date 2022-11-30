using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawbridgeScript : MonoBehaviour
{
    private int leverCount = 0;
    public int totalLevers = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeverPulled()
    {
        leverCount++;

        if(leverCount == totalLevers)
        {
            Debug.Log("Opened gate");
        }
    }
}
