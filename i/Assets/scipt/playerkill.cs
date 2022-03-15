using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerkill : MonoBehaviour
{

    public float cooldownCurr;
    public float cooldownMax;
    public bool oncooldown;
    public Text cooldownnumber;
    public float volume;
    public AudioClip killclip;
    public AudioSource killsound;
    public Image  killbutton;
    public GameObject[] deadbody;
    private GameObject targetplayer;
    public bool cankill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldownCurr > 0)
        {
            cooldownCurr -= Time.deltaTime;
            oncooldown = true;
            displaycooldown(cooldownCurr);
        }
        else if (cooldownCurr <= 0) 
        {
            if (cooldownnumber != null)
            {
                cooldownnumber.color = new Color(255, 255, 255, 0);
            }
            cooldownCurr = 0;
           // displaycooldown(cooldownCurr);
            oncooldown = false;
        }
        if (cankill == true)
        {
           // killbutton.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                kill();
            }

        }
        

        
      
          
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && oncooldown == false)
        {

            cankill = true;
            killbutton.enabled = true;
            targetplayer = other.gameObject;
            }
        }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cankill = false;
            killbutton.enabled = false;
        }
    }
    public void kill()
    {
        killsound.PlayOneShot(killclip, volume);
        spawnBody();
        Destroy(targetplayer);
        cankill = false;
        killbutton.enabled = false;
        cooldownCurr = cooldownMax;
        cooldownnumber.color = new Color(255, 255, 255, 1);
       
        

    }
    public void spawnBody()
    {
        int colorid = 0;
        string name = targetplayer.name;
        switch (name)
        {
            case "playerBlue":
                colorid = 0;
                break;
            case "playerBrown":
                colorid = 1;
                break;

            case "playerRed":
                colorid = 2;
                break;

            case "playerYellow":
                colorid = 3;
                break;
        }
        Instantiate(deadbody[colorid], targetplayer.transform.position, Quaternion.identity);
    }
    public void displaycooldown(float c)
    {
        c++;
        int second = Mathf.FloorToInt(c % 60);
        cooldownnumber.text = second.ToString();

    }
}
