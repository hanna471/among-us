using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript01 : MonoBehaviour
{
    public GameObject lighton;
    public SpriteRenderer wireEnd;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startpoint;
    Vector3 startPosition;
    private void Start()
    {
        startpoint = transform.parent.position;
        startPosition = transform.position;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        Collider[] colliders = Physics.OverlapBox(curScreenPoint,transform.localScale/2,Quaternion.identity );
        foreach(Collider collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                Debug.Log("touch collider");
                Updatewire(collider.transform.position);
                if(transform.parent.name.Equals(collider.transform.parent.name))
                {
                    Debug.Log("matching");
                    collider.GetComponent<WireScript01>()?.done();
                    done();
                }
                return;
            }
        }

        Updatewire(curPosition);
    }
    private void OnMouseUp()
    {
        Updatewire(startPosition);
    }

    void Updatewire(Vector3 curPosition)
    {
        transform.position = curPosition;

        Vector3 direction = curPosition - startpoint;
        transform.right = direction * transform.lossyScale.x;


        float dist = Vector2.Distance(startpoint, curPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);

    }
    void done()
    {
        lighton.SetActive(true);
        Destroy(this);
    }
}