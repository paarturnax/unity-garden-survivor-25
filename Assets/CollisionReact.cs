using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReact : MonoBehaviour
{
    [SerializeField] public int Health = 5;
    [SerializeField] private int _damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            TakeDamage(_damage);
            isDead();
            print(Health);
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
            Application.Quit();
            Time.timeScale = 0;
        }
    }
}
