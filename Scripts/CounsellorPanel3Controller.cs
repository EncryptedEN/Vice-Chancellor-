using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the interaction and feedback for each counselor in Scene 3.
/// This includes hiding/showing feedback panels, tracking total scores, and handling button clicks.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class CounselorPanel3Controller : MonoBehaviour
{
    // Andrew button and related objects
    [SerializeField] private GameObject AndrewTalking; // Andrew's talking panel
    [SerializeField] private GameObject AndrewAccept; // Andrew's accept button
    [SerializeField] private Button AndrewButton; // Andrew's main button
    [SerializeField] private GameObject AndrewFeedback; // Andrew's feedback panel
    [SerializeField] private TMP_Text AndrewTotalScore; // Andrew's total score text display

    // Zara button and related objects
    [SerializeField] private GameObject ZaraTalking; // Zara's talking panel
    [SerializeField] private GameObject ZaraAccept; // Zara's accept button
    [SerializeField] private Button ZaraButton; // Zara's main button
    [SerializeField] private GameObject ZaraFeedback; // Zara's feedback panel
    [SerializeField] private TMP_Text ZaraTotalScore; // Zara's total score text display

    // Smith button and related objects
    [SerializeField] private GameObject SmithTalking; // Smith's talking panel
    [SerializeField] private GameObject SmithAccept; // Smith's accept button
    [SerializeField] private Button SmithButton; // Smith's main button
    [SerializeField] private GameObject SmithFeedback; // Smith's feedback panel
    [SerializeField] private TMP_Text SmithTotalScore; // Smith's total score text display

    // Stacy button and related objects
    [SerializeField] private GameObject StacyTalking; // Stacy's talking panel
    [SerializeField] private GameObject StacyAccept; // Stacy's accept button
    [SerializeField] private Button StacyButton; // Stacy's main button
    [SerializeField] private GameObject StacyFeedback; // Stacy's feedback panel
    [SerializeField] private TMP_Text StacyTotalScore; // Stacy's total score text display

    // Counselor Panel and text container objects
    [SerializeField] private GameObject counselorPanel; // Panel containing all counselor buttons
    [SerializeField] private GameObject textContainer; // Container for hiding other elements

    // Track the currently active feedback panel
    private GameObject activeFeedback;

    // Static property to hold the score for Scene 3
    public static int Score { get; private set; } // Accessible static score

    /// <summary>
    /// Initializes the buttons and sets up the feedback mechanism for each counselor.
    /// </summary>
    private void Start()
    {
        // Hide all talking, accept, and feedback panels initially
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

        // Attach button listeners to display respective panels
        AndrewButton.onClick.AddListener(OnAndrewButtonClick);
        ZaraButton.onClick.AddListener(OnZaraButtonClick);
        SmithButton.onClick.AddListener(OnSmithButtonClick);
        StacyButton.onClick.AddListener(OnStacyButtonClick);

        // Attach accept button listeners for feedback display with corresponding scores
        AndrewAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(AndrewFeedback, AndrewTotalScore, 0, 0)); // 50 Sustainability, 0 Satisfaction
        ZaraAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(ZaraFeedback, ZaraTotalScore, 0, 50)); // 0 Sustainability, 50 Satisfaction
        SmithAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(SmithFeedback, SmithTotalScore, 50, 50)); // 50 Sustainability, 50 Satisfaction
        StacyAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(StacyFeedback, StacyTotalScore, 50, 0)); // 50 Sustainability, 0 Satisfaction
    }

    /// <summary>
    /// Displays Andrew's talking panel and accept button.
    /// </summary>
    private void OnAndrewButtonClick()
    {
        HideActiveComponents();
        AndrewTalking.SetActive(true);
        AndrewAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Zara's talking panel and accept button.
    /// </summary>
    private void OnZaraButtonClick()
    {
        HideActiveComponents();
        ZaraTalking.SetActive(true);
        ZaraAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Smith's talking panel and accept button.
    /// </summary>
    private void OnSmithButtonClick()
    {
        HideActiveComponents();
        SmithTalking.SetActive(true);
        SmithAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Stacy's talking panel and accept button.
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
    /// Displays feedback for the selected counselor and calculates the score.
    /// </summary>
    /// <param name="feedbackPanel">The panel to display feedback.</param>
    /// <param name="totalScoreText">Text element to show the total score.</param>
    /// <param name="sustainabilityScore">Score for sustainability (0-50).</param>
    /// <param name="satisfactionScore">Score for stakeholder satisfaction (0-50).</param>
    private void ShowFeedback(GameObject feedbackPanel, TMP_Text totalScoreText, int sustainabilityScore, int satisfactionScore)
    {
        // Hide the counselor panel and text container
        counselorPanel.SetActive(false);
        textContainer.SetActive(false);

        // Calculate total score and display it
        Score = sustainabilityScore + satisfactionScore;
        totalScoreText.text = $"{Score}/100";

        // Show the selected feedback panel
        feedbackPanel.SetActive(true);
        activeFeedback = feedbackPanel;
    }

    /// <summary>
    /// Resets the score to 0 when necessary.
    /// </summary>
    public static void ResetScore()
    {
        Score = 0;
    }
}
