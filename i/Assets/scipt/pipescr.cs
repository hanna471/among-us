using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipescr : MonoBehaviour
{
    public GameObject goomba;
    public int goombacount;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (goombacount>0)



            {
               
                    Instantiate(goomba, spawn.position, spawn.rotation);
                goombacount--;


               
                 
                   

               

                    


            }
           
        }
    }

}
