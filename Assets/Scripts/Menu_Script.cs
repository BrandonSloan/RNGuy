using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Author: Blake Henderson
//Date: 11/13/2020
public class Menu_Script : MonoBehaviour
{
    /// <summary>
    /// Starts the game.
    /// </summary>
    public void startGame()
    {
        SceneManager.LoadScene("Level_1");
    }
    /// <summary>
    /// Quits the game.
    /// </summary>
    public void quitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
