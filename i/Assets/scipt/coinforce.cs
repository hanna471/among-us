using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinforce : MonoBehaviour
{
    public Rigidbody bean;
    public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Random.Range(-15, 15), 10, Random.Range(-15, 15));
        bean.AddForce(direction * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
