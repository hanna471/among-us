using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class reportscr : MonoBehaviour
{
    public GameObject votingmenu;
    private IEnumerator reported;
    private GameObject[] reportmenu;
    private Vector3 position;
    private GameObject[] deadbodys;
    public float volume;
    public AudioClip reportclip;
    public AudioSource reportsound;
    public Image reportbutton;
    public GameObject deadbody;
    private GameObject[] players;
    public bool canreport;
    // Start is called before the first frame update
    void Start()
    {
        reported = pause();
        Time.timeScale = 1;
        reportmenu = GameObject.FindGameObjectsWithTag("dead body report");
        hideReport();
    }

    // Update is called once per frame
    void Update()
    {
        if (canreport == true)
        {
            reportbutton.enabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                report();
            }

        }
        else
        {
            reportbutton.enabled = false;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "dead body")
        {
            canreport = true;
            deadbody = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "dead body")
        {

            canreport = false;
        }
    }
    void report()
    {
        reportsound.PlayOneShot(reportclip, volume);
        position = new Vector3(13.6f, -5, 40.1f);
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            player.transform.position = position;
            position.x = position.x + 4;

        }
        deadbodys = GameObject.FindGameObjectsWithTag("dead body");
        if(deadbodys != null)
        {
            foreach(GameObject deadb in deadbodys)
            {
                Destroy(deadb);
            }
        }
        canreport = false;
        showReport();
    }
    public void hideReport()
    {
        foreach(GameObject g in reportmenu)
        {
            g.SetActive(false);
        }
        

    }
    public void showReport()
    {
        foreach(GameObject g in reportmenu)
        {
            g.SetActive(true);
        }
         StartCoroutine(reported);
    }
    public IEnumerator pause()
    {
        yield return new WaitForSeconds(2.5f);
        hideReport();
        votingmenu.GetComponent<reportmenu>().startvote();

        StopCoroutine(reported);

    }
}
