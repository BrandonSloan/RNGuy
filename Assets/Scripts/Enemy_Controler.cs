using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
//Author: Blake Henderson
//Date : 11/3/2020

public class Enemy_Controler : MonoBehaviour
{
    /// <summary>
    /// The health of the enemy
    /// </summary>
    public float enemy_Health = 30f;
    /// <summary>
    /// The actual game object of the enemy
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// The score given for killing the enemy
    /// </summary>
    public int score_Value = 0;
    /// <summary>
    /// Tells if the enemy can shoot
    /// </summary>
    public bool can_Shoot = false;
    /// <summary>
    /// The time in between enemy shots
    /// </summary>
    public float shot_delay = 1.5f;
    /// <summary>
    /// The projectile the enemy shoots
    /// </summary>
    public GameObject shot;
    /// <summary>
    /// Where the projectiles spawn
    /// </summary>
    public GameObject spawn;
    /// <summary>
    /// Where the enemy aims
    /// </summary>
    public GameObject target;
    /// <summary>
    /// The player game object
    /// </summary>
    private GameObject player;
    /// <summary>
    /// the play script attached to the player
    /// </summary>
    private Player_Controler player_Script;
    /// <summary>
    /// Used to time in between shots
    /// </summary>
    private float timer = 0.0f;

    // Start is called when the enemy is spawned
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player_Script = player.GetComponent<Player_Controler>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= shot_delay)
        {
            timer = 0.0f;
            if (can_Shoot)
            {
                shootAtPlayer();
            }
        }
        if (enemy_Health <= 0)
        {
            //addpoints
            Destroy(enemy);
        }
    }
    /// <summary>
    /// Happens when the enemy hits another object
    /// </summary>
    /// <param name="collision">The object the enemy bumps into</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player_Bullet")
        {
            int bullet_Damage = ((int)Random.Range(1.0f, 6.999999f));
            enemy_Health -= player_Script.getBaseDamage() * bullet_Damage;
            Destroy(collision.gameObject);
        }
    }
    void shootAtPlayer()
    {
        float angle = Mathf.Atan2(target.transform.position.y - spawn.transform.position.y,
            target.transform.position.x - spawn.transform.position.x) * Mathf.Rad2Deg;
        Instantiate(shot, spawn.transform.position, Quaternion.Euler(0, 0, angle - 90));
    }
}
