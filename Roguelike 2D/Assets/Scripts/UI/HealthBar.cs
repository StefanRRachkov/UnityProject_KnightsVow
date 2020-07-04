using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [SerializeField] private GameObject player = null;
    [SerializeField] private Health health = null;
    [SerializeField] private AIHealth aiHealth = null;
    [SerializeField] private HealthFiller healthFiller = null;

    private void OnEnable() 
    {
        if (health)
        {
            Debug.Log("Player is Subscribed");
            if(health) health.OnDamageTaken += ScaleHealthbar;
            
        }

        if (aiHealth)
        {
            Debug.Log("Boss is Subscribed");
            aiHealth.OnDamageTaken += ScaleHealthbar;
        }
    }
    private void OnDisable() 
    {
        if(health) health.OnDamageTaken -= ScaleHealthbar;
        if(aiHealth) aiHealth.OnDamageTaken -= ScaleHealthbar;
    }

    private void ScaleHealthbar(int newHealth) 
    {
        if(health) healthFiller.TargetScale = (float) newHealth / health.maxHealth;
        if(aiHealth) healthFiller.TargetScale = (float) newHealth / aiHealth.maxHealth;
        
    }
}
