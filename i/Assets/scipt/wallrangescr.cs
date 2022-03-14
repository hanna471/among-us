using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallrangescr : MonoBehaviour
{
    public int slowspeed;
    public player pscript;
    // Start is called before the first frame update
    void Start()
    {
       // pscript = GameObject.FindWithTag("Player").GetComponent<player>();


    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            pscript.speed = slowspeed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "wall")
        {
            pscript.speed = pscript.basespeed;
        }

    }
}
