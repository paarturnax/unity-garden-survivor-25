using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CollisionReact : MonoBehaviour
{
    [SerializeField] public int Health = 5;
    [SerializeField] private int _damage = 1;

    // ссылка на сердечки
    [SerializeField] private HealthBarManager _hpManager;
    // ссылка на панель геймовер
    [SerializeField] private GameObject _gameOverPanel;

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

        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);

            TakeDamage(2);
            _hpManager.UpdateHP(Health);
            isDead();
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
            gun.PickUpAmmo();
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
