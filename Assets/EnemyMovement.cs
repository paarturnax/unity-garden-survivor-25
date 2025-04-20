using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject ammoBoxPrefab;
    [SerializeField] private float _speed;
    private SpriteRenderer _sr;
    private int hp;

    [SerializeField] public Transform Player;

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

        if (Random.Range(0, 8) == 1)
        {
            GameObject box = Instantiate(ammoBoxPrefab);
            box.transform.position = transform.position;
        }
    }
}
