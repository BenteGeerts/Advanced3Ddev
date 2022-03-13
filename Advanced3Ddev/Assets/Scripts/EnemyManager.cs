using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enum EnemyState
    {
        Wander,
        Flee,
        Seek,
    }
        EnemyState state;
        public Transform target;
        public float fleeDistance;
        public EnemyFlee fleeComponent;
        public EnemySearch seekComponent;
        public EnemyIdle wanderComponent;
        // Start is called before the first frame update
        void Start()
        {
            state = EnemyState.Wander;
            fleeComponent = fleeComponent.gameObject.GetComponent<EnemyFlee>();
            wanderComponent = wanderComponent.gameObject.GetComponent<EnemyIdle>();
            seekComponent = seekComponent.gameObject.GetComponent<EnemySearch>();
        }
        void Update()
        {
            switch (state)
            {
                case EnemyState.Wander:
                    {
                        if (Vector3.Distance(transform.position, target.position) < fleeDistance)
                        {
                            Debug.Log("switching to Flee");
                            state = EnemyState.Flee;
                            fleeComponent.enabled = true;
                            wanderComponent.enabled = false;
                            seekComponent.enabled = false;
                        }
                        break;
                    }
                case EnemyState.Flee:
                    {
                        if (Vector3.Distance(transform.position, target.position) >= fleeDistance)
                        {
                            Debug.Log("switching to Wander");
                            state = EnemyState.Wander;
                            fleeComponent.enabled = false;
                            wanderComponent.enabled = true;
                            seekComponent.enabled = false;
                        }
                        break;
                    }
            }

            if (GameManager.GetInstance().running == true)
            {
                Debug.Log("I am scared........");
                StartCoroutine(wait10Seconds());
                GameManager.GetInstance().running = false;
            }

            IEnumerator wait10Seconds()
            {
                Debug.Log("Started Coroutine at timestamp : " + Time.time);
                yield return new WaitForSeconds(10);
                Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            }
        }

}
