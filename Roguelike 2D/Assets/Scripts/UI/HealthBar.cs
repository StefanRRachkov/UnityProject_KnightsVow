using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [SerializeField] private GameObject player = null;
    [SerializeField] private Health health = null;
    [SerializeField] private HealthFiller healthFiller = null;

    private void OnEnable() 
    {
        if (health)
        {
            Debug.Log("Subscribed");
            health.OnDamageTaken += ScaleHealthbar;
        }
    }
    private void OnDisable() 
    {
        if(health) health.OnDamageTaken -= ScaleHealthbar;
    }

    private void ScaleHealthbar(int newHealth) 
    {
        healthFiller.TargetScale = (float) newHealth / health.maxHealth;
    }
}
