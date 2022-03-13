using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Flee,
        Search,
    }
    EnemyState state;
    public Transform target;
    public float distance = 20;
    public EnemyFlee fleeComponent;
    public EnemySearch searchComponent;
    public EnemyIdle idleComponent;
    void Start()
    {
        fleeComponent.enabled = false;
        idleComponent.enabled = false;
        searchComponent.enabled = true;
        state = EnemyState.Search;
        fleeComponent = fleeComponent.gameObject.GetComponent<EnemyFlee>();
        idleComponent = idleComponent.gameObject.GetComponent<EnemyIdle>();
        searchComponent = searchComponent.gameObject.GetComponent<EnemySearch>();
    }
    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                {
                    if (Vector3.Distance(transform.position, target.position) < distance)
                    {
                        Debug.Log("switching to search");
                        state = EnemyState.Flee;
                        fleeComponent.enabled = false;
                        idleComponent.enabled = false;
                        searchComponent.enabled = true;
                    }

                    if(GameManager.GetInstance().running)
                    {
                        Debug.Log("switching to flee");
                        state = EnemyState.Flee;
                        fleeComponent.enabled = true;
                        idleComponent.enabled = false;
                        searchComponent.enabled = false;
                        GameManager.GetInstance().running = false;
                    }
                    break;
                }
            case EnemyState.Flee:
                {
                    if (Vector3.Distance(transform.position, target.position) >= distance)
                    {
                        Debug.Log("switching to idle");
                        state = EnemyState.Idle;
                        fleeComponent.enabled = false;
                        idleComponent.enabled = true;
                        searchComponent.enabled = false;
                    }
                    break;
                }
            case EnemyState.Search:
                {
                    if(Vector3.Distance(transform.position, target.position) > distance)
                    {
                        Debug.Log("switching to idle");
                        state=EnemyState.Idle;
                        fleeComponent.enabled = false;
                        idleComponent.enabled = true;
                        searchComponent.enabled = false;
                    }
                    if (GameManager.GetInstance().running)
                    {
                        Debug.Log("switching to flee");
                        state = EnemyState.Flee;
                        fleeComponent.enabled = true;
                        idleComponent.enabled = false;
                        searchComponent.enabled = false;
                        GameManager.GetInstance().running = false;
                    }
                    break;
                }
        }
            /*IEnumerator wait10Seconds()
            {
                Debug.Log("Started Coroutine at timestamp : " + Time.time);
                yield return new WaitForSeconds(10);
                Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            }*/

        /*if (GameManager.GetInstance().running == true)
                    {
                        Debug.Log("I am scared........");
                        StartCoroutine(wait10Seconds());
                        GameManager.GetInstance().running = false;
                    }
                    break;*/
    }
}
