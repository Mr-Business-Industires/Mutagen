using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timeUntilDeath = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator CountDown(GameObject parasite)
    {
        this.GetComponent<Sc_CharacterMovement>().enabled = true;
        this.GetComponent<Sc_CharacterMovement>().SendMessage("StartControl", parasite);
        Debug.Log("Started Enemy Destruction At: " + Time.time);
        yield return new WaitForSeconds(timeUntilDeath);
        parasite.SendMessage("GameOver");
        Destroy(this);
    }
}
