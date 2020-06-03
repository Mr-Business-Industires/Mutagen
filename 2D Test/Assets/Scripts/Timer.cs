using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timeUntilDeath = 5;
    bool controlled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controlled)
        {
            CountDown();
            controlled = false;
        }
    }
    IEnumerator CountDown()
    {
        Debug.Log("Started Enemy Destruction At: " + Time.time);
        yield return new WaitForSeconds(timeUntilDeath);
        //SEND A COMMAND FOR THE MAIN CHARACTER TO DIE
        Destroy(this);
    }
}
