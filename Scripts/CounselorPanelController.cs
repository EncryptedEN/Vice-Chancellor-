using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles the behavior of the counselor panel where players can choose advisors 
/// and receive feedback based on their decisions.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class CounselorPanelController : MonoBehaviour
{
    // Andrew button and related objects
    [SerializeField] private GameObject AndrewTalking; // Andrew's dialogue UI
    [SerializeField] private GameObject AndrewAccept; // Andrew's accept button
    [SerializeField] private Button AndrewButton; // Button to trigger Andrew's response
    [SerializeField] private GameObject AndrewFeedback; // Andrew's feedback panel
    [SerializeField] private TMP_Text AndrewTotalScore; // Andrew's score display

    // Zara button and related objects
    [SerializeField] private GameObject ZaraTalking; // Zara's dialogue UI
    [SerializeField] private GameObject ZaraAccept; // Zara's accept button
    [SerializeField] private Button ZaraButton; // Button to trigger Zara's response
    [SerializeField] private GameObject ZaraFeedback; // Zara's feedback panel
    [SerializeField] private TMP_Text ZaraTotalScore; // Zara's score display

    // Smith button and related objects
    [SerializeField] private GameObject SmithTalking; // Smith's dialogue UI
    [SerializeField] private GameObject SmithAccept; // Smith's accept button
    [SerializeField] private Button SmithButton; // Button to trigger Smith's response
    [SerializeField] private GameObject SmithFeedback; // Smith's feedback panel
    [SerializeField] private TMP_Text SmithTotalScore; // Smith's score display

    // Stacy button and related objects
    [SerializeField] private GameObject StacyTalking; // Stacy's dialogue UI
    [SerializeField] private GameObject StacyAccept; // Stacy's accept button
    [SerializeField] private Button StacyButton; // Button to trigger Stacy's response
    [SerializeField] private GameObject StacyFeedback; // Stacy's feedback panel
    [SerializeField] private TMP_Text StacyTotalScore; // Stacy's score display

    // Panel that contains all counselor buttons
    [SerializeField] private GameObject counselorPanel;

    // Other UI elements
    [SerializeField] private GameObject textContainer; // Main text UI container

    // Track the currently active feedback panel
    private GameObject activeFeedback;

    // Static properties for scores
    public static int Score { get; private set; } // Combined score (Scene + Drag and Drop)
    public static int SceneScore { get; private set; } // Scene-specific score (for final feedback)

    /// <summary>
    /// Initializes the buttons and sets the panel's visibility.
    /// </summary>
    private void Start()
    {
        // Initially hide the talking and feedback sections for each advisor
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

        // Set up button listeners for each advisor
        AndrewButton.onClick.AddListener(OnAndrewButtonClick);
        ZaraButton.onClick.AddListener(OnZaraButtonClick);
        SmithButton.onClick.AddListener(OnSmithButtonClick);
        StacyButton.onClick.AddListener(OnStacyButtonClick);

        // Set up listeners for accepting feedback from each advisor
        AndrewAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(AndrewFeedback, AndrewTotalScore, 0));
        ZaraAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(ZaraFeedback, ZaraTotalScore, 30));
        SmithAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(SmithFeedback, SmithTotalScore, 30));
        StacyAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(StacyFeedback, StacyTotalScore, 60));
    }

    /// <summary>
    /// Displays Andrew's feedback when selected.
    /// </summary>
    private void OnAndrewButtonClick()
    {
        HideActiveComponents();
        AndrewTalking.SetActive(true);
        AndrewAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Zara's feedback when selected.
    /// </summary>
    private void OnZaraButtonClick()
    {
        HideActiveComponents();
        ZaraTalking.SetActive(true);
        ZaraAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Smith's feedback when selected.
    /// </summary>
    private void OnSmithButtonClick()
    {
        HideActiveComponents();
        SmithTalking.SetActive(true);
        SmithAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Stacy's feedback when selected.
    /// </summary>
    private void OnStacyButtonClick()
    {
        HideActiveComponents();
        StacyTalking.SetActive(true);
        StacyAccept.SetActive(true);
    }

    /// <summary>
    /// Hides all active components when switching between feedback panels.
    /// </summary>
    private void HideActiveComponents()
    {
        if (activeFeedback != null)
        {
            activeFeedback.SetActive(false); // Hide active feedback
        }

        // Hide all talking and accept sections
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
    /// Displays feedback for a selected advisor and updates the score.
    /// </summary>
    /// <param name="feedbackPanel">The feedback panel to show.</param>
    /// <param name="ScoreText">The score display text.</param>
    /// <param name="sceneScore">The score for the current scene.</param>
    private void ShowFeedback(GameObject feedbackPanel, TMP_Text ScoreText, int sceneScore)
    {
        // Hide the main panel and text container
        counselorPanel.SetActive(false);
        textContainer.SetActive(false);

        // Set the scene-specific score for feedback calculations
        SceneScore = sceneScore;

        // Combine scene score with Drag and Drop score
        Score = sceneScore + DragAndDropManager.Score;
        ScoreText.text = $"{Score}/100"; // Display the combined score

        // Show the feedback panel
        feedbackPanel.SetActive(true);
        activeFeedback = feedbackPanel;
    }

    /// <summary>
    /// Resets all scores for the scene.
    /// </summary>
    public static void ResetScores()
    {
        Score = 0;
        SceneScore = 0;
    }
}
