using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueMovement : PlayerMovement//INHERITANCE
{
    bool isDashing;
    [SerializeField]float dashForce = 40000f;
    protected override void Awake()//POLYMORPHISM
    {
        base.Awake();
    }
    protected override void Update()//POLYMORPHISM
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashing = true;
        }
        
    }
    protected override void FixedUpdate()//POLYMORPHISM
    {
        base.FixedUpdate();
        if (DashConditions())
        {
            Dash();
        }
    }
    bool DashConditions()//POLYMORPHISM //ABSTRACTION
    {
        if (isDashing)
        {
            return true;
        }
        return false;
    }
    void Dash()//POLYMORPHISM //ABSTRACTION
    {
        Vector3 dashDirection = playerRb.velocity.normalized;
        playerRb.AddForce(dashDirection*dashForce);
        isDashing = false;
    }
}
