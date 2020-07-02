using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{
    [SerializeField] private float flatDamage = 8.0f;
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
    }

    public void ApplyDamageModifiers(float modifier)
    {
        damageModifiers = modifier;
        onDamageModifierChanged = true;
    }

}
