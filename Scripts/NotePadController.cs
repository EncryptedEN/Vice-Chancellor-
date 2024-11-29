using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Controls the behavior of the notepad UI that provides instructions 
/// and details before moving to the main scene components.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class NotepadController : MonoBehaviour
{
    [SerializeField] private GameObject notepad; // The Notepad UI
    [SerializeField] private TextMeshProUGUI notepadText; // The TextMeshPro for displaying notepad content
    [SerializeField] private Button padNextButton; // Button to advance to the next notepad instruction
    [SerializeField] private GameObject textContainer; // Container for all other scene components

    // The array of text to display on the notepad
    private string[] notepadContents;
    private int currentTextIndex = 0; // Tracks the current notepad text being displayed

    /// <summary>
    /// Initializes the notepad content and sets up the UI for the scene.
    /// </summary>
    private void Start()
    {
        // The instructional content for the notepad
        notepadContents = new string[]
        {
            "Now you will be presented with a challenge that requires you to provide a solution.",
            "After that, click on which advisor you want to get advice from.",
            "Each of them will share their insight with you based on their perspective.",
            "Once you have decided which solution is best, click 'Accept' to select it."
        };

        // Ensure only the notepad is visible at the beginning
        notepad.SetActive(true);
        textContainer.SetActive(false); // Hide other scene components initially

        // Set up the button to display the next notepad text when clicked
        padNextButton.onClick.AddListener(DisplayNextNotepadText);

        // Display the first notepad text
        DisplayNextNotepadText();
    }

    /// <summary>
    /// Reopens the notepad when the question mark button is clicked, hiding other components.
    /// </summary>
    public void QuestionMarkButton()
    {
        notepad.SetActive(true); // Show the notepad
        textContainer.SetActive(false); // Hide other scene components
        padNextButton.onClick.AddListener(DisplayNextNotepadText); // Add listener to the button
        DisplayNextNotepadText(); // Display the first notepad text again
    }

    /// <summary>
    /// Displays the next text in the notepad or closes the notepad if all content is shown.
    /// </summary>
    private void DisplayNextNotepadText()
    {
        if (currentTextIndex < notepadContents.Length)
        {
            notepadText.text = notepadContents[currentTextIndex]; // Show the current text
            currentTextIndex++; // Move to the next text
        }
        else
        {
            CloseNotepad(); // Close the notepad when all text has been shown
        }
    }

    /// <summary>
    /// Closes the notepad and shows other scene components, resetting the notepad state.
    /// </summary>
    private void CloseNotepad()
    {
        notepad.SetActive(false); // Hide the notepad
        textContainer.SetActive(true); // Show all other scene components
        padNextButton.onClick.RemoveListener(DisplayNextNotepadText); // Remove listener to avoid duplicate calls
        currentTextIndex = 0; // Reset the text index for future use
    }
}


