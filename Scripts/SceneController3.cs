using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the dialogue and interaction for Scene 3.
/// Manages the display of initial positive weather dialogue and email scenario related to campus renovation.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class SceneController3 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject compScreen; // Computer screen where the email will be displayed
    [SerializeField] private Button emailButton; // Button for interacting with the email icon
    [SerializeField] private GameObject counselorPanel; // Panel containing counselor buttons
    [SerializeField] private GameObject textContainer; // Container for dialogue text display

    private string[] dialogSentences; // Array holding all dialogue sentences
    private int dialogIndex = 0; // Tracks the current position in the dialogue
    private bool emailOpened = false; // Tracks if the email has been opened
    private bool scenarioReadingStarted = false; // Tracks if the scenario is being read

    /// <summary>
    /// Initializes the dialogue and buttons for Scene 3.
    /// Starts with a positive introduction about the day, leading to the email challenge.
    /// </summary>
    private void Start()
    {
        // Initial positive weather dialogue and introduction to the day
        dialogSentences = new string[]
        {
            "Yay! It's a new week at Success University!, the sun is shining, and the campus is bustling with energy.",
            "You can't help but feel optimistic about the week ahead.",
            "The weather is perfect, setting the tone for productivity and progress.",
            "You're ready to make impactful decisions and lead the university forward.",
            "Click on the email icon on the screen to view today’s challenge."
        };

        // Set the initial dialogue text and button actions
        dialogText.text = dialogSentences[dialogIndex];
        nextButton.onClick.AddListener(ShowNextDialog);
        emailButton.onClick.AddListener(OnEmailButtonClicked);

        // Hide or show elements at the start of the scene
        compScreen.SetActive(false); // Initially hide the computer screen
        counselorPanel.SetActive(false); // Hide the counselor panel until later
        textContainer.SetActive(true); // Show the text container with the dialogue
    }

    /// <summary>
    /// Handles the progression of dialogue. Shows email button after the initial dialogue.
    /// </summary>
    private void ShowNextDialog()
    {
        // Show the next line of dialogue if the email hasn't been opened yet
        if (!emailOpened)
        {
            dialogIndex++;
            if (dialogIndex < dialogSentences.Length - 1) // Loop through positive day message
            {
                dialogText.text = dialogSentences[dialogIndex];
            }
            else if (dialogIndex == dialogSentences.Length - 1) // Show the final line + computer screen
            {
                dialogText.text = dialogSentences[dialogIndex];
                nextButton.gameObject.SetActive(false); // Hide the next button
                compScreen.SetActive(true); // Show the computer screen for email interaction
            }
        }
        // If email is opened, proceed to the scenario reading dialogue
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
                dialogText.text = ""; // Clear the dialogue text
                counselorPanel.SetActive(true); // Show the counselor panel when scenario is complete
            }
        }
    }

    /// <summary>
    /// Displays the email content when the email icon is clicked, starting the scenario.
    /// </summary>
    private void OnEmailButtonClicked()
    {
        // Update dialogue with email scenario content
        dialogSentences = new string[]
        {
            "Subject: Campus Renovation Project",
            "Dear Vice Chancellor, our campus buildings are aging and in need of renovation.",
            "We’ve received numerous requests for better study spaces, improved access, and eco-friendly systems.",
            "With a limited budget, we need to prioritize certain renovations.",
            "Could you make a decision on how to proceed, considering the needs of students and staff?",
            "Best regards,",
            "Michael, Director of Campus Infrastructure"
        };

        // Reset dialogue index and update text
        dialogIndex = 0;
        dialogText.text = dialogSentences[dialogIndex];
        compScreen.SetActive(false); // Hide the computer screen after email interaction
        emailOpened = true; // Flag to track that the email has been opened
        nextButton.gameObject.SetActive(true); // Show the next button to continue scenario reading
        scenarioReadingStarted = true; // Flag to start scenario reading
    }
}
