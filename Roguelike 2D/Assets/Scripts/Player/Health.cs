using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthPoints = 100;
    private Animator anim;

    public Action<int> OnDamageTaken;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Health", healthPoints);
    }

    void TakeDamage(float damage)
    {
        this.healthPoints = Mathf.Max(this.healthPoints - (int) damage, 0);
        
        OnDamageTaken?.Invoke(this.healthPoints);
    }
}
