using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthPoints = 100;
    
    public int HealthPoints => healthPoints;
    
    public int maxHealth;
    private Animator anim;

    public Action<int> OnDamageTaken;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Health", healthPoints);
        maxHealth = healthPoints;
    }

    public void TakeDamage(float damage)
    {
        this.healthPoints = Mathf.Max(this.healthPoints - (int) damage, 0);
        this.healthPoints = Mathf.Min(this.healthPoints - (int) damage, maxHealth);
        
        anim.SetInteger("Health", this.healthPoints);
        if(damage < 0) anim.SetTrigger("onHit");
        
        OnDamageTaken?.Invoke(this.healthPoints);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.parent != transform && collision.gameObject.CompareTag("Hitbox")) 
        {
            TakeDamage(collision.transform.parent.GetComponent<AICombat>().damage);
        }
    }
}
