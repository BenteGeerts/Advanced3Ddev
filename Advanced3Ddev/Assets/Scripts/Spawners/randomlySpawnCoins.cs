using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomlySpawnCoins : MonoBehaviour
{
    public GameObject coin;
    int xPos;
    int enemyCount;
    int zPos;


    void Start()
    {
        StartCoroutine(CoinDrop());
    }


    IEnumerator CoinDrop()
    {
        while(enemyCount < 40)
        {
            xPos = Random.Range(216, 481);
            zPos = Random.Range(-56, 18);
            Instantiate(coin, new Vector3(xPos, -1.38f, zPos), Quaternion.identity);
            yield return null;
            enemyCount++;
        }
    }
}
