using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    
    bool maptoggle;
    public AudioSource walksound;
    public Animator anim;
    public int health;
    public bool doublejump;
    public float speed;
    public float basespeed;
    public Vector3 direction;
    public Rigidbody rb;
    public float jumpforce;
    public float toground;
    public GameObject jumpP;
    public float basej;
    public int lground;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        maptoggle = false;
        map.SetActive(false);
        speed = basespeed;
        basej = 1.3f;
        lground = LayerMask.NameToLayer("ground");
        Physics.gravity = new Vector3(0, -17, 0);

        anim = gameObject.transform.Find("am us").GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        //// rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        Vector3 move = transform.right * direction.x + transform.forward * direction.z;

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        if(direction.x!=0||direction.z != 0)
        {
            anim.SetBool("moving", true);
            if (!walksound.isPlaying ||Time.timeScale==0)
            {
                walksound.Play();

            }


        }else if(direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("moving", false);
            walksound.Stop();

        }
         if (Input.GetKey(KeyCode.LeftShift))
        {
           // speed = 15;


        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
          //  speed = 8;


        }


        if (Input.GetKeyUp(KeyCode.M))
        {
            maptoggle = !maptoggle;
           
            
                map.SetActive(maptoggle);
            }
            
        }

        private void FixedUpdate()
    {
        RaycastHit hitinfo;
        Physics.Raycast(transform.position, -Vector3.up, out hitinfo);
        if (hitinfo.transform.gameObject.layer == lground)
        {

            toground = hitinfo.distance;

        }



    }
    public void gotmushroom()
    {
        gameObject.transform.localScale = new Vector3(2, 2, 2);
        basej = 2.1f;
        jumpforce = 900f;
        Physics.gravity = new Vector3(0, -18, 0);
    }
    public void lossmushroom()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        basej = 1.1f;
        jumpforce = 820f;
        Physics.gravity = new Vector3(0, -17, 0);
    }
    public void damage()
    {

        print("got damage!");
        lossmushroom();
        health--;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



        }
    }
   
}
