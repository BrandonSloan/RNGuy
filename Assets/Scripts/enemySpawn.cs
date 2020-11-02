using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int yPos;
    Vector2 spawnLocation;
    public int numEnemies;
    private int activeEnemies = 0;
    private void Update()
    {
        while (activeEnemies <= numEnemies)
        {
            xPos = Random.Range(-16, 15);
            yPos = Random.Range(-9, 8);
            spawnLocation = new Vector2(xPos, yPos);
            Instantiate(enemy, spawnLocation, Quaternion.identity);
            activeEnemies++;
        }
    }
}
