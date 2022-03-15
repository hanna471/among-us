using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textscr : MonoBehaviour
{
    public Text cointext;
    public coinco coincos;
    // Start is called before the first frame update
    void Start()
    {
        coincos = GameObject.FindWithTag("Player").GetComponent<coinco>();
    }

    // Update is called once per frame
    void Update()
    {
        cointext.text = "x " + coincos.coincount.ToString();
    }
}
