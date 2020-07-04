using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;
    
    public List<GameObject> rooms;

    [SerializeField] private float waitTime = 4.0f;
    private bool spawnedBoss = false;
    [SerializeField] private GameObject boss;

    private void Start()
    {
        if(!spawnedBoss && boss) StartCoroutine(SpawnBoss());
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(waitTime);
        boss.transform.position = rooms[rooms.Count - 1].transform.position;
        boss.SetActive(true);
        spawnedBoss = true;
    }
}
