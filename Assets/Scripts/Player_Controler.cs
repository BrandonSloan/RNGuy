using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Blake Henderson
//Date : 10/23/2020
public class Player_Controler : MonoBehaviour
{
    public HealthBar healthBar;
    /// <summary>
    /// minimum max health for the player
    /// </summary>
    public int minMaxHealth = 5;
    /// <summary>
    /// maximum max health for the player
    /// </summary>
    public int maxMaxHealth = 20;
    /// <summary>
    /// maximum max health for the player
    /// </summary>
    public int maxHealth;
    /// <summary>
    /// current health for the player
    /// </summary>
    public int currentHealth;
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
    
    // Start is called before the first frame update
    void Start()
    {
        //used to randomly generate speed
        speed = Random.Range(minSpeed, maxSpeed);
        maxHealth = Random.Range(minMaxHealth, maxMaxHealth);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        baseDamage = Random.Range(minBaseDamage, maxBaseDamage);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_Bullet")
        {

            currentHealth -= 1;
            Destroy(collision.gameObject);
            healthBar.SetHealth(currentHealth);
        }
        if(collision.tag == "Enemy")
        {
            if (timer >= 0.5f)
            {
                currentHealth -= 1;
                healthBar.SetHealth(currentHealth);
                timer = 0.0f;
            }
        }
    }

    //void takeDamage(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy_Bullet")
    //    {
            
    //        currentHealth -= 1;
    //        Destroy(collision.gameObject);
    //        healthBar.SetHealth(currentHealth);
    //    }
    //}

    //void TakeDamage(int damage)
    //{
    //    if (currentHealth !=0)
    //    currentHealth -= damage;
    //    healthBar.SetHealth(currentHealth);
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        //movement
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
