using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frrotation : MonoBehaviour
{
    Transform t;
    public float fixedRotation = 5;

    void Start()
    {
        t = transform;
    }

    void Update()
    {
        t.eulerAngles = new Vector3(90, fixedRotation, t.eulerAngles.z);
    }

}
