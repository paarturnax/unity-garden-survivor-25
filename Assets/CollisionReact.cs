using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReact : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (_health > 1)
            {
                _health -= 1;
                collision.transform.position = new Vector3(0f, 0f, 0f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
