using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class goombascr : MonoBehaviour
{
    public Rigidbody rb;
    public Transform target;
    public NavMeshAgent agent;
    public int lground;
    public soundmanger sound;
    public float toground;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.FindWithTag("sound manager").GetComponent<soundmanger>();
        sound.goombastump();
        agent.enabled = false;
        target = GameObject.FindWithTag("Player").transform;
        lground = LayerMask.NameToLayer("ground");
    }

    // Update is called once per frame
    void Update()
    {
       //if (toground <= 0.2f&&target!=null)
       // {
            agent.enabled = true;

            agent.SetDestination(target.position);
       // }


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
    private void OnTriggerEnter(Collider other)
    {
       
    }
}
