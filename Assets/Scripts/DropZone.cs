using UnityEngine;

public class DropZone : MonoBehaviour
{
    // Array of expected shape tags for the current level (assign via Inspector)
    public string[] expectedShapeTags;

    // Optional: offset for snapping position
    public Vector3 snapOffset;

    // Track the number of shapes placed correctly
    private int shapesPlacedCorrectly = 0;

    // Check if this drop zone can accept the shape
    public bool CanAcceptShape(GameObject shape)
    {
        // Check if the shape's tag matches any of the expected tags
        foreach (string tag in expectedShapeTags)
        {
            if (shape.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }

    // Return the position where the shape should snap
    public Vector3 GetSnapPosition()
    {
        return transform.position + snapOffset;
    }

    // Called when a shape is successfully placed
    public void ShapePlaced(GameObject shape)
    {
        // Increment the count of correctly placed shapes
        shapesPlacedCorrectly++;

        // Check if all expected shapes have been placed
        if (shapesPlacedCorrectly == expectedShapeTags.Length)
        {
            ShapePlacedCorrectly();
        }
    }

    // Called when all shapes are placed correctly
    public void ShapePlacedCorrectly()
    {
        Debug.Log("All shapes placed correctly!");
        // Trigger level completion logic here (e.g., load next level, play a sound, etc.)
    }

    // Reset the drop zone for a new level
    public void ResetDropZone()
    {
        shapesPlacedCorrectly = 0;
    }
}