using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
       DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        maxHealth = UnityEngine.Random.Range(minMaxHealth, maxMaxHealth);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage(int a)
    {
        currentHealth -= a;
        healthBar.SetHealth(currentHealth);
    }
}
