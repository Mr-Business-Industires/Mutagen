using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_GameTime : MonoBehaviour
{
    public Text theTime;

    private float startTime;
    public bool countTime = false;

    // Start is called before the first frame update
    void Start()
    {
        theTime = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            theTime.text = minutes + ":" + seconds;
        }

    }

    public void TimerStart()
    {
        startTime = Time.time;
        countTime = true;
    }
}
