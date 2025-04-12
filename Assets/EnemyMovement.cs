using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpriteRenderer _sr;
    private int hp;

    [SerializeField] public Transform Player;
    [SerializeField] public GameObject ammobox;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        hp = 3;
    }

    void Update()
    {
        float movement = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, movement);
        _sr.flipX = Player.position.x < transform.position.x;
    }

    public void GetDamage(int damage)
    {
        if (hp > damage)
        {
            hp -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EnemySpawner.Remove(this);
        if (Random.Range(0, 9) == 1)
        {
            GameObject ammo = Instantiate(ammobox);
            ammo.transform.position = transform.position;
        }
    }
}
