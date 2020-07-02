using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed = 1.0f;
    [SerializeField]
    private float runningSpeed = 2.0f;

    private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;
    private readonly float movementThreshold = 0.01f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        speed = (Input.GetKey(KeyCode.LeftShift)) ? runningSpeed : walkingSpeed;
        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        ResolveLookDirection();
        AnimationHandler();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    
    private void ResolveLookDirection() {
        if (Abs(moveVelocity.x) > movementThreshold) {
            transform.localScale = new Vector3(Sign(moveVelocity.x), 1, 1);
        }
    }

    void AnimationHandler()
    {
        if (moveVelocity != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    
    public void StopMovementVelocity() {
        moveVelocity = Vector2.zero;
    }
    
}
