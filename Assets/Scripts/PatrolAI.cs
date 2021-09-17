using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    
    //List of Waypoints
    [SerializeField]
    List<Waypoint> patrolPoints;

    NavMeshAgent agent;
    int currentPatrolIndex;
    bool traveling;
    bool patrolForward;

   

    public void OnEnable()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (patrolPoints != null && patrolPoints.Count >= 2)
        {
            currentPatrolIndex = 0;
            SetDestination();

        }
        else
        {
            Debug.Log("Not Enough patrolPoints");
        }
    }
    public void Update()
    {
        //Checks if destination is reached
       
        if(traveling && agent.remainingDistance <= 1f)
        {
            traveling = false;

            ChangePatrolPoints();
            SetDestination();

        }
        

    }
    //Selects where to move
    private void SetDestination()
    {
        if(patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            agent.SetDestination(targetVector);
            traveling = true;
        }
    }
    //Moves through the list of patrolPoints
    private void ChangePatrolPoints()
    {
        

        if (patrolForward)
        {
            currentPatrolIndex++;

            if(currentPatrolIndex >= patrolPoints.Count)
            {
                currentPatrolIndex = 0;
            }
        }
        else
        {
            if(-- currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}
