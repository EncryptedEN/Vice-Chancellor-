using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the flow of dialog and email interaction for Scene 4.
/// Handles the positive introduction, email reading, and triggering the CounselorPanel for decision-making.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class Scene4Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText; // Reference to the dialog text UI
    [SerializeField] private Button nextButton; // Button to progress through the dialog
    [SerializeField] private GameObject compScreen; // The computer screen with the email button
    [SerializeField] private Button emailButton; // Button to open the email on the computer screen
    [SerializeField] private GameObject counselorPanel; // Panel containing counselor advice options
    [SerializeField] private GameObject textContainer; // Container for dialog text display
    [SerializeField] private GameObject notepad; // Notepad UI for showing initial instructions

    private string[] dialogSentences; // Array of sentences for the dialog
    private int dialogIndex = 0; // Index to track the current sentence in the dialog
    private bool emailOpened = false; // Flag to indicate if the email has been opened
    private bool scenarioReadingStarted = false; // Flag to track when scenario reading starts

    /// <summary>
    /// Initializes the scene by setting up dialog and button listeners.
    /// </summary>
    private void Start()
    {
        // Dialog sentences for the positive morning introduction in Scene 4
        dialogSentences = new string[]
        {
            "Good morning, Vice Chancellor! It's another sunny day at Success University.",
            "The students are energetic, the faculty is motivated, and the week feels promising.",
            "You’re ready to tackle another challenge to ensure a smooth and productive week.",
            "Let’s see what today has in store for you.",
            "Click on the email icon to view today’s challenge."
        };

        nextButton.onClick.AddListener(ShowNextDialog); // Attach listener for progressing through dialog
        emailButton.onClick.AddListener(OnEmailButtonClicked); // Attach listener for opening the email
        compScreen.SetActive(false); // Hide the computer screen initially
        counselorPanel.SetActive(false); // Hide the CounselorPanel initially
        textContainer.SetActive(false); // Hide the text container initially
    }

    /// <summary>
    /// Triggered when the notepad is closed, showing the textContainer and dialog.
    /// </summary>
    public void NotepadClosed()
    {
        notepad.SetActive(false); // Hide the notepad
        textContainer.SetActive(true); // Show the text container with the dialog
        dialogText.text = dialogSentences[dialogIndex]; // Display the first line of dialog
    }

    /// <summary>
    /// Displays the next dialog sentence or triggers the computer screen for email interaction.
    /// </summary>
    private void ShowNextDialog()
    {
        if (!emailOpened)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length - 1) // Progress through the positive day dialog
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else if (dialogIndex == dialogSentences.Length - 1) // Last line before showing computer screen
            {
                dialogText.text = dialogSentences[dialogIndex];
                nextButton.gameObject.SetActive(false); // Hide the next button
                compScreen.SetActive(true); // Show the computer screen for email interaction
            }
        }
        else if (scenarioReadingStarted)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length)
            {
                dialogText.text = dialogSentences[dialogIndex]; // Continue reading the scenario email
            }
            else
            {
                nextButton.gameObject.SetActive(false); // Hide the next button after email reading
                dialogText.text = ""; // Clear dialog text before showing CounselorPanel
                counselorPanel.SetActive(true); // Show the CounselorPanel for decision-making
            }
        }
    }

    /// <summary>
    /// Updates the dialog with the scenario content once the email is opened.
    /// </summary>
    private void OnEmailButtonClicked()
    {
        // Email content and scenario details
        dialogSentences = new string[]
        {
            "Subject: Campus Transportation Challenge",
            "Dear Vice Chancellor,",
            "We’ve been receiving increasing concerns from students and staff regarding transportation across campus.",
            "The campus shuttle system is often delayed, leaving students stranded, and there are limited parking spaces.",
            "The university's budget can cover either shuttle expansion or parking improvements.",
            "Please recommend the best course of action to balance budget constraints and address these issues.",
            "Best regards,",
            "Michael, Director of Operations"
        };
        dialogIndex = 0;
        dialogText.text = dialogSentences[dialogIndex]; // Start displaying the email content
        compScreen.SetActive(false); // Hide the computer screen after email is opened
        emailOpened = true; // Mark the email as opened
        nextButton.gameObject.SetActive(true); // Show the next button to continue reading the email
        scenarioReadingStarted = true; // Indicate that the scenario reading has started
    }
}
