using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // префаб (прототип) зомби, который будет клонироваться
    [SerializeField] private EnemyMovement enemyPrefab;

    // ловушка
    [SerializeField] private GameObject trapPrefab;
    // задержка между спауном клонов
    [SerializeField] private float spawnDelay;

    // ограничение для случайного места спауна
    [SerializeField] private float xDistance;
    [SerializeField] private float yDistance;

    // ссылка на игрока которую спавнер передаст каждому клону в момент создания
    [SerializeField] private Transform playerTransform;

    // список заспавленных зомби
    public static List<EnemyMovement> SpawnedZombies = new List<EnemyMovement>();

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, spawnDelay);
        //InvokeRepeating(nameof(SpawnTrap), 0f, 1f);
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
        SpawnedZombies.Add(enemy);
    }

    private void SpawnTrap()
    {
        GameObject trap = Instantiate(trapPrefab);
        trap.transform.position = GetRandomPos();
    }

    public static void Remove(EnemyMovement enemy)
    {
        SpawnedZombies.Remove(enemy);
    }
}
