using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int maxHp = 6;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private ParticleSystem partSys;
    private SpriteRenderer _sr;
    private int _hp;

    [SerializeField] public Transform Player;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _hp = maxHp;
    }

    public void GetDamage(int damage)
    {
        _hp -= damage;
        hpSlider.value = (float)_hp / maxHp;
        partSys.Play();
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
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
