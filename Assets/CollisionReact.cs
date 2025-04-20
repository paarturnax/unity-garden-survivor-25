using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionReact : MonoBehaviour
{
    [SerializeField] public int Health = 5;
    [SerializeField] private int _damage = 1;

    // ������ �� ��������
    [SerializeField] private HealthBarManager _hpManager;
    // ������ �� ������ ��������
    [SerializeField] private GameObject _gameOverPanel;

    // ������ �� ������ ������ MouseShooting ��� ���� ����� ����� ���� ����� ����� PickAmmo
    [SerializeField] private MouseShooting gun;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            TakeDamage(_damage);
            _hpManager.UpdateHP(Health);
            isDead();
            print(Health);
        }

        if (collision.gameObject.CompareTag("AmmoBox"))
        {
            Destroy(collision.gameObject);
            // ���������� ��������
            int bullets = Random.Range(15, 30);
            gun.PickAmmo(bullets);
            print(bullets);
        }
    }



    private void TakeDamage(int damage)
    {
        if (damage < Health)
        {
            Health -= damage;
        }
        else
        {
            Health = 0;
        }
    }

    private void isDead()
    {
        if (Health <= 0)
        {
            _gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
