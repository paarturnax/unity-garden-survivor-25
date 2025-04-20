using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private int bullets = 10;
    [SerializeField] private Camera _camera;
    [SerializeField] private BulletsUIManeger bulletsUI;

    private SpriteRenderer _sr;

    public void PickAmmo(int bulletsCount)
    {
        bullets += bulletsCount;
        bulletsUI.UpdateBulletsUI(bullets);
    }

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        bulletsUI.UpdateBulletsUI(bullets);
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

                bullets--;
                bulletsUI.UpdateBulletsUI(bullets);
            }
        }
    }
}
