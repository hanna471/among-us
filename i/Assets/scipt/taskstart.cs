using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class taskstart : MonoBehaviour
{
    public GameObject player;
    public GameObject task;
    public Camera playerCamera;
    public Camera taskCamera;
    public Image useButton;
    public bool playerHere = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHere == true)
        {
            startTask();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHere = true;
            useButton.enabled = true;

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHere = false;
            useButton.enabled = false;
        }
       
        
    }
    public void startTask()
    {
        task.SetActive(true);
        playerCamera.enabled = false;
        taskCamera.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        player.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
   }
}
