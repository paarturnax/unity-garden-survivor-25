using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private int bullets = 25;
    [SerializeField] private Camera _camera;

    [SerializeField] private TextMeshProUGUI ammoCount;

    private SpriteRenderer _sr;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void UpdateAmmoCount(int value)
    {
        ammoCount.text = $"bulets: {value}";
    }

    private void Shoot(Vector3 target)
    {
        GameObject bullet = Instantiate(projectile);     // ������� ����
        bullet.transform.position = transform.position;  // ���������� � �������������� �����
        Vector3 direction = target - transform.position; // ��������� ����������� � ������� ��������� ���� � �����
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction); // ������� ���� � ����������� target

        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction); // ������� �����
        _sr.flipY = Mathf.Abs(transform.rotation.z) > 0.5f;
    }

    public void PickUpAmmo()
    {
        bullets += 25;
        UpdateAmmoCount(bullets);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (bullets > 0)
            {
                Vector3 MousePos = Input.mousePosition;
                Vector3 point = _camera.ScreenToWorldPoint(MousePos);
                point.z = 0f;
                Shoot(point);
                bullets --;
                UpdateAmmoCount(bullets);
            }
        }
    }
}
