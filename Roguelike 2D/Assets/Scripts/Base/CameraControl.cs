using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform[] newPositions;

    [SerializeField] private float smoothSpeed = 0.125f;
    
    private float vertExtent;
    private float horzExtent;

    private Vector3 desiredPosition;
     
    void Start()
    {
        for (int index = 0; index < transform.childCount - 1; index++)
        {
            newPositions[index] = transform.GetChild(index);
        }

        desiredPosition = transform.position;
        
        vertExtent = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().orthographicSize; 
        horzExtent = vertExtent * Screen.width / Screen.height;
    }

    private void LateUpdate()
    {
        if (desiredPosition != transform.position)
        {
            Vector3 smoothedPosition =
                Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }
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
                        desiredPosition = newPosition.position;
                        break;
                    }
                    else if (other.transform.position.y < transform.position.y && newPosition.name == "B_CameraPosition")
                    {
                        desiredPosition = newPosition.position;
                        break;
                    }
                }
                else if (other.transform.position.y < transform.position.y + vertExtent &&
                    other.transform.position.y > transform.position.y - vertExtent)
                {
                    if (other.transform.position.x > transform.position.x && newPosition.name == "R_CameraPosition")
                    {
                        desiredPosition = newPosition.position;
                        break;
                    }
                    else if (other.transform.position.x < transform.position.x && newPosition.name == "L_CameraPosition")
                    {
                        desiredPosition = newPosition.position;
                        break;
                    }
                }
            }
        }
    }
}
