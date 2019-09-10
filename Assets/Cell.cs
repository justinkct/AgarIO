using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float movementSpeed;

    private float sizeToAdd;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sizeToAdd = GameManager.instance.foodValue;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -40.0f, 33.0f);
        pos.y = Mathf.Clamp(pos.y, -19.0f, 18.0f);
        transform.position = pos;
    }

    public void Move(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, movementSpeed);
    }

    public void ChangeSpeed(float size)
    {
        float temp = transform.localScale.x;

        do
        {
            movementSpeed += 0.05f;
            temp -= sizeToAdd;
        } while (temp != size);
    }

    public void Grow()
    {
        if (movementSpeed > 0.005f)
        {
            transform.localScale += new Vector3(sizeToAdd, sizeToAdd, 0);
            movementSpeed -= 0.005f;
            if (CompareTag("Player"))
                GameManager.instance.cam.orthographicSize += 0.05f;
        }
        else
            movementSpeed = 0.005f;
    }

    public void Shrink()
    {
        if (movementSpeed < 0.3)
        {
            transform.localScale -= new Vector3(sizeToAdd, sizeToAdd, 0);
            movementSpeed += 0.005f;
            if (CompareTag("Player"))
                GameManager.instance.cam.orthographicSize -= 0.05f;
        }
        else
            movementSpeed = 0.3f;
    }

    public void Eat(Food food)
    {
        Grow();
        if (CompareTag("Player"))
            GameManager.instance.AddScore(1);
        Destroy(food.gameObject);
    }
}
