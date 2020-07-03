using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] newPositions;
    
    private float vertExtent;
    private float horzExtent;
     
    void Start()
    {
        for (int index = 0; index < transform.childCount; index++)
        {
            newPositions[index] = transform.GetChild(index);
        }
        
        vertExtent = this.GetComponent<Camera>().orthographicSize; 
        horzExtent = vertExtent * Screen.width / Screen.height;
    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var newPosition in newPositions)
            {
                if (other.transform.position.x < transform.position.x + horzExtent &&
                    other.transform.position.x > transform.position.x - horzExtent)
                {
                    if (other.transform.position.y > transform.position.y && newPosition.name == "T_CameraPosition")
                    {
                        transform.position = newPosition.position;
                        break;
                    }
                    else if (other.transform.position.y < transform.position.y && newPosition.name == "B_CameraPosition")
                    {
                        transform.position = newPosition.position;
                        break;
                    }
                }
                else if (other.transform.position.y < transform.position.y + vertExtent &&
                    other.transform.position.y > transform.position.y - vertExtent)
                {
                    if (other.transform.position.x > transform.position.x && newPosition.name == "R_CameraPosition")
                    {
                        transform.position = newPosition.position;
                        break;
                    }
                    else if (other.transform.position.x < transform.position.x && newPosition.name == "L_CameraPosition")
                    {
                        transform.position = newPosition.position;
                        break;
                    }
                }
            }
        }
    }
}
