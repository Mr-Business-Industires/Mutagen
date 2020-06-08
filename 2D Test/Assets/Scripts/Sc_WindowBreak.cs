using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_WindowBreak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Got Here!");
            if (collision.gameObject.GetComponent<SC_ParasiteController>().son == null)
            {
                DestroyWindow();
            }
        }
    }

    public void DestroyWindow()
    {
        Destroy(this);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
