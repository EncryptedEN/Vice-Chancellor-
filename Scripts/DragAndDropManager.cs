using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/// <summary>
/// Manages the drag and drop functionality of task cards and tracks the game score.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class DragAndDropManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform canvasTransform; // Reference to the canvas
    [SerializeField] private GameObject urgentImportantPanel; // Panel for urgent and important tasks
    [SerializeField] private GameObject notUrgentNotImportantPanel; // Panel for not urgent and not important tasks
    [SerializeField] private GameObject notUrgentImportantPanel; // Panel for not urgent but important tasks
    [SerializeField] private GameObject urgentNotImportantPanel; // Panel for urgent but not important tasks
    [SerializeField] private TMP_Text scoreText; // Text displaying the score
    [SerializeField] private TMP_Text countdownText; // Text displaying the countdown timer
    [SerializeField] private GameObject feedbackPanel; // Panel shown when the game ends
    [SerializeField] private TMP_Text weldoneText; // Text displaying the "Weldone" message
    [SerializeField] private TMP_Text scoreDisplayText; // Text displaying the final score

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector3 initialPosition; // Stores the initial position of the task card
    private Transform initialParent; // Stores the initial parent of the task card
    private static int score = 0; // Tracks the player's score

    // Flags to track whether each task card is correctly matched
    private static bool isTaskCard1Matched = false;
    private static bool isTaskCard2Matched = false;
    private static bool isTaskCard3Matched = false;
    private static bool isTaskCard4Matched = false;
    private static bool isTaskCard5Matched = false;
    private static bool isTaskCard6Matched = false;
    private static bool isTaskCard7Matched = false;
    private static bool isTaskCard8Matched = false;

    private bool isTaskCardCorrectlyPlaced = false; // Flag to check if task card is placed correctly
    private float countdown = 120f; // Countdown timer (in seconds)
    private bool timerActive = true; // Flag to check if the timer is active

    /// <summary>
    /// Gets the current score.
    /// </summary>
    public static int Score
    {
        get { return score; }
    }

    /// <summary>
    /// Initializes references and hides the feedback panel.
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = canvasTransform.GetComponent<Canvas>();
        UpdateScoreText();
        feedbackPanel.SetActive(false); // Ensure feedback panel is hidden at the start
    }

    /// <summary>
    /// Updates the countdown timer if it is active.
    /// </summary>
    private void Update()
    {
        if (timerActive)
        {
            CountdownTimer();
        }
    }

    /// <summary>
    /// Handles the countdown timer and checks when time runs out.
    /// </summary>
    private void CountdownTimer()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime; // Decreases the timer
            countdownText.text = Mathf.Ceil(countdown).ToString(); // Updates countdown text
        }
        else
        {
            EndGame(); // End game when time runs out
        }
    }

    /// <summary>
    /// Ends the game by stopping interactions and showing the feedback panel.
    /// </summary>
    private void EndGame()
    {
        timerActive = false; // Stops the timer
        countdownText.text = "0"; // Sets the countdown to 0
        DisableAllInteractions();
        ShowFeedbackPanel();
    }

    /// <summary>
    /// Disables interactions such as dragging after the game ends.
    /// </summary>
    private void DisableAllInteractions()
    {
        canvasGroup.blocksRaycasts = false; // Disables dragging
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!timerActive) return; // Do nothing if the timer is not active

        initialPosition = rectTransform.anchoredPosition; // Store the initial position
        initialParent = rectTransform.parent; // Store the initial parent

        canvasGroup.blocksRaycasts = false; // Allow the task card to be dragged
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!timerActive) return; // Do nothing if the timer is not active

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, eventData.position, canvas.worldCamera, out position);
        rectTransform.anchoredPosition = position; // Update task card's position based on drag
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!timerActive) return; // Do nothing if the timer is not active

        canvasGroup.blocksRaycasts = true; // Enable raycasts to detect drop
        bool matchedThisTime = false; // Check if task card was matched this time

        // Matching logic for TaskCard1-8 based on the panel it is dropped on
        if (RectTransformUtility.RectangleContainsScreenPoint(urgentImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard1" && !isTaskCard1Matched)
            {
                SetPanelColor(urgentImportantPanel, true); // Update panel color to indicate a match
                matchedThisTime = true;
                isTaskCard1Matched = true; // Mark TaskCard1 as matched
            }
            else if (gameObject.name == "TaskCard5" && !isTaskCard5Matched)
            {
                SetPanelColor(urgentImportantPanel, true); 
                matchedThisTime = true;
                isTaskCard5Matched = true;
            }
            else
            {
                SetPanelColor(urgentImportantPanel, false); // Update panel color to indicate no match
            }
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(urgentNotImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard2" && !isTaskCard2Matched)
            {
                SetPanelColor(urgentNotImportantPanel, true);
                matchedThisTime = true;
                isTaskCard2Matched = true;
            }
            else if (gameObject.name == "TaskCard6" && !isTaskCard6Matched)
            {
                SetPanelColor(urgentNotImportantPanel, true);
                matchedThisTime = true;
                isTaskCard6Matched = true;
            }
            else
            {
                SetPanelColor(urgentNotImportantPanel, false);
            }
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(notUrgentImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard3" && !isTaskCard3Matched)
            {
                SetPanelColor(notUrgentImportantPanel, true);
                matchedThisTime = true;
                isTaskCard3Matched = true;
            }
            else if (gameObject.name == "TaskCard7" && !isTaskCard7Matched)
            {
                SetPanelColor(notUrgentImportantPanel, true);
                matchedThisTime = true;
                isTaskCard7Matched = true;
            }
            else
            {
                SetPanelColor(notUrgentImportantPanel, false);
            }
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(notUrgentNotImportantPanel.GetComponent<RectTransform>(), Input.mousePosition))
        {
            if (gameObject.name == "TaskCard4" && !isTaskCard4Matched)
            {
                SetPanelColor(notUrgentNotImportantPanel, true);
                matchedThisTime = true;
                isTaskCard4Matched = true;
            }
            else if (gameObject.name == "TaskCard8" && !isTaskCard8Matched)
            {
                SetPanelColor(notUrgentNotImportantPanel, true);
                matchedThisTime = true;
                isTaskCard8Matched = true;
            }
            else
            {
                SetPanelColor(notUrgentNotImportantPanel, false);
            }
        }

        // If the card was matched correctly, increase the score
        if (matchedThisTime)
        {
            if (!isTaskCardCorrectlyPlaced)
            {
                score += 5; // Increase score by 5
                isTaskCardCorrectlyPlaced = true; // Mark the card as placed correctly
                UpdateScoreText(); // Update score display
                SetTaskCardColor(Color.grey); // Change the task card color to grey
            }
        }
        else
        {
            isTaskCardCorrectlyPlaced = false; // Reset flag if not placed correctly
        }

        // Return the task card to its original position if not matched
        rectTransform.anchoredPosition = initialPosition;

        // If all task cards are matched, end the game
        if (AllTaskCardsMatched())
        {
            EndGame();
        }
    }

    /// <summary>
    /// Changes the panel color based on correct or incorrect placement.
    /// </summary>
    private void SetPanelColor(GameObject panel, bool isCorrect)
    {
        panel.GetComponent<UnityEngine.UI.Image>().color = isCorrect ? Color.green : Color.red;
    }

    /// <summary>
    /// Changes the task card color after it's placed correctly.
    /// </summary>
    private void SetTaskCardColor(Color color)
    {
        GetComponent<UnityEngine.UI.Image>().color = color;
    }

    /// <summary>
    /// Updates the score text on the UI.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = $"{score}/40"; // Updates the score display
    }

    /// <summary>
    /// Checks if all task cards have been matched correctly.
    /// </summary>
    private bool AllTaskCardsMatched()
    {
        // Returns true if all task cards are matched correctly
        return isTaskCard1Matched && isTaskCard2Matched && isTaskCard3Matched &&
               isTaskCard4Matched && isTaskCard5Matched && isTaskCard6Matched &&
               isTaskCard7Matched && isTaskCard8Matched;
    }

    /// <summary>
    /// Shows the feedback panel and displays the final score.
    /// </summary>
    private void ShowFeedbackPanel()
    {
        feedbackPanel.SetActive(true); // Show feedback panel
        weldoneText.text = "Weldone!"; // Show the weldone message
        scoreDisplayText.text = $"Score: {score}"; // Display the final score
    }

    /// <summary>
    /// Resets the game progress, including the score and task card matches.
    /// </summary>
    public static void ResetGameProgress()
    {
        score = 0;
        isTaskCard1Matched = false;
        isTaskCard2Matched = false;
        isTaskCard3Matched = false;
        isTaskCard4Matched = false;
        isTaskCard5Matched = false;
        isTaskCard6Matched = false;
        isTaskCard7Matched = false;
        isTaskCard8Matched = false;
    }
}

