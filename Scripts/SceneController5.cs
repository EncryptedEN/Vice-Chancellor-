using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the flow of dialog, email interaction, and decision-making for Scene 5.
/// Handles the positive morning introduction, email reading, and activating the CounselorPanel for user decisions.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class Scene5Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText; // Reference to the dialog text UI
    [SerializeField] private Button nextButton; // Button to progress through the dialog
    [SerializeField] private GameObject compScreen; // The computer screen with the email icon
    [SerializeField] private Button emailButton; // Button to open the email
    [SerializeField] private GameObject counselorPanel; // Panel containing counselor advice buttons
    [SerializeField] private GameObject textContainer; // Container for dialog text display
    [SerializeField] private GameObject notepad; // Notepad UI for showing initial instructions

    private string[] dialogSentences; // Array holding the dialog sentences
    private int dialogIndex = 0; // Index to track current sentence in the dialog
    private bool emailOpened = false; // Flag to indicate if the email has been opened
    private bool scenarioReadingStarted = false; // Flag to track when the scenario reading begins

    /// <summary>
    /// Initializes the scene with dialog sentences and button listeners.
    /// </summary>
    private void Start()
    {
        // Dialog sentences for Scene 5's introduction
        dialogSentences = new string[]
        {
            "Good morning, Vice Chancellor! It's another productive week at Success University.",
            "Students are excited, and the energy on campus is high.",
            "As always, you’re prepared to tackle the challenges of the week and make impactful decisions.",
            "Let’s see what today has in store for you.",
            "Click on the email icon to view today’s challenge."
        };

        nextButton.onClick.AddListener(ShowNextDialog); // Listener for progressing through the dialog
        emailButton.onClick.AddListener(OnEmailButtonClicked); // Listener for opening the email
        compScreen.SetActive(false); // Hide the computer screen initially
        counselorPanel.SetActive(false); // Hide the CounselorPanel initially
        textContainer.SetActive(false); // Hide the text container initially
    }

    /// <summary>
    /// Triggered when the notepad closes, showing the text container and allowing dialog progression.
    /// </summary>
    public void NotepadClosed()
    {
        notepad.SetActive(false); // Hide the notepad
        textContainer.SetActive(true); // Show the text container
        
        // Immediately display the first line of the positive morning message
        dialogText.text = dialogSentences[dialogIndex];
        
        // Set the next button active to allow progression through the dialog
        nextButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// Displays the next sentence in the dialog or triggers email interaction when needed.
    /// </summary>
    private void ShowNextDialog()
    {
        if (!emailOpened)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length - 1) // Display positive day dialog
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else if (dialogIndex == dialogSentences.Length - 1) // Last dialog line before email
            {
                dialogText.text = dialogSentences[dialogIndex]; 
                nextButton.gameObject.SetActive(false); // Hide the next button
                compScreen.SetActive(true); // Show the computer screen with the email icon
            }
        }
        else if (scenarioReadingStarted)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length)
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else
            {
                nextButton.gameObject.SetActive(false); // Hide the next button after scenario
                dialogText.text = ""; // Clear the dialog text before showing CounselorPanel
                counselorPanel.SetActive(true); // Show the CounselorPanel for decision-making
            }
        }
    }

    /// <summary>
    /// Updates the dialog with the email scenario content once the email is opened.
    /// </summary>
    private void OnEmailButtonClicked()
    {
        // Email content and scenario details for Scene 5
        dialogSentences = new string[]
        {
            "Subject: Launching the University Community Outreach Program",
            "Dear Vice Chancellor,",
            "We are preparing to launch a new University Community Outreach Program aimed at improving our ties with local businesses and offering practical experiences for students.",
            "While this program offers great potential, it requires careful coordination between departments, local businesses, and students.",
            "There are some concerns about how to structure the program to ensure maximum participation and benefit for everyone involved.",
            "We need your input on how to organize the effort in a way that fosters smooth operation while keeping us within budget.",
            "Best regards,",
            "Catherine, Director of External Relations"
        };
        dialogIndex = 0;
        dialogText.text = dialogSentences[dialogIndex]; // Start displaying the email content
        compScreen.SetActive(false); // Hide the computer screen after clicking the email icon
        emailOpened = true; // Flag indicating the email has been opened
        nextButton.gameObject.SetActive(true); // Show the next button to continue dialog
        scenarioReadingStarted = true; // Flag to indicate scenario reading has started
    }
}
