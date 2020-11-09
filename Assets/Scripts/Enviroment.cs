using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    /// <summary>
    /// The health of the enviroment
    /// </summary>
    public float health = 30f;
    /// <summary>
    /// The score given for killing the enemy
    /// </summary>
    public int score_Value = 0;
    /// <summary>
    /// The cracks that spawn when broken
    /// </summary>
    public GameObject cracks;
    /// <summary>
    /// The player game object
    /// </summary>
    private GameObject player;
    /// <summary>
    /// the play script attached to the player
    /// </summary>
    private Player_Controler player_Script;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player_Script = player.GetComponent<Player_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            cracks.SetActive(true);
            //add points
        }
    }
    /// <summary>
    /// Happens when the enemy hits another object
    /// </summary>
    /// <param name="collision">The object the enemy bumps into</param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_Bullet")
        {
            int bullet_Damage = ((int)Random.Range(1.0f, 6.999999f));
            health -= player_Script.getBaseDamage() * bullet_Damage;
            Destroy(collision.gameObject);
        }
    }
}
