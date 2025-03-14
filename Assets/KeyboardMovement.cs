using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Animator animator;
    private SpriteRenderer sr;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, vertical) * _speed * Time.deltaTime;
        transform.Translate(movement);

        animator.SetBool("isRun", movement.magnitude > 0f);
        sr.flipX = movement.x < 0f;

    }
}
