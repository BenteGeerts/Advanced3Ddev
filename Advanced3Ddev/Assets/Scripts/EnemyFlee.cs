using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlee : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Transform seekTarget;
    public float fleeDistance = 5;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, seekTarget.position) <
fleeDistance)
        {
            Vector3 newDirection = transform.position - seekTarget.position;
            newDirection = new Vector3(newDirection.x, 0, newDirection.z);
            newDirection = newDirection.normalized;
            direction = newDirection;
        }
        else
        {
            direction = Vector3.zero;
        }
        transform.position += speed * direction * Time.deltaTime;
    }
}

