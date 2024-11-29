using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the logic and flow of Scene 6, managing dialogue, email reading, and counselor interaction.
/// </summary>
/// <author>Emmanuel Nwokoro</author>

public class Scene6Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText; // Displays the dialogue text
    [SerializeField] private Button nextButton; // Button to progress through the dialogue
    [SerializeField] private GameObject compScreen; // Computer screen with email button
    [SerializeField] private Button emailButton; // Button to open the email
    [SerializeField] private GameObject counselorPanel; // Panel with counselor options
    [SerializeField] private GameObject textContainer; // Container for text dialogues
    [SerializeField] private GameObject notepad; // Notepad UI object

    private string[] dialogSentences; // Holds the dialogue lines
    private int dialogIndex = 0; // Tracks the current dialogue index
    private bool emailOpened = false; // Tracks whether the email has been opened
    private bool scenarioReadingStarted = false; // Tracks if scenario reading has started

    /// <summary>
    /// Initializes the scene, setting up the initial dialogue and hiding UI elements.
    /// </summary>
    private void Start()
    {
        // Initialize dialogue for the start of the scene
        dialogSentences = new string[]
        {
            "Good morning, Vice Chancellor! It's another sunny day at Success University.",
            "The students are energetic, and the week is filled with potential.",
            "You’re prepared to tackle another challenge and lead the university forward.",
            "Let’s see what today has in store for you.",
            "Click on the email icon to view today’s challenge."
        };

        // Setup button listeners and initial UI states
        nextButton.onClick.AddListener(ShowNextDialog);
        emailButton.onClick.AddListener(OnEmailButtonClicked);
        compScreen.SetActive(false); // Hide computer screen initially
        counselorPanel.SetActive(false); // Hide counselor panel initially
        textContainer.SetActive(false); // Hide text container initially
    }

    /// <summary>
    /// Triggered when the notepad is closed, switching back to dialogue display.
    /// </summary>
    public void NotepadClosed()
    {
        notepad.SetActive(false); // Hide the notepad
        textContainer.SetActive(true); // Show the dialogue text container
        dialogText.text = dialogSentences[dialogIndex]; // Display the first dialogue line
    }

    /// <summary>
    /// Advances the dialogue based on the email reading state.
    /// </summary>
    private void ShowNextDialog()
    {
        if (!emailOpened)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length - 1) // Progress through positive day dialogue
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else if (dialogIndex == dialogSentences.Length - 1) // Last line shows the email
            {
                dialogText.text = dialogSentences[dialogIndex];
                nextButton.gameObject.SetActive(false); // Hide next button
                compScreen.SetActive(true); // Show the email icon
            }
        }
        else if (scenarioReadingStarted)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length) // Continue reading scenario
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else
            {
                nextButton.gameObject.SetActive(false); // Hide next button after scenario
                dialogText.text = ""; // Clear text before showing the counselor panel
                counselorPanel.SetActive(true); // Show the counselor panel
            }
        }
    }

    /// <summary>
    /// Handles the logic for displaying the scenario email when the email button is clicked.
    /// </summary>
    private void OnEmailButtonClicked()
    {
        // Update dialogue with email scenario content
        dialogSentences = new string[]
        {
            "Subject: IT Infrastructure Overhaul",
            "Dear Vice Chancellor,",
            "We’ve been experiencing ongoing issues with our IT infrastructure.",
            "Several key systems are outdated, causing frequent downtime and inefficiencies across departments.",
            "Upgrading these systems will be costly, and we need a solution that minimizes disruptions while addressing the urgent issues.",
            "Please recommend the best approach to handle these upgrades, keeping both budget and long-term functionality in mind.",
            "Best regards,",
            "Michael, Director of IT"
        };
        dialogIndex = 0;
        dialogText.text = dialogSentences[dialogIndex]; // Display the email content
        compScreen.SetActive(false); // Hide the computer screen after email is opened
        emailOpened = true; // Set flag to indicate email has been opened
        nextButton.gameObject.SetActive(true); // Show next button to continue dialogue
        scenarioReadingStarted = true; // Mark that scenario reading has started
    }
}
