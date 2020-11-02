using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//Author: Blake Henderson
//Date : 10/23/2020
public class Player_Shooting : MonoBehaviour
{
    /// <summary>
    /// The actual projectile in the form of a prefab
    /// </summary>
    public GameObject projectile;
    /// <summary>
    /// Where the projectiles spawn
    /// </summary>
    public GameObject spawn;
    /// <summary>
    /// The player character's data, used to get baseDamage
    /// </summary>
    private Player_Controler player;
    
    /// <summary>
    /// where the projectile is spawned, derived from spawn
    /// </summary>
    private Vector2 position;
    /// <summary>
    /// What angle the projectile is fired at, determined by mouse position
    /// </summary>
    private Quaternion shotAngle;
    // Update is called once per frame
    void Update()
    {
        position = spawn.transform.position;
        shotAngle = calcShotAngle();
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, position, shotAngle);
        }
    }
    /// <summary>
    /// This calculates the angle of the shot
    /// </summary>
    /// <returns>The angle of the shot</returns>
    private Quaternion calcShotAngle()
    {
        Vector2 mouseScreen = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mouseScreen);
        float angle = Mathf.Atan2(mousePos.y - spawn.transform.position.y,
            mousePos.x - spawn.transform.position.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle - 90);
    }
}
