using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookscr : MonoBehaviour
{
    public float xRotation;
    public Transform body;
    public float mouseS = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseS*Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseS * Time.deltaTime;


        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mousex);
       

    }
}
