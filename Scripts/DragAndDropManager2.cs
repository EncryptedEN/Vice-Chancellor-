using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// DragAndDropManagers2 handles the drag-and-drop functionality of task cards within the game.
/// The cards are matched to specific panels representing priority categories.
/// This script also manages the score, feedback, and countdown timer.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class DragAndDropManagers2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Serialized fields to reference various UI components in the game
    [SerializeField] private RectTransform canvasTransform;
    [SerializeField] private GameObject urgentImportantPanel;
    [SerializeField] private GameObject notUrgentNotImportantPanel;
    [SerializeField] private GameObject notUrgentImportantPanel;
    [SerializeField] private GameObject urgentNotImportantPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text countdownText; // Reference to Countdown Text
    [SerializeField] private GameObject feedbackPanel; // Reference to Feedback Panel
    [SerializeField] private TMP_Text weldoneText; // Reference to Weldone Text
    [SerializeField] private TMP_Text scoreDisplayText; // Reference to Score Display Text

    // Internal references for managing drag-and-drop behavior
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Variables to track the task card's initial position
    private Vector3 initialPosition;
    private Transform initialParent;

    // Static score variable shared across instances of this script
    private static int score = 0;

    // Flags to track whether each task card has been correctly matched
    private static bool isTaskCard1Matched = false;
    private static bool isTaskCard2Matched = false;
    private static bool isTaskCard3Matched = false;
    private static bool isTaskCard4Matched = false;
    private static bool isTaskCard5Matched = false;
    private static bool isTaskCard6Matched = false;
    private static bool isTaskCard7Matched = false;
    private static bool isTaskCard8Matched = false;

    // Tracks whether a task card has been placed in the correct panel
    private bool isTaskCardCorrectlyPlaced = false;

    // Countdown timer variables
    private float countdown = 30f; // Timer starts at 120 seconds
    private bool timerActive = true; // Flag to determine if the timer is active

    // Property to retrieve the current score
    public static int Score
    {
        get { return score; }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded. It initializes components.
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Get the RectTransform of the task card
        canvasGroup = GetComponent<CanvasGroup>(); // Get the CanvasGroup to manage interaction
        canvas = canvasTransform.GetComponent<Canvas>(); // Get the parent canvas for positioning
        UpdateScoreText(); // Update the score display at the start of the game
        feedbackPanel.SetActive(false); // Ensure feedback panel is hidden initially
    }

    /// <summary>
    /// Update is called once per frame. It handles the countdown timer.
    /// </summary>
    private void Update()
    {
        if (timerActive)
        {
            CountdownTimer(); // Run the countdown timer if active
        }
    }

    /// <summary>
    /// CountdownTimer decreases the countdown value and updates the UI.
    /// </summary>
    private void CountdownTimer()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime; // Decrease countdown based on time elapsed
            countdownText.text = Mathf.Ceil(countdown).ToString(); // Update the countdown text in the UI
        }
        else
        {
            EndGame(); // End the game when countdown reaches zero
        }
    }

    /// <summary>
    /// EndGame stops the timer, disables interactions, and displays feedback.
    /// </summary>
    private void EndGame()
    {
        timerActive = false; // Stop the countdown
        countdownText.text = "0"; // Set the countdown text to 0
        DisableAllInteractions(); // Disable further interactions with task cards
        ShowFeedbackPanel(); // Display the feedback panel with the final score
    }

    /// <summary>
    /// Disables interactions with the task cards by blocking raycasts.
    /// </summary>
    private void DisableAllInteractions()
    {
        canvasGroup.blocksRaycasts = false; // Disable raycast blocking to prevent further dragging
    }

    /// <summary>
    /// Called when dragging begins. Stores the initial position of the task card.
    /// </summary>
    /// <param name="eventData">Pointer event data</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!timerActive) return; // Do nothing if the timer has stopped

        initialPosition = rectTransform.anchoredPosition; // Store the initial position of the task card
        initialParent = rectTransform.parent; // Store the initial parent of the task card

        canvasGroup.blocksRaycasts = false; // Disable raycast blocking while dragging
    }

    /// <summary>
    /// Called during the drag to update the task card's position.
    /// </summary>
    /// <param name="eventData">Pointer event data</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (!timerActive) return; // Do nothing if the timer has stopped

        Vector2 position;
        // Convert screen position to local canvas position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, eventData.position, canvas.worldCamera, out position);
        rectTransform.anchoredPosition = position; // Update task card position
    }

    /// <summary>
    /// Called when dragging ends. Checks if the task card was dropped in a valid panel.
    /// </summary>
    /// <param name="eventData">Pointer event data</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!timerActive) return; // Do nothing if the timer has stopped

        canvasGroup.blocksRaycasts = true; // Re-enable raycast blocking after dragging

        bool matchedThisTime = false; // Track if the task card was matched in this attempt

        // Matching logic for TaskCard1-8 based on their names and target panels

        // Check if the task card was placed in the "Not Urgent + Important" panel
        if (RectTransformUtility.RectangleContainsScreenPoint(notUrgentImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard1" && !isTaskCard1Matched)
            {
                SetPanelColor(notUrgentImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard1Matched = true; // Mark TaskCard1 as correctly placed
            }
            else if (gameObject.name == "TaskCard3" && !isTaskCard3Matched)
            {
                SetPanelColor(notUrgentImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard3Matched = true; // Mark TaskCard3 as correctly placed
            }
            else if (gameObject.name == "TaskCard8" && !isTaskCard8Matched)
            {
                SetPanelColor(notUrgentImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard8Matched = true; // Mark TaskCard8 as correctly placed
            }
            else
            {
                SetPanelColor(notUrgentImportantPanel, false); // Highlight as incorrect
            }
        }
        // Check if the task card was placed in the "Urgent + Important" panel
        else if (RectTransformUtility.RectangleContainsScreenPoint(urgentImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard2" && !isTaskCard2Matched)
            {
                SetPanelColor(urgentImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard2Matched = true; // Mark TaskCard2 as correctly placed
            }
            else if (gameObject.name == "TaskCard6" && !isTaskCard6Matched)
            {
                SetPanelColor(urgentImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard6Matched = true; // Mark TaskCard6 as correctly placed
            }
            else
            {
                SetPanelColor(urgentImportantPanel, false); // Highlight as incorrect
            }
        }

        // Check if the task card was placed in the "Urgent + Not Important" panel
        else if (RectTransformUtility.RectangleContainsScreenPoint(urgentNotImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard5" && !isTaskCard5Matched)
            {
                SetPanelColor(urgentNotImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard5Matched = true; // Mark TaskCard5 as correctly placed
            }
            else if (gameObject.name == "TaskCard7" && !isTaskCard7Matched)
            {
                SetPanelColor(urgentNotImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard7Matched = true; // Mark TaskCard7 as correctly placed
            }
            else
            {
                SetPanelColor(urgentNotImportantPanel, false); // Highlight as incorrect
            }
        }

        // Check if the task card was placed in the "Not Urgent + Not Important" panel
        else if (RectTransformUtility.RectangleContainsScreenPoint(notUrgentNotImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard4" && !isTaskCard4Matched)
            {
                SetPanelColor(notUrgentNotImportantPanel, true); // Highlight correct panel
                matchedThisTime = true;
                isTaskCard4Matched = true; // Mark TaskCard4 as correctly placed
            }
            else
            {
                SetPanelColor(notUrgentNotImportantPanel, false); // Highlight as incorrect
            }
        }

        // If matched this time, update the score and visual feedback
        if (matchedThisTime)
        {
            if (!isTaskCardCorrectlyPlaced) 
            {
                score += 5; // Increment score by 5 points for correct placement
                isTaskCardCorrectlyPlaced = true;
                UpdateScoreText(); // Update the score display
                SetTaskCardColor(Color.grey); // Visually change the task card color
            }
        }
        else
        {
            isTaskCardCorrectlyPlaced = false; // Reset the flag if not matched correctly
        }

        // Return the task card to its initial position after dragging
        rectTransform.anchoredPosition = initialPosition;

        // Check if all task cards have been matched
        if (AllTaskCardsMatched())
        {
            EndGame(); // Trigger the end game if all task cards are correctly placed
        }
    }

    /// <summary>
    /// Sets the color of the matching panel to green if correct, otherwise default.
    /// </summary>
    /// <param name="panel">Panel where the task card is placed</param>
    /// <param name="isCorrect">Is the card placed in the correct panel?</param>
    private void SetPanelColor(GameObject panel, bool isCorrect)
    {
        if (isCorrect)
        {
            panel.GetComponent<UnityEngine.UI.Image>().color = Color.green; // Highlight panel as correct
        }
    }

    /// <summary>
    /// Changes the task card's color to grey after it has been correctly placed.
    /// </summary>
    /// <param name="color">The color to set for the task card</param>
    private void SetTaskCardColor(Color color)
    {
        GetComponent<UnityEngine.UI.Image>().color = color; // Change the task card color
    }

    /// <summary>
    /// Updates the score display in the game UI.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = $"{score}/40"; // Display the current score out of 40
    }

    /// <summary>
    /// Checks if all task cards have been correctly placed in their respective panels.
    /// </summary>
    /// <returns>True if all task cards are correctly placed, false otherwise</returns>
    private bool AllTaskCardsMatched()
    {
        return isTaskCard1Matched && isTaskCard2Matched && isTaskCard3Matched &&
               isTaskCard4Matched && isTaskCard5Matched && isTaskCard6Matched &&
               isTaskCard7Matched && isTaskCard8Matched; // Returns true if all cards are matched
    }

    /// <summary>
    /// Shows the feedback panel once the game ends and all task cards are placed.
    /// </summary>
    private void ShowFeedbackPanel()
    {
        feedbackPanel.SetActive(true); // Display the feedback panel
        weldoneText.text = "Weldone!"; // Set the feedback message
        scoreDisplayText.text = $"Score: {score}"; // Display the final score
    }

    /// <summary>
    /// Resets the game progress by setting all task matching flags and the score to zero.
    /// </summary>
    public static void ResetGameProgress()
    {
        score = 0; // Reset the score
        isTaskCard1Matched = false;
        isTaskCard2Matched = false;
        isTaskCard3Matched = false;
        isTaskCard4Matched = false;
        isTaskCard5Matched = false;
        isTaskCard6Matched = false;
        isTaskCard7Matched = false;
        isTaskCard8Matched = false; // Reset all task card matching flags
    }
}

