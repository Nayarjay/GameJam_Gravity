using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float honrizontalMove = 0f;
    bool jump = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       honrizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Jump();
    }
    private void FixedUpdate()
    {
        controller.Move(honrizontalMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }
     public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
}
