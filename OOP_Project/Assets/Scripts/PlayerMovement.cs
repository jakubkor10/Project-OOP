using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    string playerName;

    Rigidbody playerRb;
    Collider playerCollider;

    [SerializeField] float playerSpeed = 1000f;
    [SerializeField] float jumpForce = 2000f;
    float groundCheckDepth = 0.5f;
    public bool canJump { get; private set; }// ENCAPSULATION
    public bool canMove { get; private set; }// ENCAPSULATION


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            canMove = true;
        }
        else { canMove = false; }
    }
    private void FixedUpdate()
    {
        if (MoveConditions()) { Move();}
        if (JumpConditions()) { Jump();}
    }
    bool MoveConditions()
    {
        if (canMove && isGrounded())
        {
            Debug.Log("Can move");
            return true;
        }
        else { return false; }
        
    }//ABSTRACTION
    void Move()//ABSTRACTION
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput,0,verticalInput).normalized;

        playerRb.AddForce(moveDirection*playerSpeed);
    }
    public bool isGrounded()
    {
        Vector3 playerBottom = new Vector3(0,transform.position.y-playerCollider.bounds.extents.y,0);
        Debug.DrawRay(playerBottom, Vector3.down * groundCheckDepth, Color.red, 100);
        if (Physics.Raycast(playerBottom, Vector3.down, groundCheckDepth))
        {
            Debug.Log("Is grounded");
            return true;
        }
        else { return false; }
        
    }
    bool JumpConditions()//ABSTRACTION
    {
        if (canJump && isGrounded())
        {
            Debug.Log("Can jump");
            return true;
        }
        else { return false; }
    }
    void Jump()//ABSTRACTION
    {
        playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        canJump = false;
    }
}
