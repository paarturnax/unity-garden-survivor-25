using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _xDistance;
    [SerializeField] private float _yDistance; // Ограничение для камеры верх - низ
    
    private void Move()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(_player.position.x, -_xDistance, _xDistance);
        cameraPosition.y = Mathf.Clamp(_player.position.y, -_yDistance, _yDistance);
        transform.position = cameraPosition;
    }

    void Update()
    {
        Move();
    }
}
