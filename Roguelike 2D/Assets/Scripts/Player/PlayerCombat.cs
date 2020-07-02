using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float flatDamage = 5.0f;
    private float damageModifiers = 0.0f;
    public float damage;

    private Animator anim;
    private bool onDamageModifierChanged = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        onDamageModifierChanged = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onDamageModifierChanged)
        {
            damage = flatDamage + damageModifiers;
            onDamageModifierChanged = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isAttacking");
        }
    }

    // If we have weapons or other stuff
    // we call this method to apply the 
    // damage modifier to the character
    public void ApplyDamageModifiers(float modifier)
    {
        damageModifiers = modifier;
        onDamageModifierChanged = true;
    }

}
