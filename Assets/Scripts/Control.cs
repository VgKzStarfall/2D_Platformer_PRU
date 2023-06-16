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
    public int maxhealth = 100;
    public int curhealth = 100;

    public float moveS, jumpH;
    public bool moveL, moveR, jump;
    public bool isJumping = false;

    public bool startgame;

    private Animator anim;
    public Vector3 respawnPoint;
    public GameObject Explode;
    public bool immune;
    public GameObject healthbar;

    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint= transform.position;
        curhealth = 100;
        maxhealth = 100;
        immune = false;
    }

    //
    void Update()
    {
        if (startgame)
        {
            SceneManager.LoadScene("Level1");
        }
        healthbar.GetComponent<Healthbar>().setHealth(curhealth, maxhealth);
        InputMovement();
        AnimAvatar();
        StartCoroutine(StorePosition());
        if (curhealth == 0)
        {
            StartCoroutine(respawndelay());
        }
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
        if (collision.tag == "slave" && !immune)
        {
            collision.GetComponent<MonsterShared>().dealDamage(gameObject);
            StartCoroutine(immunity());
        }
    }

    public IEnumerator immunity()
    {
        immune = true;
        yield return new WaitForSeconds(1f);
        immune = false;
    }

    public IEnumerator respawndelay()
    {
        enabled = false;
        Instantiate(Explode, respawnPoint, transform.rotation); //edit this line for checkpoint
        //player.enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        transform.position = respawnPoint; // eidt this line for checkpoint
        curhealth = maxhealth;
        GetComponent<Renderer>().enabled = true;
        enabled = true;
    }

}