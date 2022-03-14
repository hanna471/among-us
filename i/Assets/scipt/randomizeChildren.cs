using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizeChildren : MonoBehaviour
{
    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            int newspot = Random.Range(0, transform.childCount);
            Vector3 temp = transform.GetChild(i).position;
            transform.GetChild(i).position = transform.GetChild(newspot).position;
            transform.GetChild(newspot).position = temp;
        }
    }
}
