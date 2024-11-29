using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls the interaction between the user and the counselor panel in Scene 4.
/// Handles button clicks, feedback display, and score calculation based on decisions made by the player.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class CounselorPanel4Controller : MonoBehaviour
{
    // Andrew's button and related objects
    [SerializeField] private GameObject AndrewTalking;  // Panel for Andrew's dialogue
    [SerializeField] private GameObject AndrewAccept;   // Button to accept Andrew's advice
    [SerializeField] private Button AndrewButton;       // Button to display Andrew's panel
    [SerializeField] private GameObject AndrewFeedback; // Panel for Andrew's feedback
    [SerializeField] private TMP_Text AndrewTotalScore; // TextMeshPro for Andrew's score

    // Zara's button and related objects
    [SerializeField] private GameObject ZaraTalking;
    [SerializeField] private GameObject ZaraAccept;
    [SerializeField] private Button ZaraButton;
    [SerializeField] private GameObject ZaraFeedback;
    [SerializeField] private TMP_Text ZaraTotalScore;

    // Smith's button and related objects
    [SerializeField] private GameObject SmithTalking;
    [SerializeField] private GameObject SmithAccept;
    [SerializeField] private Button SmithButton;
    [SerializeField] private GameObject SmithFeedback;
    [SerializeField] private TMP_Text SmithTotalScore;

    // Stacy's button and related objects
    [SerializeField] private GameObject StacyTalking;
    [SerializeField] private GameObject StacyAccept;
    [SerializeField] private Button StacyButton;
    [SerializeField] private GameObject StacyFeedback;
    [SerializeField] private TMP_Text StacyTotalScore;

    // Panel and containers for the scene
    [SerializeField] private GameObject counselorPanel;  // Panel containing all buttons
    [SerializeField] private GameObject textContainer;   // Container for other text elements

    // Holds the active feedback panel
    private GameObject activeFeedback;

    // Stores the total score for the scene
    public static int Score { get; private set; }  // Static property to track total score

    /// <summary>
    /// Initializes the scene by hiding all child objects and setting up button listeners.
    /// </summary>
    private void Start()
    {
        // Hide all panels and feedback initially
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

        // Add click listeners for counselor buttons
        AndrewButton.onClick.AddListener(OnAndrewButtonClick);
        ZaraButton.onClick.AddListener(OnZaraButtonClick);
        SmithButton.onClick.AddListener(OnSmithButtonClick);
        StacyButton.onClick.AddListener(OnStacyButtonClick);

        // Add click listeners for accept buttons, each with its own feedback and score
        AndrewAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(AndrewFeedback, AndrewTotalScore, 50, 0));  // Andrew: 50 sustainability, 0 satisfaction
        ZaraAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(ZaraFeedback, ZaraTotalScore, 0, 50));    // Zara: 0 sustainability, 50 satisfaction
        SmithAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(SmithFeedback, SmithTotalScore, 0, 50));  // Smith: 0 sustainability, 50 satisfaction
        StacyAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(StacyFeedback, StacyTotalScore, 50, 50)); // Stacy: 50 sustainability, 50 satisfaction
    }

    /// <summary>
    /// Handles the event when the Andrew button is clicked.
    /// </summary>
    private void OnAndrewButtonClick()
    {
        HideActiveComponents();
        AndrewTalking.SetActive(true);
        AndrewAccept.SetActive(true);
    }

    /// <summary>
    /// Handles the event when the Zara button is clicked.
    /// </summary>
    private void OnZaraButtonClick()
    {
        HideActiveComponents();
        ZaraTalking.SetActive(true);
        ZaraAccept.SetActive(true);
    }

    /// <summary>
    /// Handles the event when the Smith button is clicked.
    /// </summary>
    private void OnSmithButtonClick()
    {
        HideActiveComponents();
        SmithTalking.SetActive(true);
        SmithAccept.SetActive(true);
    }

    /// <summary>
    /// Handles the event when the Stacy button is clicked.
    /// </summary>
    private void OnStacyButtonClick()
    {
        HideActiveComponents();
        StacyTalking.SetActive(true);
        StacyAccept.SetActive(true);
    }

    /// <summary>
    /// Hides all currently active panels and resets feedback visibility.
    /// </summary>
    private void HideActiveComponents()
    {
        if (activeFeedback != null)
        {
            activeFeedback.SetActive(false);
        }

        // Hide all talking and accept panels
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
    /// Displays the feedback for the selected counselor and calculates the score.
    /// </summary>
    /// <param name="feedbackPanel">The panel to display the feedback.</param>
    /// <param name="totalScoreText">The TextMeshPro component for displaying the total score.</param>
    /// <param name="sustainabilityScore">The sustainability score awarded by the counselor.</param>
    /// <param name="satisfactionScore">The satisfaction score awarded by the counselor.</param>
    private void ShowFeedback(GameObject feedbackPanel, TMP_Text totalScoreText, int sustainabilityScore, int satisfactionScore)
    {
        // Hide the counselor panel and text container
        counselorPanel.SetActive(false);
        textContainer.SetActive(false);

        // Calculate and set the total score
        int totalScore = sustainabilityScore + satisfactionScore;
        Score = totalScore;

        // Update the score display in the feedback panel
        totalScoreText.text = $"{totalScore}/100";

        // Show the selected feedback panel
        feedbackPanel.SetActive(true);
        activeFeedback = feedbackPanel;
    }

    // Static method to reset the score if needed
    public static void ResetScore()
    {
        Score = 0;
    }
}
