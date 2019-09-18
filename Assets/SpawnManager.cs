using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform food;
    public Transform enemy;
    public int foodCount;
    public int enemyCount;
    public float foodInterval = 1.0f;
    public float enemyInterval = 10.0f;
    public List<Transform> foodList;

    [SerializeField] Transform foodParent;

    private float foodLastSpawned;
    private float enemyLastSpawned;

    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            SpawnFood();
        }
        SpawnEnemy();
        foodLastSpawned = Time.time;
        enemyLastSpawned = Time.time;
    }

    void Update()
    {
        if (Time.time - foodLastSpawned >= foodInterval && foodCount < 100)
        {
            SpawnFood();
            foodLastSpawned = Time.time;
        }
        if (Time.time - enemyLastSpawned >= enemyInterval && enemyCount < 3)
        {
            SpawnEnemy();
            enemyLastSpawned = Time.time;
        }
    }

    public void SpawnFood()
    {
        Transform foodToAdd = Instantiate(food, new Vector2(Random.Range(-40.0f, 33.0f), Random.Range(-19.0f, 18.0f)), Quaternion.identity);
        foodToAdd.SetParent(foodParent);
        foodList.Add(foodToAdd);
        foodCount++;
    }

    public void RemoveFromList(Transform foodToRemove)
    {
        foodList.Remove(foodToRemove);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector2(Random.Range(-40.0f, 33.0f), Random.Range(-19.0f, 18.0f)), Quaternion.identity);
        enemyCount++;
    }
}
