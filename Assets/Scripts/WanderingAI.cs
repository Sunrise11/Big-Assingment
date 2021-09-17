using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    //Radius in which the AI can Wander
    float wanderRadius;
    [SerializeField]
    //how long the AI waits before moving;
    float wanderTimer;

     NavMeshAgent agent;
     float timer;
    void OnEnable()
    {
        agent = this.GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        //Checks if its time to move and resets timer
        if(timer >= wanderTimer)
        {
            Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPosition);

            timer = 0;
        }
    }

    //Selects the position where the AI moves to
    public static  Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;

    }
}
