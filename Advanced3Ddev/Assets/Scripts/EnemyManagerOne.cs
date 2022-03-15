using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerOne : MonoBehaviour
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
    float time = 10f;
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
                        Search();
                    }

                    if(GameManager.GetInstance().one)
                    {
                        Flee();
                    }
                    break;
                }
            case EnemyState.Flee:
                {
                    //StartCoroutine(CountDownStart());
                    time = time - Time.deltaTime;
                    Debug.Log(time);
                    if (time < 0f)
                    {
                        time = 10f;
                        Idle();
                    }
                        break;
                }
            case EnemyState.Search:
                {
                    if(Vector3.Distance(transform.position, target.position) > distance)
                    {
                        Idle();
                    }
                    if (GameManager.GetInstance().one)
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
            GameManager.GetInstance().one = false;
        }
        void Flee()
        {
            Debug.Log("switching to flee");
            state = EnemyState.Flee;
            fleeComponent.enabled = true;
            idleComponent.enabled = false;
            searchComponent.enabled = false;
            GameManager.GetInstance().one = false;
        }

        void Search()
        {
            Debug.Log("switching to search");
            state = EnemyState.Search;
            fleeComponent.enabled = false;
            idleComponent.enabled = false;
            searchComponent.enabled = true;
            GameManager.GetInstance().one = false;
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
            Idle();
        }

    }
}
