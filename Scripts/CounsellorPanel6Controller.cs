using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the counselor panel for Scene 6, where players interact with advisors.
/// Handles showing dialogue, feedback, and score calculation based on player decisions.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class CounselorPanel6Controller : MonoBehaviour
{
    // Andrew button and associated components
    [SerializeField] private GameObject AndrewTalking;
    [SerializeField] private GameObject AndrewAccept;
    [SerializeField] private Button AndrewButton;
    [SerializeField] private GameObject AndrewFeedback;
    [SerializeField] private TMP_Text AndrewTotalScore;

    // Zara button and associated components
    [SerializeField] private GameObject ZaraTalking;
    [SerializeField] private GameObject ZaraAccept;
    [SerializeField] private Button ZaraButton;
    [SerializeField] private GameObject ZaraFeedback;
    [SerializeField] private TMP_Text ZaraTotalScore;

    // Smith button and associated components
    [SerializeField] private GameObject SmithTalking;
    [SerializeField] private GameObject SmithAccept;
    [SerializeField] private Button SmithButton;
    [SerializeField] private GameObject SmithFeedback;
    [SerializeField] private TMP_Text SmithTotalScore;

    // Stacy button and associated components
    [SerializeField] private GameObject StacyTalking;
    [SerializeField] private GameObject StacyAccept;
    [SerializeField] private Button StacyButton;
    [SerializeField] private GameObject StacyFeedback;
    [SerializeField] private TMP_Text StacyTotalScore;

    // Panel containing all counselor buttons
    [SerializeField] private GameObject counselorPanel;

    // GameObject to hide non-relevant components when feedback is shown
    [SerializeField] private GameObject textContainer;

    // Track the currently active feedback panel
    private GameObject activeFeedback;

    // Static property to store the overall score
    public static int Score { get; private set; }

    private void Start()
    {
        // Hide all talking, accept buttons, and feedback for each counselor at the beginning
        HideAllCounselors();

        // Add listeners for each button click
        AndrewButton.onClick.AddListener(OnAndrewButtonClick);
        ZaraButton.onClick.AddListener(OnZaraButtonClick);
        SmithButton.onClick.AddListener(OnSmithButtonClick);
        StacyButton.onClick.AddListener(OnStacyButtonClick);

        // Add listeners for each accept button click to show feedback
        AndrewAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(AndrewFeedback, AndrewTotalScore, 50, 0));
        ZaraAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(ZaraFeedback, ZaraTotalScore, 0, 50));
        SmithAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(SmithFeedback, SmithTotalScore, 0, 0));
        StacyAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(StacyFeedback, StacyTotalScore, 50, 50)); // Stacy is correct here
    }

    /// <summary>
    /// Hides all active counselor components (talking and accept buttons).
    /// </summary>
    private void HideAllCounselors()
    {
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
    }

    /// <summary>
    /// Handles Andrew button click, shows relevant UI components.
    /// </summary>
    private void OnAndrewButtonClick()
    {
        HideActiveComponents();
        AndrewTalking.SetActive(true);
        AndrewAccept.SetActive(true);
    }

    /// <summary>
    /// Handles Zara button click, shows relevant UI components.
    /// </summary>
    private void OnZaraButtonClick()
    {
        HideActiveComponents();
        ZaraTalking.SetActive(true);
        ZaraAccept.SetActive(true);
    }

    /// <summary>
    /// Handles Smith button click, shows relevant UI components.
    /// </summary>
    private void OnSmithButtonClick()
    {
        HideActiveComponents();
        SmithTalking.SetActive(true);
        SmithAccept.SetActive(true);
    }

    /// <summary>
    /// Handles Stacy button click, shows relevant UI components.
    /// </summary>
    private void OnStacyButtonClick()
    {
        HideActiveComponents();
        StacyTalking.SetActive(true);
        StacyAccept.SetActive(true);
    }

    /// <summary>
    /// Hides any active feedback or counselor buttons and text panels.
    /// </summary>
    private void HideActiveComponents()
    {
        if (activeFeedback != null)
        {
            activeFeedback.SetActive(false);
        }

        HideAllCounselors();
    }

    /// <summary>
    /// Shows feedback panel with the calculated score based on the decision.
    /// </summary>
    /// <param name="feedbackPanel">The feedback panel to show.</param>
    /// <param name="totalScoreText">Text component to display the score.</param>
    /// <param name="sustainabilityScore">Score for sustainability.</param>
    /// <param name="satisfactionScore">Score for satisfaction.</param>
    private void ShowFeedback(GameObject feedbackPanel, TMP_Text totalScoreText, int sustainabilityScore, int satisfactionScore)
    {
        // Hide counselor panel and text container
        counselorPanel.SetActive(false);
        textContainer.SetActive(false);

        // Calculate and display total score
        Score = sustainabilityScore + satisfactionScore;
        totalScoreText.text = $"{Score}/100"; // Update UI

        // Show the feedback panel
        feedbackPanel.SetActive(true);
        activeFeedback = feedbackPanel;
    }

    /// <summary>
    /// Resets the score to 0 if needed.
    /// </summary>
    public static void ResetScore()
    {
        Score = 0;
    }
}
