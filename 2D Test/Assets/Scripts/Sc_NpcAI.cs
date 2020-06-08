using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sc_NpcAI : MonoBehaviour
{
    public bool seeing = false;
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

    public NavMeshAgent agent;

    public GameObject pointList;
    Sc_CharacterMovement charMovRef;


    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        timeBtwShots = startTimeBtwShots;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        charMovRef = gameObject.GetComponent<Sc_CharacterMovement>();
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
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector2 directionToPlayer = player.position - transform.position;
        //seeing = ObjectInSight("Player", directionToPlayer);
        if (!charMovRef.controlled)
        {
            if (Vector2.Distance(transform.position, player.position) > haltDistance)
            {
                agent.destination = player.position;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < haltDistance && Vector2.Distance(transform.position, player.position) > fleeDistance)
            {
                agent.isStopped = true;
                //transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < fleeDistance)
            {
                Vector3 chosenPoint = pointList.transform.GetChild(1).position;
                float choosePoint = 0;
                for (int i = 0; i > pointList.transform.childCount; i++)
                {
                    choosePoint = (pointList.transform.GetChild(i).position.x - transform.position.x) + (pointList.transform.GetChild(i).position.y - transform.position.y);
                    if (choosePoint <= ((chosenPoint.x - transform.position.x) + (chosenPoint.y - transform.position.y)))
                    {
                        chosenPoint = pointList.transform.GetChild(i).position;
                    }
                }
                Debug.Log("Chose Point" + chosenPoint);
                agent.destination = chosenPoint;


                //agent.destination = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                //transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
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
        else if(charMovRef.controlled)
        {
            agent.isStopped = true;
        }
    }


    public bool ObjectInSight(string tag, Vector3 direction)
    {
        bool inSight = false;

        Ray2D enemyRay = new Ray2D(transform.position, direction);

        RaycastHit2D enemyRayInfo;
        enemyRayInfo = Physics2D.Raycast(transform.position, direction, 20f);

        if (enemyRayInfo.collider.tag == tag)
            inSight = true;

        return inSight;
    }

}
