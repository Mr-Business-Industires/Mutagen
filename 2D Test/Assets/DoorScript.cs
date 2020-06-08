using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject doorLeft;
    public GameObject doorRight;
    Animator leftAnimator;
    Animator rightAnimator;


    // Start is called before the first frame update
    void Start()
    {
        leftAnimator = doorLeft.GetComponent<Animator>();
        rightAnimator = doorRight.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //rightAnimator.ResetTrigger("closeRight");
        //leftAnimator.ResetTrigger("closeLeft");
        leftAnimator.SetTrigger("openLeft");
        rightAnimator.SetTrigger("openRight");
        doorRight.GetComponent<BoxCollider2D>().enabled = false;
        doorLeft.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
       // rightAnimator.ResetTrigger("openRight");
        //leftAnimator.ResetTrigger("openLeft");
        leftAnimator.SetTrigger("closeLeft");
        rightAnimator.SetTrigger("closeRight");
        doorRight.GetComponent<BoxCollider2D>().enabled = true;
        doorLeft.GetComponent<BoxCollider2D>().enabled = true;
    }


}
