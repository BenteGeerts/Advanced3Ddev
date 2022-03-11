using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotate : MonoBehaviour
{
    public int spinSpeed = 1;
    private float angleForHeight = 0;
    public float heightSpeed = .1f;
    private float startYPos;
    // Start is called before the first frame update
    void Start()
    {
        startYPos = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        angleForHeight += heightSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x,
            startYPos + Mathf.Sin(angleForHeight) / 2,
            transform.position.z);

        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

    }
}
