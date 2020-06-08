using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_CharacterMovement : MonoBehaviour
{
    Rigidbody2D body;
    //public enum CharacterClass { Scientist, Gaurd, Other};
    public bool controlled = false;
    public Animator animController;
    GameObject parasiteRef;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float runSpeed = 7.0f;
    public float scientistSpeed = 30.0f;
    public float guardSpeed = 30.0f;
    public float otherSpeed = 30.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //CharacterClass Npc;
       
        //Npc = CharacterClass.Scientist;

    }

    void Update()
    {
        if (controlled)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            parasiteRef.transform.position = transform.position;
        }

        if (horizontal != 0 || vertical != 0)
        {
            animController.SetBool("IsMoving", true);
        }

        else if (horizontal == 0 && vertical == 0)
        {
            animController.SetBool("IsMoving", false);
        }

    }

    private void FixedUpdate()
    {
        if (controlled)
        {   
            if (gameObject.tag == "Scientist")
            {
                runSpeed = scientistSpeed;
            }
            else if (gameObject.tag == "Gaurd")
            {
                runSpeed = guardSpeed;
            }
            else if (gameObject.tag == "Other")
            {
                runSpeed = otherSpeed;
            }

                if (horizontal != 0 && vertical != 0) // Check for diagonal movement
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

            float angle = Mathf.Atan2(-horizontal, vertical) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
        }
    }


    public void StartControl (GameObject parasite)
    {
        if(!controlled)
        {
            controlled = true;
            GameObject.Find("Score").SendMessage("AddOne");
        }
        parasiteRef = parasite;
    }

}