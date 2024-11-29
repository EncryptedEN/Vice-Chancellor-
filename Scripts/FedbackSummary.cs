using UnityEngine;
using TMPro;

/// <summary>
/// Displays a summary of the player's performance across Targetted Soft Skills:
/// Time Management, Communication, Teamwork, and Problem Solving.
/// The total score and grade are calculated based on individual scores from different scenes and mini-games.
/// </summary>
/// <author>Emmanuel Nwokoro</author>

public class FeedbackSummary : MonoBehaviour
{
    // TMP references for Feedback UI
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private TMP_Text totalGradeText;
    [SerializeField] private TMP_Text timeManagementScoreText;
    [SerializeField] private TMP_Text communicationScoreText;
    [SerializeField] private TMP_Text teamworkScoreText;
    [SerializeField] private TMP_Text problemScoreText;

    [SerializeField] private TMP_Text timeSummaryText;
    [SerializeField] private TMP_Text communicationSummaryText;
    [SerializeField] private TMP_Text teamSummaryText;
    [SerializeField] private TMP_Text problemSummaryText;

    [SerializeField] private TMP_Text levelRatingText;

    // Max scores for each skill
    private const int MaxTotalScore = 600;
    private const int MaxTimeManagementScore = 80;
    private const int MaxCommunicationScore = 120;  // Scene 1 + Scene 2 = 60 + 60
    private const int MaxTeamworkScore = 200;
    private const int MaxProblemScore = 200;

    private void Start()
    {
        // Calculate total scores and grade
        int totalScore = CalculateTotalScore();
        float totalGrade = ((float)totalScore / MaxTotalScore) * 100;

        // Calculate percentages per skill
        float timeManagementPercentage = ((float)GetTimeManagementScore() / MaxTimeManagementScore) * 100;
        float communicationPercentage = ((float)GetSceneSpecificCommunicationScore() / MaxCommunicationScore) * 100;
        float teamworkPercentage = ((float)GetTeamworkScore() / MaxTeamworkScore) * 100;
        float problemSolvingPercentage = ((float)GetProblemSolvingScore() / MaxProblemScore) * 100;

        // Update the UI with calculated scores and summaries
        totalScoreText.text = $"{totalScore}/600";
        totalGradeText.text = $"{totalGrade:F1}%";
        timeManagementScoreText.text = $"{timeManagementPercentage:F1}%";
        communicationScoreText.text = $"{communicationPercentage:F1}%";
        teamworkScoreText.text = $"{teamworkPercentage:F1}%";
        problemScoreText.text = $"{problemSolvingPercentage:F1}%";

        // Update feedback summaries based on skill percentages
        timeSummaryText.text = GetTimeManagementSummary(timeManagementPercentage);
        communicationSummaryText.text = GetEffectiveCommunicationSummary(communicationPercentage);
        teamSummaryText.text = GetTeamworkSummary(teamworkPercentage);
        problemSummaryText.text = GetProblemSolvingSummary(problemSolvingPercentage);

        // Set player level rating based on the total grade
        levelRatingText.text = GetPlayerLevel(totalGrade);
    }

    /// <summary>
    /// Calculates the total score from all relevant scenes and mini-games.
    /// </summary>
    /// <returns>Total score for the player.</returns>
    private int CalculateTotalScore()
    {
        int score = 0;
        score += DragAndDropManager.Score;      // Recess 1
        score += CounselorPanelController.SceneScore;  // Scene 1
        score += DragAndDropManagers2.Score;    // Recess 2
        score += CounselorPanel2Controller.SceneScore; // Scene 2
        score += CounselorPanel3Controller.Score; // Scene 3
        score += CounselorPanel4Controller.Score; // Scene 4
        score += CounselorPanel5Controller.Score; // Scene 5
        score += CounselorPanel6Controller.Score; // Scene 6
        return score;
    }

    /// <summary>
    /// Retrieves the total time management score from the relevant drag-and-drop mini-games.
    /// </summary>
    private int GetTimeManagementScore()
    {
        return DragAndDropManager.Score + DragAndDropManagers2.Score;
    }

    /// <summary>
    /// Retrieves the effective communication score, specifically from Scene 1 and Scene 2.
    /// </summary>
    private int GetSceneSpecificCommunicationScore()
    {
        return CounselorPanelController.SceneScore + CounselorPanel2Controller.SceneScore;
    }

    /// <summary>
    /// Retrieves the total teamwork score from Scene 3 and Scene 5.
    /// </summary>
    private int GetTeamworkScore()
    {
        return CounselorPanel3Controller.Score + CounselorPanel5Controller.Score;
    }

    /// <summary>
    /// Retrieves the total problem-solving score from Scene 4 and Scene 6.
    /// </summary>
    private int GetProblemSolvingScore()
    {
        return CounselorPanel4Controller.Score + CounselorPanel6Controller.Score;
    }

    // Feedback summaries based on percentage ranges

    /// <summary>
    /// Provides a summary of the player's time management performance based on their percentage score.
    /// </summary>
    private string GetTimeManagementSummary(float percentage)
    {
        if (percentage <= 50)
        {
            return "You’ve struggled with managing your time efficiently, resulting in missed opportunities. Focus on prioritization and setting clear goals.";
        }
        else
        {
            return "You've effectively managed your time and priorities, demonstrating solid organizational skills throughout the tasks.";
        }
    }

    /// <summary>
    /// Provides a summary of the player's communication performance based on their percentage score.
    /// </summary>
    private string GetEffectiveCommunicationSummary(float percentage)
    {
        if (percentage <= 50)
        {
            return "There were some challenges in communicating with key stakeholders. Work on conveying ideas clearly and actively listening to others.";
        }
        else
        {
            return "You've excelled at communicating with stakeholders and making informed decisions, demonstrating excellent listening and speaking skills.";
        }
    }

    /// <summary>
    /// Provides a summary of the player's teamwork performance based on their percentage score.
    /// </summary>
    private string GetTeamworkSummary(float percentage)
    {
        if (percentage <= 50)
        {
            return "You faced difficulties collaborating with your team, leading to a lack of cohesion. Greater openness to others' ideas could strengthen your teamwork.";
        }
        else
        {
            return "You thrived in collaborative settings, ensuring that everyone’s voice was heard and working well with others to achieve common goals.";
        }
    }

    /// <summary>
    /// Provides a summary of the player's problem-solving performance based on their percentage score.
    /// </summary>
    private string GetProblemSolvingSummary(float percentage)
    {
        if (percentage <= 50)
        {
            return "You encountered some issues finding solutions to complex problems. Developing a structured approach could improve your problem-solving abilities.";
        }
        else
        {
            return "You've demonstrated strong problem-solving skills, analyzing situations carefully and finding effective solutions to challenges.";
        }
    }

    /// <summary>
    /// Determines the player's level rating based on their overall grade percentage.
    /// </summary>
    private string GetPlayerLevel(float grade)
    {
        if (grade <= 50)
        {
            return "Novice Strategist";
        }
        else
        {
            return "Master Technician";
        }
    }
}
