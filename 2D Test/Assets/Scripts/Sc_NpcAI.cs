using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_NpcAI : MonoBehaviour
{
    public float guardSpeed = 15f;
    public float scientistSpeed = 7.5f;
    public float otherSpeed = 20f;
    public float guardHaltDistance = 6f;
    public float guardFleeDistance = 5f;
    public float shootDistance = 40f;
    public float scientisitHaltDistance = 100f;
    public float scientisitFleeDistance = 10f;
    public float otherHaltDistance = 3f;
    public float otherFleeDistance = 1f;
    private Transform player;

    private float speed;
    private float fleeDistance; 
    private float haltDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;



    void Start()
    {

        timeBtwShots = startTimeBtwShots;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        
        
            if (gameObject.tag == "Scientist")
            {
                speed = scientistSpeed;
                fleeDistance = scientisitFleeDistance;
                haltDistance = scientisitHaltDistance;
            }
            else if (gameObject.tag == "Gaurd")
            {
                speed = guardSpeed;
                fleeDistance = guardFleeDistance;
                haltDistance = guardHaltDistance;
            }
            else if (gameObject.tag == "Other")
            {
                speed = otherSpeed;
                fleeDistance = otherFleeDistance;
                haltDistance = otherHaltDistance;
            }
        
    }
            void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > haltDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < haltDistance && Vector2.Distance(transform.position, player.position) > fleeDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < fleeDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }



        if (timeBtwShots <= 0 && gameObject.tag == "Gaurd" && Vector2.Distance(transform.position, player.position) < shootDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }


}
