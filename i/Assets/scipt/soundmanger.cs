using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanger : MonoBehaviour
{
    public AudioSource source;
    public float high;
    public float low;
    public AudioClip goombast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goombastump()
    {
       // float vol = Random.Range(low, high);
        source.PlayOneShot(goombast, 1.0f);



    }
}
