using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool canShoot = false;
    public GameObject bullet;
    public GameObject bulletPosition;
    public GameObject gun;

    private bool isResistentToEnemies = false;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    private int extraJumpsValue;

    private bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;
    public LayerMask whatIsWall;

    private bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    public bool isAbleToWallJump;

    public LayerMask lava;

    void Start()
    {
        extraJumpsValue = extraJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsWall);

        if (isTouchingFront == true && isGrounded == false && moveInput != 0 && isAbleToWallJump == true)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
        }

        if (Input.GetKeyDown(KeyCode.E) && canShoot == true)
        {
            GameObject shot = Instantiate(bullet, bulletPosition.transform.position, this.transform.rotation);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;
            //Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            facingRight = false;
            //Flip();
        }
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 scaler = transform.localScale;
    //    scaler.x *= -1;
    //    transform.localScale = scaler;
    //}

    public void AddExtraJumps(int amount)
    {
        extraJumpsValue = amount;
        isGrounded = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy" && isResistentToEnemies == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.collider.gameObject.tag == "Bullet")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.collider.gameObject.tag == "Rocket")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.collider.gameObject.tag == "Laser")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.collider.gameObject.tag == "Asteroid")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.collider.gameObject.layer == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GiveResistance(ResistanceType type)
    {
        if (type == ResistanceType.Enemy)
        {
            isResistentToEnemies = true;
        }
    }

    public void GiveBullets()
    {
        canShoot = true;
        gun.SetActive(true);
    }
}
