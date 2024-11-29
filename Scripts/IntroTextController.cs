using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Controls the introduction text display and the transition between different parts of the introduction.
/// Manages the display of text, buttons, and timing before allowing the player to proceed.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class IntroTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI introText; //Reference to the text display area
    [SerializeField] private Button nextButton; //Button to proceed to the next text part
    [SerializeField] private Button clickableImageButton; //Reference to a clickable image button
    [SerializeField] private GameObject textContainer; //Container holding the text display UI
    [SerializeField] private float waitTime = 5f; //Wait time before the next button becomes visible

    private string[] sentencesPart1; //First set of introduction sentences
    private string[] sentencesPart2; //Second set of introduction sentences
    private int currentPart = 1; //Tracks which part of the introduction is being shown

    private void Start()
    {
        // Define the sentences to be displayed in part 1 and part 2
        sentencesPart1 = new string[] {
            "You have been offered a prestigious role as the Vice Chancellor of Success University.",
            "This university is located in the United Kingdom and requires improvements in several key areas.",
            "Your new job as Vice Chancellor is to ensure that the university reaches greater heights.",
            "You must make decisions that are both sustainable and satisfying to all stakeholders, including students and staff.",
            "You will face various scenarios that will test your competence in this role.",
            "Don’t worry, you will have four advisors to assist you with making decisions."
        };

        sentencesPart2 = new string[] {
            "Each advisor has their own priorities, so listen carefully to their advice.",
            "Ultimately, you must make the best choice for the university.",
            "Before the first two scenarios, you have a drag and drop Game scene.",
            "First, you will play a game of priority that requires you to match your to-do list cards to their levels of priority.",
            "You get 5 points for each one done correctly and a total of 40 points for getting everything right.",
            "Your first two scenarios will have a total of 60 points for the best choice, which will then be added to your initial points to get the total.",
            "Click on any of the computer screens to get started."
        };

        introText.text = ""; // Start with no text displayed
        nextButton.gameObject.SetActive(false); // Hide the next button initially

        DisplayPart1(); // Display the first part of the introduction
        StartCoroutine(WaitAndShowNextButton()); // Wait before showing the next button
    }

    /// <summary>
    /// Displays the first part of the introduction text.
    /// </summary>
    private void DisplayPart1()
    {
        introText.text = ""; // Clear the text display

        // Show all the sentences for part 1
        foreach (string sentence in sentencesPart1)
        {
            introText.text += sentence + "\n\n";
        }
    }

    /// <summary>
    /// Displays the second part of the introduction text.
    /// </summary>
    private void DisplayPart2()
    {
        introText.text = ""; // Clear the text display

        // Show all the sentences for part 2
        foreach (string sentence in sentencesPart2)
        {
            introText.text += sentence + "\n\n";
        }
    }

    /// <summary>
    /// Waits for the specified time and then shows the next button.
    /// </summary>
    private IEnumerator WaitAndShowNextButton()
    {
        yield return new WaitForSeconds(waitTime); // Wait for the specified time
        nextButton.gameObject.SetActive(true); // Show the next button
    }

    /// <summary>
    /// Handles the logic when the next button is clicked.
    /// </summary>
    public void OnNextButtonClicked()
    {
        if (currentPart == 1)
        {
            // Show the second part of the introduction
            DisplayPart2();
            nextButton.gameObject.SetActive(false); // Hide the button after clicking
            StartCoroutine(WaitAndShowNextButton()); // Wait and show the button again
            currentPart = 2; // Update to the second part
        }
        else if (currentPart == 2)
        {
            // Hide text and proceed after the second part
            nextButton.gameObject.SetActive(false); // Hide the next button
            textContainer.SetActive(false); // Hide the text container
        }
    }
}
