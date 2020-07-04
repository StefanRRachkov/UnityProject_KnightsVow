using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
        [SerializeField] private int healthPoints = 100;

        public int HealthPoints => healthPoints;

        private Animator anim;
        public int maxHealth;

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
            anim.SetTrigger("onHurt");
            
            OnDamageTaken?.Invoke(this.healthPoints);
        }
        
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.transform.parent.CompareTag("Player"))
            {
                if (collision.gameObject.CompareTag("Hitbox"))
                {
                    TakeDamage(collision.transform.parent.GetComponent<PlayerCombat>().damage);
                }
            }
        }
}
