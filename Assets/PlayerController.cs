using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Cell player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputMove();
    }

    void InputMove()
    {
        if (Input.GetKey(KeyCode.Equals)) player.Grow();
        if (Input.GetKey(KeyCode.Minus)) player.Shrink();

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.Move(pos);
    }
}
