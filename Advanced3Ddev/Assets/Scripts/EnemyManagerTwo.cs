using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerTwo : MonoBehaviour
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
    public float countDownTime;
    void Start()
    {
        fleeComponent.enabled = true;
        idleComponent.enabled = false;
        searchComponent.enabled = false;
        state = EnemyState.Flee;
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
                    StartCoroutine(CountDownStart());
                    break;
                }
            case EnemyState.Flee:
                {
                    if(Vector3.Distance(transform.position, target.position) < distance)
                    {
                        Search();
                    }
                    if(GameManager.GetInstance().running)
                    {
                        Idle();
                    }
                    break;
                }
            case EnemyState.Search:
                {
                    if(GameManager.GetInstance().running)
                    {
                        Idle();
                    }
                    if(Vector3.Distance(transform.position, target.position)> distance)
                    {
                        Flee();
                    }
                    break;
                }
        }
         void Idle()
         {
            Debug.Log("switching to idle");
            state = EnemyState.Idle;
            fleeComponent.enabled = false;
            idleComponent.enabled = true;
            searchComponent.enabled = false;
         }
        void Flee()
        {
            Debug.Log("switching to flee");
            state = EnemyState.Flee;
            fleeComponent.enabled = true;
            idleComponent.enabled = false;
            searchComponent.enabled = false;
            GameManager.GetInstance().running = false;
        }

        void Search()
        {
            Debug.Log("switching to search");
            state = EnemyState.Search;
            fleeComponent.enabled = false;
            idleComponent.enabled = false;
            searchComponent.enabled = true;
        }

        IEnumerator CountDownStart()
        {
            while(countDownTime > 0)
            {
                yield return new WaitForSeconds(1f);
                countDownTime = countDownTime - Time.deltaTime;
                Debug.Log(countDownTime);
            }

            yield return new WaitForSeconds(1f);
            countDownTime = 10;
            Search();
        }

    }
}
