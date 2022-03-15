using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscsr : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public Rigidbody rb;
    public float jumpforce;
    public float toground;
    public GameObject jumpP;
    public float basej;
    public int lground;
    // Start is called before the first frame update
    void Start()
    {
        basej = 1.3f;
        lground = LayerMask.NameToLayer("ground");
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        Vector3 move =transform.right*direction.x+transform.forward*direction.z;

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && toground <= basej)
        {
            rb.AddForce(Vector3.up * jumpforce);

            Instantiate(jumpP, transform.position, Quaternion.identity);
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
        basej = 2f;
        jumpforce = 600f;
        Physics.gravity = new Vector3(0, -18, 0);
    }
}


