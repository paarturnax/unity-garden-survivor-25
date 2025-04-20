using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletsUIManeger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bullets;

    void Start()
    {
        bullets = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBulletsUI(int bulletsCount)
    {
        bullets.text = bulletsCount.ToString();
    }
}
