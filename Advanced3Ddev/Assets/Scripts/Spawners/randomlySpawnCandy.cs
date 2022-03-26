using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomlySpawnCandy : MonoBehaviour
{
    public GameObject candy;
    int xPos;
    int enemyCount;
    int zPos;


    void Start()
    {
        StartCoroutine(CandyDrop());
    }

    IEnumerator CandyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(216, 481);
            zPos = Random.Range(-56, 18);
            Instantiate(candy, new Vector3(xPos, -2.4f, zPos), Quaternion.identity);
            yield return null;
            enemyCount++;
        }
    }
}
