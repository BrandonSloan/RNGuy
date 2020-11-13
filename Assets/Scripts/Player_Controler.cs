using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Blake Henderson
//Date : 11/10/2020
public class Player_Controler : MonoBehaviour
{
    public static GameManager gameManager;
    //public GameManager gmScript;
    /// <summary>
    /// minimum speed for the player
    /// </summary>
    public float minSpeed = 0.0f;
    /// <summary>
    /// maximum speed for the player
    /// </summary>
    public float maxSpeed = 1.0f;
    /// <summary>
    /// minimum base damage of the player
    /// </summary>
    public float minBaseDamage = 0.5f;
    /// <summary>
    /// maximum base damage of the player
    /// </summary>
    public float maxBaseDamage = 10.0f;
    /// <summary>
    /// This is used in movement calculations, is randomized between 5 and 15
    /// </summary>
    private float speed = 0.0f;
    /// <summary>
    /// The base damage of the player which is randomized and then multiplied to
    /// calculate the actual damage in the projectile script.
    /// </summary>
    private float baseDamage = 1.0f;
    /// <summary>
    /// The rigid body of the player sprite.
    /// </summary>
    private Rigidbody2D rb2d;
    /// <summary>
    /// This timer is for calculating the time between contact damage
    /// </summary>
    private float timer = 0.0f;
    /// <summary>
    /// Handles the animation of RNGuy
    /// </summary>
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameManager.FindGameObjectWithTag("GameManager");
        //gmScript = gameManager.GetComponent<GameManager>();
        //used to randomly generate speed
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        speed = Random.Range(minSpeed, maxSpeed);
        baseDamage = Random.Range(minBaseDamage, maxBaseDamage);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_Bullet")
        {
            gameManager.takeDamage(1);
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Enemy")
        {
            if (timer >= 0.5f)
            {
                gameManager.takeDamage(1);
                timer = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        //movement
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //animation
        if(movement.y < 0f)
        {
            anim.SetBool("Move_Forward", true);
            anim.SetBool("Move_Backward", false);
            anim.SetBool("Move_Right", false);
            anim.SetBool("Move_Left", false);
            anim.SetBool("Idle", false);
        }
        if(movement.y > 0f)
        {
            anim.SetBool("Move_Forward", false);
            anim.SetBool("Move_Backward", true);
            anim.SetBool("Move_Right", false);
            anim.SetBool("Move_Left", false);
            anim.SetBool("Idle", false);
        }
        if (movement.x > 0f)
        {
            anim.SetBool("Move_Forward", false);
            anim.SetBool("Move_Backward", false);
            anim.SetBool("Move_Right", true);
            anim.SetBool("Move_Left", false);
            anim.SetBool("Idle", false);
        }
        if (movement.x < 0f)
        {
            anim.SetBool("Move_Forward", false);
            anim.SetBool("Move_Backward", false);
            anim.SetBool("Move_Right", false);
            anim.SetBool("Move_Left", true);
            anim.SetBool("Idle", false);
        }
        if (movement.y == 0 && movement.x == 0)
        {
            anim.SetBool("Move_Forward", false);
            anim.SetBool("Move_Backward", false);
            anim.SetBool("Move_Right", false);
            anim.SetBool("Move_Left", false);
            anim.SetBool("Idle", true);
        }
        rb2d.MovePosition(rb2d.position + (movement * speed * Time.deltaTime));
    }
    /// <summary>
    /// This is used to pass the base damage to the projectile script.
    /// </summary>
    /// <returns></returns>
    public float getBaseDamage()
    {
        return baseDamage;
    }
}
