using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform player; 
    public float pickupRadius = 2f; 
    public RocketSpawner rocketSpawner; 

    void Update()
    {
        foreach (Transform powerUp in transform)
        {
            // Check if player is within the pickup radius
            if (Vector3.Distance(player.position, powerUp.position) < pickupRadius)
            {
                rocketSpawner.IncreaseRockets(); // Increase rocket count
                Destroy(powerUp.gameObject);

            }
        }
    }
}
