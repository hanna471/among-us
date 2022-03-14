using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocksr : MonoBehaviour
{
    public GameObject delete;
    public float timer;
    public Animator anim;
    public enum type {coin,mush,block,random };
    public type blocktype;
    public GameObject coin;
    public GameObject mushroom;
    public Transform spawn;
    public int hitcount;
    public bool block;
    // Start is called before the first frame update
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {
        if (block == true)
        {

            if (hitcount == 0)
            {
                Instantiate(delete, transform.position, transform.rotation);
                Destroy(gameObject);


            }
            return;

        }
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;


        }


        if (timer <= 0) 
        {

            anim.SetBool("hit",false);
            if (hitcount <= 0)
            {
                Instantiate(delete, transform.position, transform.rotation);
                Destroy(gameObject);


            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (block==true&&other.transform.localScale==new Vector3(2f,2f,2f))



            anim.SetBool("hit", true);
            timer = 0.5f;

            print("active");
            switch (blocktype)
            {
                case type.coin:
                    Instantiate(coin, spawn.position, spawn.rotation);
                    break;


                case type.mush:
                    Instantiate(mushroom, spawn.position, spawn.rotation);
                    break;

                case type.block:
                    
                    break;


            }
            hitcount -= 1;

        }
    }


}
