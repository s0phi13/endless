using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public GameObject groundChecker;
    public LayerMask whatIsGround;

    float maxSpeed = 5.0f;
    bool isOnGround = false;
    bool doubleJump = true;

    Rigidbody2D playerObject;
  
    void Start()
    {

        playerObject = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {
        
        // float movementValueX = Input.GetAxis("Horizontal");
          float movementValueX = 1.0f;

        playerObject.velocity = new Vector2 (movementValueX * maxSpeed, playerObject.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
         
            Jump();
           
    
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {

            DoubleJump();
        
        }
      

    
    }

    void Jump()
    {
        doubleJump = true;
          playerObject.AddForce(new Vector2(0.0f, 320.0f));
      

    }

    void DoubleJump()
    {
        if (doubleJump == true)
         playerObject.AddForce(new Vector2(0.0f, 320.0f));
        doubleJump = false;

    }



}