using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages various scene transitions based on different button clicks in the game.
/// It handles navigation between game scenes and provides functionality for resetting game progress.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class Functionalities : MonoBehaviour
{
    /// <summary>
    /// Loads the "Recess1" scene when the image is clicked.
    /// </summary>
    public void OnImageClick()
    {
        SceneManager.LoadScene("Recess1");
    }

    /// <summary>
    /// Loads the "Scene1" when the cancel button is clicked.
    /// </summary>
    public void OnCancelClick()
    {
        SceneManager.LoadScene("Scene1");
    }

    /// <summary>
    /// Loads the "Scene2" when the second cancel button is clicked.
    /// </summary>
    public void OnCancelClick2()
    {
        SceneManager.LoadScene("Scene2");
    }

    /// <summary>
    /// Loads the "Recess2" scene when the feedback for cancel button 1 is clicked.
    /// </summary>
    public void OnFeedbackCancel1()
    {
        SceneManager.LoadScene("Recess2");
    }

    /// <summary>
    /// Loads the "Scene3" when the feedback for cancel button 2 is clicked.
    /// </summary>
    public void OnFeedbackCancel2()
    {
        SceneManager.LoadScene("Scene3");
    }

    /// <summary>
    /// Loads the "Scene4" when the feedback for cancel button 3 is clicked.
    /// </summary>
    public void OnFeedbackCancel3()
    {
        SceneManager.LoadScene("Scene4");
    }

    /// <summary>
    /// Loads the "Scene5" when the feedback for cancel button 4 is clicked.
    /// </summary>
    public void OnFeedbackCancel4()
    {
        SceneManager.LoadScene("Scene5");
    }

    /// <summary>
    /// Loads the "Scene6" when the feedback for cancel button 5 is clicked.
    /// </summary>
    public void OnFeedbackCancel5()
    {
        SceneManager.LoadScene("Scene6");
    }

    /// <summary>
    /// Loads the "FeedBackSummary" scene when feedback for cancel button 6 is clicked.
    /// </summary>
    public void OnFeedbackCancel6()
    {
        SceneManager.LoadScene("FeedBackSummary");
    }

    /// <summary>
    /// Resets all game progress and navigates to the main menu when the "Give Up" button is clicked.
    /// </summary>
    public void OnGiveUpClick()
    {
        GameProgressM.ResetAllGameProgress();  // Reset game progress for both drag-and-drop managers
        SceneManager.LoadScene("MainMenu");    // Load the main menu scene
    }
}
