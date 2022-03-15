using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySearch : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Transform seekTarget;
    public float stoppingDistance;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, seekTarget.position) > stoppingDistance)
        {
            agent.isStopped = false;
            Vector3 newDirection = seekTarget.position - transform.position;
            newDirection = new Vector3(newDirection.x + stoppingDistance, 0, newDirection.z);
            newDirection = newDirection.normalized;
            direction = newDirection;
            transform.position += speed * direction * Time.deltaTime;
        }
        else
        {
            agent.isStopped = true;
        }
       
    }
}
