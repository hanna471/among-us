using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskdone : MonoBehaviour
{
    public taskstart startscr;
    public int targetscore;
    public int wireScore;
    // Start is called before the first frame update
    void Start()
    {
      //  startscr = gameObject.GetComponent<taskstart>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void score()
    {
        wireScore++;
        Debug.Log("score" + wireScore);
        if (wireScore >= targetscore)
        {
            finishTask();
        }

    }
    public void finishTask()
    {
        startscr.endTask();
    }
}