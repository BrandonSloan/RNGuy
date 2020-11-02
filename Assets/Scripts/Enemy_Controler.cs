using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controler : MonoBehaviour
{
    public float enemy_Health = 30f;
    public GameObject enemy;
    private GameObject player;
    private Player_Controler player_Script;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player_Script = player.GetComponent<Player_Controler>();
    }
    void Update()
    {
        if(enemy_Health <= 0)
        {
            Destroy(enemy);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player_Bullet")
        {
            int bullet_Damage = ((int)Random.Range(1.0f, 6.999999f));
            enemy_Health -= player_Script.getBaseDamage() * bullet_Damage;
            Destroy(collision.gameObject);
        }
    }
}
