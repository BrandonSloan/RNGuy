using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text healthText;

    private int health;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();

        healthText = GameObject.Find("HealthText").GetComponent<Text>();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void heal()
    {
        health++;
        healthText.text = "x" + health;
    }

    public void takeDamage()
    {
        health--;
        if (health >= 0)
        {
            healthText.text = "x" + health;
        }
       
    }
}
