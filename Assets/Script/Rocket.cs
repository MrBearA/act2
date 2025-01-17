using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet

    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized; // Set the direction of the rocket
    }

    void Update()
    {
        // Move the rocket in the specified direction
        transform.position += direction * speed * Time.deltaTime;

        
        if (Vector3.Distance(transform.position, Vector3.zero) > 50f)
        {
            Destroy(gameObject);
        }
    }
}
