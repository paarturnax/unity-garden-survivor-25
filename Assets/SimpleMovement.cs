using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, vertical) * _speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("1"))
        {
            print("ok");
        }
        else if (collision.gameObject.CompareTag("2"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("3"))
        {
            Destroy(gameObject);
        }
    }
}
