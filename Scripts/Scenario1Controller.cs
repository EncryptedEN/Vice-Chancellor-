using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the flow of the first scenario where the player reads an email 
/// and interacts with counselors. This script manages dialogues, email interaction, 
/// and displays the counselor panel at the appropriate time.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class Scenario1Controller : MonoBehaviour
{
    // UI components for dialogues, buttons, and panels
    [SerializeField] private TextMeshProUGUI dialogText; // Text component to display dialogue
    [SerializeField] private Button nextButton; // Button to progress to the next dialogue
    [SerializeField] private GameObject compScreen; // Screen containing the email button
    [SerializeField] private Button emailButton; // Button for opening the email
    [SerializeField] private GameObject counselorPanel; // Panel for displaying counselor options

    // Dialogue and state tracking variables
    private string[] dialogSentences; // Array to store dialogue lines
    private int dialogIndex = 0; // Tracks the current dialogue index
    private bool emailOpened = false; // Tracks whether the email has been opened

    /// <summary>
    /// Initializes the dialogue and button listeners at the start.
    /// </summary>
    private void Start()
    {
        // Initial set of dialogue lines for the scenario
        dialogSentences = new string[]
        {
            "It's Monday morning, you have just arrived at work and found an email.",
            "Click the email icon on the screen to read your email."
        };

        // Display the first line of dialogue
        dialogText.text = dialogSentences[dialogIndex];

        // Set up button listeners
        nextButton.onClick.AddListener(ShowNextDialog);
        emailButton.onClick.AddListener(OnEmailButtonClicked);

        // Initially hide the computer screen and counselor panel
        compScreen.SetActive(false);
        counselorPanel.SetActive(false);
    }

    /// <summary>
    /// Displays the next line of dialogue or shows the email panel when appropriate.
    /// </summary>
    private void ShowNextDialog()
    {
        // Before the email is opened, show the next dialogue line or email screen
        if (!emailOpened)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length)
            {
                dialogText.text = dialogSentences[dialogIndex];
                nextButton.gameObject.SetActive(false); // Hide next button for email interaction
                compScreen.SetActive(true); // Show computer screen to open email
            }
        }
        // After email is opened, continue displaying the rest of the dialogue
        else
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length)
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else
            {
                nextButton.gameObject.SetActive(false); // Hide the next button when dialogue ends
                dialogText.text = ""; // Clear dialogue text
                counselorPanel.SetActive(true); // Show the counselor panel for the player
                Debug.Log("Email reading complete, CounselorPanel activated.");
            }
        }
    }

    /// <summary>
    /// Triggered when the email button is clicked. Updates the dialogue to reflect the email content.
    /// </summary>
    private void OnEmailButtonClicked()
    {
        // Dialogue content for the email
        dialogSentences = new string[]
        {
            "Immediate Attention Required: Online Learning Platform Issues",
            "Dear Vice Chancellor,We've been receiving numerous complaints from students about our online learning platform.",
            "The primary concerns are usability issues and outdated features, which are impacting their learning experience.",
            "We urgently need to consider upgrading the system to better support our students and faculty.",
            "Best regards,",
            "Ricardo",
            "Director of Digital Learning"
        };

        // Reset dialogue index and update the text to the first email line
        dialogIndex = 0;
        dialogText.text = dialogSentences[dialogIndex];

        // Hide the computer screen and indicate that the email has been opened
        compScreen.SetActive(false);
        emailOpened = true;

        // Show the next button to allow progression through the email dialogue
        nextButton.gameObject.SetActive(true);
    }
}
