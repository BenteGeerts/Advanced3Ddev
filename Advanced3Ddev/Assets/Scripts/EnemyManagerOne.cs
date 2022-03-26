using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManagerOne : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Flee,
        Search,
    }
    EnemyState state;
    public GameObject target;
    public float distance = 20;
    public EnemyFlee fleeComponent;
    public EnemySearch searchComponent;
    public EnemyIdle idleComponent;
    public float countDownTime;
    float time = 10f;
    float lastAttackTime = 0;
    float attackCoolDown = 2;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
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
                    if (Vector3.Distance(transform.position, target.transform.position) < distance)
                    {
                        Search();
                    }

                    if(GameManager.GetInstance().candyTaken)
                    {
                        Flee();
                    }
                    break;
                }
            case EnemyState.Flee:
                {
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
                    if(Vector3.Distance(transform.position, target.transform.position) > distance)
                    {
                        Idle();
                    }
                    if (GameManager.GetInstance().candyTaken)
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
        }

        void Search()
        {
            Debug.Log("switching to search");
            state = EnemyState.Search;
            fleeComponent.enabled = false;
            idleComponent.enabled = false;
            searchComponent.enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider entered");
        if(state == EnemyState.Flee)
        {
            GameManager.GetInstance().AddGhost();
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            if (state == EnemyState.Search || state == EnemyState.Idle)
            {
                GameManager.GetInstance().LoseHealth();
            }
        }
    }
}
