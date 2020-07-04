using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    /*    1 -> need from Bottom Rooms
     *    2 -> need from Top Rooms
     *    3 -> need from Left Rooms
     *    4 -> need from Right Rooms
     */

    private RoomTemplates roomTemplate;

    private int rand;
    public bool spawned = false;
    [SerializeField] private float waitTime = 4.0f;
    
    private void Start()
    {
        Destroy(gameObject, waitTime);
        roomTemplate = GameObject.FindWithTag("GameManager").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            switch (openingDirection)
            {
                case 1:
                    rand = Random.Range(0, roomTemplate.bottomRooms.Length);
                    Instantiate(roomTemplate.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2:
                    rand = Random.Range(0, roomTemplate.topRooms.Length);
                    Instantiate(roomTemplate.topRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3:
                    rand = Random.Range(0, roomTemplate.leftRooms.Length);
                    Instantiate(roomTemplate.leftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4:
                    rand = Random.Range(0, roomTemplate.rightRooms.Length);
                    Instantiate(roomTemplate.rightRooms[rand], transform.position, Quaternion.identity);
                    break;
                default: break;
            }

            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StartingRoom"))
        {
            spawned = true;
            Destroy(gameObject);
        }
        else if (other.CompareTag("RoomSpawnPoint"))
        {
            if (!other.GetComponent<RoomSpawner>().spawned && !this.spawned)
            {
                Instantiate(roomTemplate.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
