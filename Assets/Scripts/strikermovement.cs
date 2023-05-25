using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strikermovement : MonoBehaviour
{

    public GameObject coins; // reference to the coin game object
    public float speed = 10f; // speed at which the striker moves

    private Vector3 targetPosition; // target position for the striker to move to

    private void Start()
    {
        // Find the first game object with the tag "Enemy"
        coins = GameObject.FindWithTag("coins");
    }

    private void Update()
    {
        // Check if the coin has collided with the striker line
        if (coins.transform.position.y <= transform.position.y)
        {
            // Set the target position for the striker to move to
            targetPosition = new Vector3(coins.transform.position.x, transform.position.y, transform.position.z);

            // Move the striker towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}


