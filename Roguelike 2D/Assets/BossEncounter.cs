using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEncounter : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;

    private void Update()
    {
        if (GetComponent<AIMovementScript>().running)
        {
            healthBar.SetActive(true);
        }
    }
}
