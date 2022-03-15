using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickscr : MonoBehaviour
{
    public GameObject delete;  
  
    public int hitcount;
  
    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
      
        {

            if (hitcount == 0)
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
            if (other.transform.localScale == new Vector3(2f, 2f, 2f))
                hitcount -= 1;





            }


        }
    }


