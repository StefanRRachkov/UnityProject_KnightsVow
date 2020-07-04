using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EncounterSpawn : MonoBehaviour
{
    private EncounterTemplates encounters;
    private int rand;

    [SerializeField] private float waitTime = 4.0f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        encounters = GameObject.FindWithTag("GameManager").GetComponent<EncounterTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        rand = Random.Range(0, encounters.encounters.Length);
        Instantiate(encounters.encounters[rand], transform.position, Quaternion.identity);
    }
}
