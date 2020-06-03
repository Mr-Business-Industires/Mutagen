using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ParasiteController : MonoBehaviour
{
    public int speed;
    bool CanJump;
    bool attached;
    public Rigidbody2D rb;
    public GameObject son;
    // Start is called before the first frame update
    void Start()
    {
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(1))
            {
            if (CanJump == true)
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                Destroy(son);
                attached = false;

                FirePlayer();
            }
            }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CanJump = true;
        }
        if (attached)
        {
            son.transform.position = transform.position;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CanJump = true;
            son = other.gameObject;   
            attached = true;
            gameObject.layer = LayerMask.NameToLayer("Merged");

        }
    }
    
    /*void toggleColliders()
    {
        if
    }*/


    void FirePlayer()
        {
        CanJump = false;
        Vector2 mousePosition = Input.mousePosition;
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Debug.Log(mousePosition);
        rb.velocity = ((mousePosition - playerPosition) * 10);
            }
    }
