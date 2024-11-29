using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages counselor interactions in Scene 5.
/// Handles the display of advice, user selection, and feedback for each counselor.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class CounselorPanel5Controller : MonoBehaviour
{
    // Andrew button and related objects
    [SerializeField] private GameObject AndrewTalking; // Dialog box when Andrew is talking
    [SerializeField] private GameObject AndrewAccept; // Accept button for Andrew's advice
    [SerializeField] private Button AndrewButton; // Button to display Andrew's advice
    [SerializeField] private GameObject AndrewFeedback; // Feedback panel for Andrew
    [SerializeField] private TMP_Text AndrewTotalScore; // Score display for Andrew

    // Zara button and related objects
    [SerializeField] private GameObject ZaraTalking; 
    [SerializeField] private GameObject ZaraAccept;
    [SerializeField] private Button ZaraButton;
    [SerializeField] private GameObject ZaraFeedback; 
    [SerializeField] private TMP_Text ZaraTotalScore;

    // Smith button and related objects
    [SerializeField] private GameObject SmithTalking;
    [SerializeField] private GameObject SmithAccept;
    [SerializeField] private Button SmithButton;
    [SerializeField] private GameObject SmithFeedback;
    [SerializeField] private TMP_Text SmithTotalScore;

    // Stacy button and related objects
    [SerializeField] private GameObject StacyTalking;
    [SerializeField] private GameObject StacyAccept;
    [SerializeField] private Button StacyButton;
    [SerializeField] private GameObject StacyFeedback;
    [SerializeField] private TMP_Text StacyTotalScore;

    // Main panel for all counselor buttons
    [SerializeField] private GameObject counselorPanel;

    // Text container for displaying dialog
    [SerializeField] private GameObject textContainer;

    // Currently active feedback panel
    private GameObject activeFeedback;

    // Static property to store and track total score
    public static int Score { get; private set; }

    /// <summary>
    /// Initializes the panel by hiding all feedback and dialog panels, and sets button listeners.
    /// </summary>
    private void Start()
    {
        // Hide all talking and feedback panels initially
        AndrewTalking.SetActive(false);
        AndrewAccept.SetActive(false);
        AndrewFeedback.SetActive(false);
        ZaraTalking.SetActive(false);
        ZaraAccept.SetActive(false);
        ZaraFeedback.SetActive(false);
        SmithTalking.SetActive(false);
        SmithAccept.SetActive(false);
        SmithFeedback.SetActive(false);
        StacyTalking.SetActive(false);
        StacyAccept.SetActive(false);
        StacyFeedback.SetActive(false);

        // Set up button listeners for counselors
        AndrewButton.onClick.AddListener(OnAndrewButtonClick);
        ZaraButton.onClick.AddListener(OnZaraButtonClick);
        SmithButton.onClick.AddListener(OnSmithButtonClick);
        StacyButton.onClick.AddListener(OnStacyButtonClick);

        // Set up accept button listeners for feedback
        AndrewAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(AndrewFeedback, AndrewTotalScore, 50, 0));
        ZaraAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(ZaraFeedback, ZaraTotalScore, 0, 50)); // Correct answer
        SmithAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(SmithFeedback, SmithTotalScore, 0, 0));
        StacyAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(StacyFeedback, StacyTotalScore, 50, 50)); // Incorrect but impactful decision
    }

    /// <summary>
    /// Displays Andrew's advice and accept button.
    /// </summary>
    private void OnAndrewButtonClick()
    {
        HideActiveComponents();
        AndrewTalking.SetActive(true);
        AndrewAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Zara's advice and accept button.
    /// </summary>
    private void OnZaraButtonClick()
    {
        HideActiveComponents();
        ZaraTalking.SetActive(true);
        ZaraAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Smith's advice and accept button.
    /// </summary>
    private void OnSmithButtonClick()
    {
        HideActiveComponents();
        SmithTalking.SetActive(true);
        SmithAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Stacy's advice and accept button.
    /// </summary>
    private void OnStacyButtonClick()
    {
        HideActiveComponents();
        StacyTalking.SetActive(true);
        StacyAccept.SetActive(true);
    }

    /// <summary>
    /// Hides all active components when switching between counselors.
    /// </summary>
    private void HideActiveComponents()
    {
        if (activeFeedback != null)
        {
            activeFeedback.SetActive(false); // Hide active feedback panel
        }

        // Hide all talking and accept panels for every counselor
        AndrewTalking.SetActive(false);
        AndrewAccept.SetActive(false);
        ZaraTalking.SetActive(false);
        ZaraAccept.SetActive(false);
        SmithTalking.SetActive(false);
        SmithAccept.SetActive(false);
        StacyTalking.SetActive(false);
        StacyAccept.SetActive(false);
    }

    /// <summary>
    /// Displays the feedback panel and updates the score based on the counselor's decision.
    /// </summary>
    /// <param name="feedbackPanel">The feedback panel to show.</param>
    /// <param name="totalScoreText">The text component to display the total score.</param>
    /// <param name="sustainabilityScore">Sustainability score awarded by the counselor.</param>
    /// <param name="satisfactionScore">Satisfaction score awarded by the counselor.</param>
    private void ShowFeedback(GameObject feedbackPanel, TMP_Text totalScoreText, int sustainabilityScore, int satisfactionScore)
    {
        // Hide the entire counselor panel and text container
        counselorPanel.SetActive(false);
        textContainer.SetActive(false);

        // Calculate total score and display it
        Score = sustainabilityScore + satisfactionScore;
        totalScoreText.text = $"{Score}/100";

        // Show the feedback panel for the selected counselor
        feedbackPanel.SetActive(true);
        activeFeedback = feedbackPanel; // Keep track of the currently active feedback panel
    }

    /// <summary>
    /// Resets the score, useful for restarting the game or resetting decisions.
    /// </summary>
    public static void ResetScore()
    {
        Score = 0; // Reset score
    }
}
