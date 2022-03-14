using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wires : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newposition.z = 0;

        transform.position = newposition;
    }
}
