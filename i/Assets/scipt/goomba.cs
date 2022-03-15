using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goomba : MonoBehaviour
{
    public GameObject Goomba;
    public GameObject goombabox;
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
            sqish();


        }
    }
    public void sqish()
    {
        goombabox.SetActive(false);
        Goomba.transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);
        Destroy(Goomba, 0.4f);



    }
}
