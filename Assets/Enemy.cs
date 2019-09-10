using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyFSM
{
    Patrol,
    Chase,
    Search
}

public class Enemy : MonoBehaviour
{
    EnemyFSM enemyState;

    public Cell enemy;
    public float aggroRange;

    public Vector2 patrolTarget;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyFSM.Patrol;
        patrolTarget = new Vector2(Random.Range(-40.0f, 33.0f), Random.Range(-19.0f, 18.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameManager.instance.player.transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);
        List<Transform> foods = SpawnManager.instance.foodList;

        switch (enemyState)
        {
            case EnemyFSM.Chase:
                enemy.Move(playerPos);
                if (distance >= aggroRange)
                    enemyState = EnemyFSM.Patrol;
                break;
            case EnemyFSM.Patrol:
                if (distance < aggroRange)
                    enemyState = EnemyFSM.Chase;
                if (SearchFood(foods) != null)
                    enemyState = EnemyFSM.Search;
                 if ((Vector2)transform.position == patrolTarget)
                    patrolTarget = new Vector2(Random.Range(-40.0f, 33.0f), Random.Range(-19.0f, 18.0f));
                 enemy.Move(patrolTarget);
                break;
            case EnemyFSM.Search:
                if (distance < aggroRange)
                    enemyState = EnemyFSM.Chase;
                if (SearchFood(foods) == null)
                    enemyState = EnemyFSM.Patrol;
                else
                    enemy.Move(SearchFood(foods).position);
                break;
        }   
    }

    public Transform SearchFood(List<Transform> foods)
    {
        Transform temp = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform t in foods)
        {
            float foodDistance = Vector3.Distance(transform.position, t.position);

            if (foodDistance < minDistance && foodDistance < 5.0f)
            {
                temp = t;
                minDistance = foodDistance;
            }
        }

        return temp;
    }
}
