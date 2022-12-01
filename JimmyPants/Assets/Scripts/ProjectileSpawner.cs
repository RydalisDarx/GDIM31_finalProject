using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime = 3; // The amount of time it takes for the projectile to spawn

    private float time;

    public GameObject projectile;
    [SerializeField]
    private Transform spawnPoint;
    void Start()
    {
        Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > spawnTime)
        {
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            time = 0;

        }
    }
}
