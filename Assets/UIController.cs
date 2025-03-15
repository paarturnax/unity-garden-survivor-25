using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private CollisionReact player;
    private void Update()
    {
        int hp = player.GetComponent<CollisionReact>().Health;
        hpText.text = $"HP: {hp}";
    }
}
