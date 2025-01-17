using System.Collections;
using System.Net.Sockets;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab; 
    public Transform firePoint; 
    public int rocketCount = 1; 
    public int maxRockets = 8; 
    public float fireInterval = 2f; 

    void Start()
    {
        StartCoroutine(AutoFire());
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            FireRockets();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void FireRockets()
    {
        float angleStep = 360f / rocketCount;
        float angleOffset = 0f; 

        for (int i = 0; i < rocketCount; i++)
        {
            float angle = angleStep * i + angleOffset;
            Vector3 direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));

            // Spawn and initialize the rocket
            GameObject rocket = Instantiate(rocketPrefab, firePoint.position, Quaternion.identity);
            rocket.GetComponent<Rocket>().Initialize(direction);
        }
    }

    public void IncreaseRockets()
    {
        if (rocketCount < maxRockets)
        {
            rocketCount++;
        }
    }
}