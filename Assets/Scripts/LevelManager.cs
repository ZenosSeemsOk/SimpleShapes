using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Level = 1; // Current level
    public static LevelManager Instance;

    public DropZone dropZone; // Reference to the DropZone

    // Define expected shape tags for each level
    private string[][] levelShapeTags = new string[][]
    {
        new string[] { "Triangle", "Triangle" }, // Level 1
        new string[] { "Square", "Square" },     // Level 2
        new string[] { "Circle", "Circle" },     // Level 3
        new string[] { "Triangle", "Square" },   // Level 4
        new string[] { "Rectangle", "Rectangle", "Rectangle", "Rectangle" }, // Level 5
        new string[] { "Rectangle", "Rectangle", "Circle", "Circle" },       // Level 6
        new string[] { } // Level 7 (Freestyle, no specific shapes)
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadLevel(Level); // Load the initial level
    }

    // Load a specific level
    public void LoadLevel(int level)
    {
        if (level < 1 || level > levelShapeTags.Length)
        {
            Debug.LogError("Invalid level number!");
            return;
        }

        Level = level;
        Debug.Log($"Loading Level {Level}");

        // Update the DropZone with the expected shapes for this level
        if (dropZone != null)
        {
            dropZone.ResetDropZone();
            dropZone.expectedShapeTags = levelShapeTags[level - 1]; // Level is 1-based, array is 0-based
        }
        else
        {
            Debug.LogError("DropZone reference is missing!");
        }
    }

    // Proceed to the next level
    public void NextLevel()
    {
        if (Level < levelShapeTags.Length)
        {
            Level++;
            LoadLevel(Level);
        }
        else
        {
            Debug.Log("All levels completed!");
            // Handle game completion logic here (e.g., show a victory screen)
        }
    }

    // Reset the current level
    public void ResetLevel()
    {
        LoadLevel(Level);
    }
}