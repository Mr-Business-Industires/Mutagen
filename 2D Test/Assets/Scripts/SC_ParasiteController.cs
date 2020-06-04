using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SC_ParasiteController : MonoBehaviour
{
    public int speed;
    bool CanJump;
    bool attached;
    public Rigidbody2D rb;
    public GameObject son = null;
    // Start is called before the first frame update
    void Start()
    {

        CanJump = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && CanJump)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            Destroy(son);
            attached = false;
            FirePlayer();
        }
        if(!CanJump && rb.velocity == new Vector2(0, 0)) //Death when the character stops moving
                GameOver();
        if (Input.GetKeyDown(KeyCode.R))
        {
            CanJump = true;
        }
        if (attached)
        {
            //son.transform.position = transform.position; MOVED TO THE ENEMY
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Scientist" || other.gameObject.tag == "Gaurd" || other.gameObject.tag == "Other")
        {
            son = other.gameObject;
            transform.position = son.transform.position;
            attached = true;
            rb.velocity = new Vector2(0, 0);
            other.gameObject.SendMessage("CountDown", this.gameObject);
            gameObject.layer = LayerMask.NameToLayer("Merged");
            CanJump = true;

        }
    }

    public void GameOver ()//Game Over Function
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    /*void ToggleColliders()
    {
        for(int i = 0; i<colliders.Length; i++)
        {
            colliders[i].enabled = !colliders[i].enabled;
        }
        if ((son != null))
        {
            colliders[0].enabled = true;
            colliders[1].enabled = true;
            colliders = this.gameObject.GetComponents<Collider2D>();
            Collider2D[] colliders;
            Debug.Log("ToggledColliders");
            ToggleColliders();
        }
        ToggleColliders();
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
