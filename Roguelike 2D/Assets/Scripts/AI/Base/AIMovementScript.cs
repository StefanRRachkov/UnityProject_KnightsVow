using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Mathf;

public class AIMovementScript : MonoBehaviour
{
    [SerializeField] private float distanceToTriggerInterest = 10.0f;
    
    private GameObject pointOfInterest = null;
    private Rigidbody2D rb;
    private Vector2 povDirection = Vector2.zero;
    private Vector2 walkingDirection = Vector2.left;
    private Animator anim;
    private Vector2 velocity = Vector2.zero;
    private readonly float movementThreshold = 0.01f;

    [SerializeField] private float walkingSpeed = 2.0f;
    [SerializeField] private float runningSpeed = 4.0f;
    
    // TODO: GET
    public bool running = false;
    public float distanceToPOV;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        pointOfInterest = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (pointOfInterest)
        {
            distanceToPOV = Vector2.Distance(pointOfInterest.transform.position, this.transform.position);
            if (distanceToPOV <= distanceToTriggerInterest)
            {
                running = true;
            }
            
            if (running)
            {
                povDirection = pointOfInterest.transform.position - this.transform.position;
                velocity = povDirection.normalized * runningSpeed;
            }
            else
            {
                velocity = walkingDirection * walkingSpeed;
                StartCoroutine(RepeatableMovement());
                // wait 2 seconds, change direction and again and again
            }
        }
        ResolveLookDirection();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void ResolveLookDirection() {
        if (Abs(velocity.x) > movementThreshold) {
            transform.localScale = new Vector3(Sign(velocity.x), 1, 1);
        }
    }
    
    public void StopMovementVelocity() {
        velocity = Vector2.zero;
    }

    IEnumerator RepeatableMovement()
    {
        while (true)
        {
            if (walkingDirection == Vector2.left)
            {
                yield return new WaitForSeconds(2);
                walkingDirection = Vector2.right;
            }
            else if (walkingDirection == Vector2.right)
            {
                yield return new WaitForSeconds(2);
                walkingDirection = Vector2.left;
            }
            yield return null;
        }
    }
}
