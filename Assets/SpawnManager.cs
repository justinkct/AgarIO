using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform food;
    public int foodCount;
    public float spawnInterval = 1.0f;
    public List<Transform> foodList;

    private float timeLastSpawned;

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
        timeLastSpawned = Time.time;
    }

    void Update()
    {
        if (Time.time - timeLastSpawned >= spawnInterval && foodCount < 100)
        {
            SpawnFood();
            timeLastSpawned = Time.time;
        }
    }

    public void SpawnFood()
    {
        Transform foodToAdd = Instantiate(food, new Vector2(Random.Range(-40.0f, 33.0f), Random.Range(-19.0f, 18.0f)), Quaternion.identity);
        foodList.Add(foodToAdd);
        foodCount++;
    }

    public void RemoveFromList(Transform foodToRemove)
    {
        foodList.Remove(foodToRemove);
    }
}
