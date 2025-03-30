using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpriteRenderer _sr;

    [SerializeField] public Transform Player;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movement = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, movement);
        _sr.flipX = Player.position.x < transform.position.x;
    }

    private void OnDestroy()
    {
        EnemySpawner.Remove(this);
    }
}
