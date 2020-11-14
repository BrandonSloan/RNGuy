using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Edited by Blake Henderson on 11/13/2020
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int minMaxHealth = 5;
    public int maxMaxHealth = 20;
    public int maxHealth;
    public static int currentHealth;
    public HealthBar healthBar;
    public bool playerDiedGameRestarted;

    void Awake()
    {
    }

    void Start()
    {
        maxHealth = UnityEngine.Random.Range(minMaxHealth, maxMaxHealth);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public void takeDamage(int a)
    {
        currentHealth -= a;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
