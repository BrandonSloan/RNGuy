﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Blake Henderson
//Date : 11/10/2020
public class Projectile : MonoBehaviour
{
    /// <summary>
    /// The force behind the bullet
    /// </summary>
    public int thrust = 100;
    /// <summary>
    /// The rigid body of the projectile
    /// </summary>
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        BulletDepawn();
        transform.rotation.Set(0f, 0f, 90f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(transform.up * thrust);
    }
    /// <summary>
    /// Despawns the bullet after a given number of time.
    /// </summary>
    private void BulletDepawn()
    {
        Destroy(gameObject, 0.75f);
    }
}
