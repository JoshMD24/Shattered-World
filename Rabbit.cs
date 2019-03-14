using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rabbit : MonoBehaviour {

    //HEALTH/GATHER/DEATH CODE//
    public int health;
    public int resources;


    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Rabbit Hit");
            health--; 

            if(health <= 0)
            {
                die();
            }
            if (tag == "DeadRabbit" && collision.gameObject.tag == "Player")
            {
                resources--;
                if(resources <= 0)
                {
                    despawn();
                }
            }
        }
    }

    void die()
    {
        tag = "DeadRabbit";
        GetComponent<NavMeshAgent>().speed = 0f;
    }

    void despawn()
    {
        Destroy(this.gameObject);
    }


    //RANDOM WALK CODE//
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
