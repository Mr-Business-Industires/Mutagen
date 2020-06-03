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
    public GameObject son;
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
            other.gameObject.SendMessage("CountDown", this.gameObject);
            gameObject.layer = LayerMask.NameToLayer("Merged");

        }
    }

    public void GameOver ()//Game Over Function
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
