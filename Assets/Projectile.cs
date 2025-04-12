using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f; // ����� ������ ����
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private int hitCount = 3; // ������� ����� ����� ������� ���� ������ 

    private float timeToDestroy; // �����, �� ������� ���� ������ ������������

    void Start()
    {
        timeToDestroy = Time.time + lifetime;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (Time.time >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyMovement>().GetDamage(damage);

        }
    }
}
