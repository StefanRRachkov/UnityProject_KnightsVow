using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
        [SerializeField] private int healthPoints = 100;
        private Animator anim;
    
        private void Start()
        {
            anim = GetComponent<Animator>();
            anim.SetInteger("Health", healthPoints);
        }
    
        public void TakeDamage(float damage)
        {
            this.healthPoints = Mathf.Max(this.healthPoints - (int) damage, 0);
            anim.SetInteger("Health", this.healthPoints);
            anim.SetTrigger("onHurt");
        }
        
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.transform.parent.CompareTag("Player") && collision.gameObject.CompareTag("Hitbox")) 
            {
                TakeDamage(collision.transform.parent.GetComponent<PlayerCombat>().damage);
            }
        }
}
