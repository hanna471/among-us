using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinco : MonoBehaviour
{
    public int coincount;
    private player playercs;
    // Start is called before the first frame update
    void Start()
    {
        playercs = gameObject.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            coincount++;
            Destroy(other.transform.parent.gameObject);

        }
        if (other.tag == "mushroom")
        {
            print("got mushroom!");
            playercs.gotmushroom();
            Destroy(other.transform.parent.gameObject);


        }
        if (other.tag == "goomba")
        {
            playercs.damage();
        }
    }
    }
