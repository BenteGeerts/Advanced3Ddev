using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Transform seekTarget;
    public float stoppingDistance;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newDirection = seekTarget.position - transform.position;
        newDirection = new Vector3(newDirection.x + stoppingDistance, 0, newDirection.z);
        newDirection = newDirection.normalized;
        direction = newDirection;
        transform.position += speed * direction * Time.deltaTime;
    }
}
