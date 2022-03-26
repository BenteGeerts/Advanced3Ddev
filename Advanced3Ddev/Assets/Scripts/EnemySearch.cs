using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySearch : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float stoppingDistance;
    NavMeshAgent agent;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            agent.isStopped = false;
            Vector3 newDirection = target.transform.position - transform.position;
            newDirection = new Vector3(newDirection.x + stoppingDistance, 0, newDirection.z);
            newDirection = newDirection.normalized;
            transform.LookAt(target.transform);
            direction = newDirection;
            transform.position += speed * direction * Time.deltaTime;
        }
        else
        {
            agent.isStopped = true;
        }
       
    }
}
