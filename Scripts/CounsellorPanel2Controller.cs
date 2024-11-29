using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controls the interactions and feedback for each counselor in Scene 2.
/// Manages the display of dialogue, counselor responses, and feedback for user decisions.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class CounselorPanel2Controller : MonoBehaviour
{
    // Andrew's UI elements and feedback components
    [SerializeField] private GameObject AndrewTalking;
    [SerializeField] private GameObject AndrewAccept;
    [SerializeField] private Button AndrewButton;
    [SerializeField] private GameObject AndrewFeedback;
    [SerializeField] private TMP_Text AndrewTotalScore; // Displays Andrew's score

    // Zara's UI elements and feedback components
    [SerializeField] private GameObject ZaraTalking;
    [SerializeField] private GameObject ZaraAccept;
    [SerializeField] private Button ZaraButton;
    [SerializeField] private GameObject ZaraFeedback;
    [SerializeField] private TMP_Text ZaraTotalScore; // Displays Zara's score

    // Smith's UI elements and feedback components
    [SerializeField] private GameObject SmithTalking;
    [SerializeField] private GameObject SmithAccept;
    [SerializeField] private Button SmithButton;
    [SerializeField] private GameObject SmithFeedback;
    [SerializeField] private TMP_Text SmithTotalScore; // Displays Smith's score

    // Stacy's UI elements and feedback components
    [SerializeField] private GameObject StacyTalking;
    [SerializeField] private GameObject StacyAccept;
    [SerializeField] private Button StacyButton;
    [SerializeField] private GameObject StacyFeedback;
    [SerializeField] private TMP_Text StacyTotalScore; // Displays Stacy's score

    // General UI elements and tracking
    [SerializeField] private GameObject counselorPanel; // Holds all counselor buttons and components
    [SerializeField] private GameObject textContainer; // Additional elements to hide or show as needed

    // Keeps track of currently active feedback panel
    private GameObject activeFeedback;

    // Static properties to store total score and scene-specific score
    public static int Score { get; private set; }  // Combined score from scene and drag-and-drop tasks
    public static int SceneScore { get; private set; }  // Specific score for this scene (used in feedback)

    /// <summary>
    /// Initializes the counselor panel and sets up button listeners.
    /// </summary>
    private void Start()
    {
        // Initially hide the feedback and talking components for all counselors
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

        // Assign button listeners for counselor interaction
        AndrewButton.onClick.AddListener(OnAndrewButtonClick);
        ZaraButton.onClick.AddListener(OnZaraButtonClick);
        SmithButton.onClick.AddListener(OnSmithButtonClick);
        StacyButton.onClick.AddListener(OnStacyButtonClick);

        // Assign feedback to acceptance buttons, each with its respective score
        AndrewAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(AndrewFeedback, AndrewTotalScore, 60)); // Andrew's full score
        ZaraAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(ZaraFeedback, ZaraTotalScore, 30));
        SmithAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(SmithFeedback, SmithTotalScore, 30));
        StacyAccept.GetComponent<Button>().onClick.AddListener(() => ShowFeedback(StacyFeedback, StacyTotalScore, 0));  // Stacy's score is 0
    }

    /// <summary>
    /// Displays Andrew's dialogue and accept button.
    /// </summary>
    private void OnAndrewButtonClick()
    {
        HideActiveComponents();
        AndrewTalking.SetActive(true);
        AndrewAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Zara's dialogue and accept button.
    /// </summary>
    private void OnZaraButtonClick()
    {
        HideActiveComponents();
        ZaraTalking.SetActive(true);
        ZaraAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Smith's dialogue and accept button.
    /// </summary>
    private void OnSmithButtonClick()
    {
        HideActiveComponents();
        SmithTalking.SetActive(true);
        SmithAccept.SetActive(true);
    }

    /// <summary>
    /// Displays Stacy's dialogue and accept button.
    /// </summary>
    private void OnStacyButtonClick()
    {
        HideActiveComponents();
        StacyTalking.SetActive(true);
        StacyAccept.SetActive(true);
    }

    /// <summary>
    /// Hides any currently active dialogue or feedback components to ensure only one is shown at a time.
    /// </summary>
    private void HideActiveComponents()
    {
        if (activeFeedback != null)
        {
            activeFeedback.SetActive(false);
        }

        // Hide all talking and accepting components
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
    /// Shows feedback for the selected counselor and calculates total score.
    /// </summary>
    /// <param name="feedbackPanel">The feedback panel to show</param>
    /// <param name="ScoreText">The TextMeshPro component to display the score</param>
    /// <param name="sceneScore">The score specific to this scene</param>
    private void ShowFeedback(GameObject feedbackPanel, TMP_Text ScoreText, int sceneScore)
    {
        // Hide the counselor panel and text container while feedback is shown
        counselorPanel.SetActive(false);
        textContainer.SetActive(false);

        // Set the scene-specific score for this session
        SceneScore = sceneScore;

        // Calculate total score as scene score plus the score from the drag-and-drop task
        Score = sceneScore + DragAndDropManagers2.Score;
        ScoreText.text = $"{Score}/100";  // Update score display in UI

        // Show the feedback panel for the selected counselor
        feedbackPanel.SetActive(true);
        activeFeedback = feedbackPanel;
    }

    /// <summary>
    /// Resets the score values, useful for restarting or resetting the game.
    /// </summary>
    public static void ResetScores()
    {
        Score = 0;
        SceneScore = 0;
    }
}
