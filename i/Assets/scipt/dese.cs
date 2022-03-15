using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dese : MonoBehaviour
{


    public float mytime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mytime >=0)
        {
            mytime -= Time.deltaTime;


        }
        if (mytime <= 0)
        {
            Destroy(gameObject);

        }
        
    }
}
