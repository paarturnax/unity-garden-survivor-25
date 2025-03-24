using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Image[] images;

    public void UpdateHP(int hp)
    {
        for (int i = 0; i < images.Length; i++)
        {
            bool showImage = i < hp;
            images[i].gameObject.SetActive(showImage);
        }
    }
}
