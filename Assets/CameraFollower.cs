using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float dampTime;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameManager.instance.player.position;
        Vector3 point = gameObject.GetComponent<Camera>().WorldToViewportPoint(playerPos);
        Vector3 delta = playerPos - gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}