using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyFSM
{
    Patrol,
    Chase
}

public class Enemy : MonoBehaviour
{
    EnemyFSM enemyState;

    public Cell enemy;
    public float aggroRange;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyFSM.Patrol;
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
                if (distance < aggroRange)
                    enemy.Move(playerPos);
                else
                    enemyState = EnemyFSM.Patrol;
                break;
            case EnemyFSM.Patrol:
                Transform temp = null;
                float minDistance = Mathf.Infinity;
                if (distance >= aggroRange)
                {
                    foreach (Transform t in foods)
                    {
                        float foodDistance = Vector3.Distance(transform.position, t.position);
                        if (foodDistance < minDistance)
                        {
                            temp = t;
                            minDistance = foodDistance;
                        }
                    }
                    enemy.Move(temp.position);
                }
                else
                    enemyState = EnemyFSM.Chase;
                break;
        }   
    }
}
