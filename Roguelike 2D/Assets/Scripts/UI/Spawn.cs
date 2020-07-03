using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private Transform playerPos;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 0);
    public GameObject item;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SpawnItem() 
    {
        Instantiate(item, playerPos.position + offset, Quaternion.identity);
    }
}
