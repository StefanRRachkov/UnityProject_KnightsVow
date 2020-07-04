using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEncounter : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private CameraShake cameraShake;

    [SerializeField] private float durationOfCameraShake;
    [SerializeField] private float cameraMagnitude;
    
    private void Update()
    {
        if (GetComponent<AIMovementScript>().running)
        {
            healthBar.SetActive(true);
        }
    }

    public void PowerfulHits()
    {
        if(cameraShake) StartCoroutine(cameraShake.Shake(durationOfCameraShake, cameraMagnitude));
    }
}
