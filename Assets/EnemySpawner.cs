using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // перфаб (прототип) зомби, который будет клонироваться
    [SerializeField] private EnemyMovement enemyPrefab;
    // задержка между спауном клонов
    [SerializeField] private float spawnDelay;

    // ограничение для случайного места спауна
    [SerializeField] private float xDistance;
    [SerializeField] private float yDistance;

    // ссылка на игрока которую спавнер передаст каждому клону в момент создания
    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }
    private Vector3 GetRandomPos()
    {
        float x = Random.Range(-xDistance, xDistance);
        float y = Random.Range(-yDistance, yDistance);
        return new Vector3(x, y, 0f);
    }

    private void SpawnEnemy()
    {
        EnemyMovement enemy = Instantiate(enemyPrefab);
        enemy.transform.position = GetRandomPos();
        enemy.Player = playerTransform;
    }
}
