using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    Rigidbody2D playerObject;

    // Start is called before the first frame update
    void Start()
    {

        playerObject = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float movementValueX = Inout.GetAxis("Horizontal");

        playerObject.velocity = new Vector2 (movementValueX, playerObject.velocity.y);

    }
}
