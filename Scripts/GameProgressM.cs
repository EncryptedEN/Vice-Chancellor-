using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the resetting of game progress for multiple Drag and Drop mini-games.
/// It calls the reset methods from different classes to ensure all game progress is cleared when needed.
/// </summary>
/// <author>Emmanuel Nwokoro</author>
public class GameProgressM : MonoBehaviour
{
    /// <summary>
    /// Resets the progress of all game-related data by invoking the ResetGameProgress methods
    /// from DragAndDropManager and DragAndDropManagers2.
    /// </summary>
    public static void ResetAllGameProgress()
    {
        // Reset the progress for the first Drag and Drop mini-game
        DragAndDropManager.ResetGameProgress();

        // Reset the progress for the second Drag and Drop mini-game
        DragAndDropManagers2.ResetGameProgress();
    }
}
