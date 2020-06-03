using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GaurdAi : MonoBehaviour
{
    public float speed;
    public float haltDistance = 3f;
    public float fleeDistance = 1f;
    private Transform player;

   
        void Start()
        {
           player  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        }

    
}