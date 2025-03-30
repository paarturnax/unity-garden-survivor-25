using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // префаб снаряда
    [SerializeField] private GameObject projectile;

    private float timeToShoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToShoot)
        {
            // нахождение ближайшего
            // выстрел
        }
    }

    private void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(projectile);
        
        bullet.transform.position = transform.position;
        Vector3 direction = target.position - transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    private EnemyMovement findNearest()
    {
        Vector3 playerPos = transform.position;
        List<EnemyMovement> zombies = EnemySpawner.SpawnedZombies;

        if (zombies.Count == 0)
        {
            return null;
        }

        EnemyMovement nearest = zombies[0];
        float minDistance = Vector3.Distance(nearest.transform.position, playerPos);

        for (int i = 1; i < zombies.Count; i++)
        {
            EnemyMovement zomb = zombies[i];
            float distance = Vector3.Distance(playerPos, zomb.transform.position);
            if (distance < minDistance)
            {
                nearest = zomb;
                minDistance = distance;
            }
        }

        return nearest;
    }
}
