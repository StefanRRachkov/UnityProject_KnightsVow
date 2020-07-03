using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private Health playerHealthComponent;
    public GameObject healthEffect;
    [SerializeField] private float healthBoost = 10.0f;

    private void Start()
    {
        playerHealthComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void Use() {
        Instantiate(healthEffect, playerHealthComponent.transform.position, Quaternion.identity);
        playerHealthComponent.TakeDamage(-healthBoost);
        Destroy(gameObject);
    }
}
