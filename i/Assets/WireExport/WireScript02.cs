using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript02 : MonoBehaviour
{
    private taskdone task;
    private Vector3 target;
    public bool wiredone;
    public GameObject Lighton;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startPoint;
    private Vector3 startPosition;

    public SpriteRenderer wireEnd;

    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
        task = GameObject.FindWithTag("taskdone").GetComponent<taskdone>();
    }
    void OnMouseDown()
    {
        if (wiredone == true)
        {
            UpdateWire(target);
            return;
        }
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        if (wiredone == true)
        {
            UpdateWire(target);
            return;
        }
        
        


            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            Collider[] colliders = Physics.OverlapBox(curPosition, transform.localScale / 2, Quaternion.identity);
            foreach (Collider collider in colliders)
            {
                //Debug.Log("Touched collider " + collider.ToString());
                if (collider.gameObject != gameObject)
                {
                    target = collider.transform.position;
                    UpdateWire(collider.transform.position);
                    if (transform.parent.name.Equals(collider.transform.parent.name))
                    {
                        collider.GetComponent<WireScript02>()?.done();
                        done();
                    }
                    return;
                }
            }

            UpdateWire(curPosition);

        }
    

    private void OnMouseUp()
    {
        if (wiredone == false)
        {
            UpdateWire(startPosition);
        }
        else
        {
            UpdateWire(target);
        }
       
    }

    void UpdateWire(Vector3 curPosition)
    {
        if (curPosition == Vector3.zero)
        {
            curPosition = startPosition;
        }
        transform.position = curPosition;
        //update direction
        Vector3 direction = curPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, curPosition);

        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
    void done()
    {
        Lighton.SetActive(true);
        wiredone = true;
        task.score(); 
       // Destroy(this);
    }
}