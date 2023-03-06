using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigTeddyBear : MonoBehaviour
{
    //Patrol variables
    float distanceToPatrolPoint = 0.0f;
    Vector3 startingPos = Vector3.zero;
    bool patrol = true;
    bool patrolSwitch = true;

    //Patrol access points
    GameObject[] patrolPoints;
    GameObject patrolPoint;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;

        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        patrolPoint = patrolPoints[Random.Range(0, patrolPoints.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void Patrol()
    {
        //Calculate distance

        if (patrolSwitch)
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoint.transform.position);
            agent.destination = patrolPoint.transform.position;
            if (distanceToPatrolPoint<agent.stoppingDistance) patrolSwitch = false;

        }
        else 
        {
            distanceToPatrolPoint=Vector3.Distance(transform.position, startingPos);
            agent.destination = startingPos;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = true;
        }
    
    }
}
