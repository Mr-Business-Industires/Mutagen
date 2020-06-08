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

    public float visionDistance;

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
        charMovRef = gameObject.GetComponent<Sc_CharacterMovement>();

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

    private void FixedUpdate()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      
        
    }
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector2 directionToPlayer = player.position - transform.position;
        seeing = ObjectInSight("Player", directionToPlayer);

            if (Vector2.Distance(transform.position, player.position) > haltDistance && Vector2.Distance(transform.position, player.position) < visionDistance)
        {
            agent.isStopped = false;
            agent.destination = player.position;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
             else if (Vector2.Distance(transform.position, player.position) > haltDistance)
            {
                agent.isStopped = true;
            Debug.Log("STOPPINGGGG"+ Vector2.Distance(transform.position, player.position));
                //transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < fleeDistance && Vector2.Distance(transform.position, player.position) < visionDistance)
            {
                agent.isStopped = false;
                Vector3 chosenPoint = pointList.transform.GetChild(1).position;
            for (int i = 0; i < pointList.transform.childCount; i++)
            {
                if (Vector3.Distance(pointList.transform.GetChild(i).position, transform.position) < Vector3.Distance(chosenPoint, transform.position))
                {
                    chosenPoint = pointList.transform.GetChild(i).position;
                }
            }
                if(chosenPoint == new Vector3(0,0,0))
                {
                chosenPoint = pointList.transform.GetChild(Random.Range(0, pointList.transform.childCount)).position;
                Debug.Log("HAD TO RANDOMIZE A POINT");
            }
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


    public bool ObjectInSight(string tag, Vector3 direction)
    {
        bool inSight = false;
        
        RaycastHit2D enemyRayInfo;
        enemyRayInfo = Physics2D.Raycast(transform.position, direction, 20f);

        if (enemyRayInfo.collider.tag == tag)
        {
            inSight = true;
            Debug.Log("I SEE DEAD PEPOLE");
        }

        return inSight;
    }

}
