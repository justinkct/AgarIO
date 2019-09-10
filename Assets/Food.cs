using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Rigidbody2D rb2d;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        SpawnManager.instance.RemoveFromList(transform);
        SpawnManager.instance.foodCount--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!CompareTag(other.tag) && other.tag != "Untagged")
        {
            other.GetComponent<Cell>().Eat(this);
        }
    }
}
