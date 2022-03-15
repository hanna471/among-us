using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reportmenu : MonoBehaviour
{
    private IEnumerator wait;
    public GameObject votingUI;
    public static bool voting = false;
    private void Start()
    {
        wait = pause();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void endvote()
    {

    }
    public void startvote()
    {
        votingUI.GetComponent<Animator>().SetBool("voting", true);
        StartCoroutine(wait);
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        StopCoroutine(wait);

    }
}
