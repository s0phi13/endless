using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
  
    public GameObject groundChecker;
    public GameObject barrierChecker;
    public LayerMask whatIsGround;
    public AudioClip jump;
    public AudioClip backgroundMusic;
    public LayerMask whatIsBarrier;
    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;
   

    float maxSpeed = 5.0f;
    bool isOnGround = false;
    bool doubleJump = true;
    bool isOnBarrier = false;

    Rigidbody2D playerObject;
    Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "Barrier")
        {
              SceneManager.LoadScene(3
            );
        }
    }
  
    void Start()
    {

        playerObject = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
       

        
    }

    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);
        isOnBarrier = Physics2D.OverlapCircle(barrierChecker.transform.position, 1.0f, whatIsBarrier);
        // float movementValueX = Input.GetAxis("Horizontal");
          float movementValueX = 1.0f;

        playerObject.velocity = new Vector2 (movementValueX * maxSpeed, playerObject.velocity.y);
        

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
         
            Jump();
           
    
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {

            DoubleJump();
        
        }

        anim.SetFloat("Speed", Mathf.Abs(movementValueX));
        anim.SetBool("IsOnGround", isOnGround);

    
    
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