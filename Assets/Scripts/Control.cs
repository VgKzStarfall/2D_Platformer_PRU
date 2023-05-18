using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public Rigidbody2D rb;

    public int diamonds = 0;
    public int rubies = 0;
    public int deathc = 0;

    public float moveS, jumpH;
    public bool moveL, moveR, jump;
    public bool isJumping = false;

    public bool startgame;

    private Animator anim;
    public Vector3 respawnPoint;

    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint= transform.position;
    }

    //
    void Update()
    {
        if (startgame)
        {
            SceneManager.LoadScene("Level1");
        }

        InputMovement();
        AnimAvatar();
        StartCoroutine(StorePosition());
    }

    //
    private void Startstar()
    {

    }
   
  
    //
    private void InputMovement()
    {
        ///Keyboard
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveS, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveS, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
        }

        ///Touch
        if (moveL)
        {
            rb.velocity = new Vector2(-moveS, rb.velocity.y);
        }
        if (moveR)
        {
            rb.velocity = new Vector2(moveS, rb.velocity.y);
        }
        if (jump && (isJumping == false))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
            jump = false;
        }
        
    }

    //Store position for jumping
    private IEnumerator StorePosition()
    {
        
        Vector2 startPos = rb.transform.position;
        yield return new WaitForSeconds(0.1f);
        Vector2 finalPos = rb.transform.position;
        if (startPos.y != finalPos.y)
        {
            isJumping = true;
        } else isJumping = false;
    }

    //
    private void AnimAvatar()
    {
        if (rb.velocity.x != 0 && isJumping == false)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

    }

    //
    /*
     * 
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    //////////

    if (crystals == 41)
{
    Application.LoadLevel("level2");
}

    */

    // checkPoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag==("Checkpoint"))
        {
            respawnPoint = transform.position;

        }

    }

}