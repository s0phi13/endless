using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    Rigidbody2D playerObject;
    Vector3 jumpForce = new Vector3(0.0f,10.0f,0.0f);

    bool isJumping = true;


    void Start()
    {

        playerObject = GetComponent<Rigidbody2D>();

           if (isJumping == true)
        {
            playerObject.AddForce(jumpForce);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float movementValueX = Input.GetAxis("Horizontal");

        playerObject.velocity = new Vector2 (movementValueX, playerObject.velocity.y);

    }
}
