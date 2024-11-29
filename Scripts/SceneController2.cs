using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the flow of dialogue and scenario progression in Scene 2.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class Scene2Controller : MonoBehaviour
{
    // UI elements for displaying dialogue and interaction components
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject compScreen; // Screen with email button
    [SerializeField] private Button emailButton;    // Button to read the email
    [SerializeField] private GameObject counselorPanel; // Panel for counselor options
    [SerializeField] private GameObject textContainer;  // Container for dialogue text

    private string[] dialogSentences; // Array of dialogue lines
    private int dialogIndex = 0;      // Tracks the current dialogue line
    private bool emailOpened = false; // Tracks if the email has been opened
    private bool scenarioReadingStarted = false; // Tracks if the scenario reading has begun

    /// <summary>
    /// Initializes the dialogue and sets up event listeners.
    /// </summary>
    private void Start()
    {
        // Initial lines of dialogue, introducing the player to the scene
        dialogSentences = new string[]
        {
            "Yay! It’s a new week at Success University! The sky is clear and bright, welcoming a fresh start.",
            "Despite the brisk air, you can feel positivity flowing through the campus.",
            "You sip your coffee, ready for the challenges ahead.",
            "Today seems like a perfect day to make an impact!",
            "Click on the email icon to view today’s challenge."
        };

        dialogText.text = dialogSentences[dialogIndex]; // Display the first line of dialogue
        nextButton.onClick.AddListener(ShowNextDialog); // Set up the 'Next' button listener
        emailButton.onClick.AddListener(OnEmailButtonClicked); // Set up the email button listener
        compScreen.SetActive(false);    // Hide the email screen initially
        counselorPanel.SetActive(false); // Hide the counselor panel initially
        textContainer.SetActive(false);  // Hide the text container initially
    }

    /// <summary>
    /// Displays the next line of dialogue or reveals the email.
    /// </summary>
    private void ShowNextDialog()
    {
        if (!emailOpened)
        {
            dialogIndex++; // Move to the next dialogue line
            if (dialogIndex < dialogSentences.Length)
            {
                dialogText.text = dialogSentences[dialogIndex]; // Update the dialogue text
            }
            else
            {
                nextButton.gameObject.SetActive(false); // Hide the 'Next' button
                compScreen.SetActive(true); // Show the computer screen with the email button
            }
        }
        else if (scenarioReadingStarted)
        {
            dialogIndex++; // Move to the next scenario dialogue
            if (dialogIndex < dialogSentences.Length)
            {
                dialogText.text = dialogSentences[dialogIndex]; // Update the scenario text
            }
            else
            {
                nextButton.gameObject.SetActive(false); // Hide the 'Next' button after the scenario
                dialogText.text = ""; // Clear the dialogue text
                counselorPanel.SetActive(true); // Show the counselor panel after the scenario
            }
        }
    }

    /// <summary>
    /// Handles the email button click event and displays the scenario content.
    /// </summary>
    private void OnEmailButtonClicked()
    {
        // Scenario content detailing the energy efficiency challenge
        dialogSentences = new string[]
        {
            "Subject: Campus Energy Efficiency Project",
            "Dear Vice Chancellor,",
            "We have received numerous complaints from students and staff regarding inconsistent energy usage across campus.",
            "Several buildings, especially older ones, are experiencing power shortages and high energy consumption, leading to discomfort and inefficiencies.",
            "The university needs to improve energy systems to reduce operational costs and align with sustainability goals.",
            "Could you please decide on the best approach to address these concerns, while balancing budget constraints and ensuring the least disruption to campus activities?",
            "Your decision will directly impact students and staff who are affected by energy shortages.",
            "Best regards,",
            "Michael, Director of Facilities"
        };

        dialogIndex = 0; // Reset the dialogue index
        dialogText.text = dialogSentences[dialogIndex]; // Display the first line of the email content
        compScreen.SetActive(false); // Hide the computer screen after email is clicked
        emailOpened = true; // Mark the email as opened
        nextButton.gameObject.SetActive(true); // Show the 'Next' button to continue scenario
        scenarioReadingStarted = true; // Start scenario reading
        textContainer.SetActive(true); // Show the text container for scenario content
    }
}
