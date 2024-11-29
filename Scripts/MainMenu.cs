using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the main menu functionality, allowing the player to start or quit the game.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the first game scene when "Play" is clicked.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    /// <summary>
    /// Quits the game when "Quit" is clicked.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
