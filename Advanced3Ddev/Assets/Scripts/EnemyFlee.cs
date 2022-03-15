using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlee : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Transform seekTarget;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
        Vector3 newDirection = transform.position - seekTarget.position;
        newDirection = new Vector3(newDirection.x, 0, newDirection.z);
        newDirection = newDirection.normalized;
        direction = newDirection;

     
        transform.position += speed * direction * Time.deltaTime;
    }
}

