using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverStateManager : MonoBehaviour
{
    [SerializeField] private AIHealth boss;
    [SerializeField] private Health player;

    private MenuController switchStates;

    private void Start()
    {
        switchStates = GetComponent<MenuController>();
    }

    private void Update()
    {
        if (player.HealthPoints <= 0)
        {
            switchStates.LoadGame(1);
        }
        else if (boss.HealthPoints <= 0)
        {
            switchStates.LoadGame(2);
        }
    }
}
