using UnityEngine;

public class DropZone : MonoBehaviour
{
    // Set an expected shape tag (assign this via the Inspector)
    public string expectedShapeTag = "Triangle";

    // Optional: offset for snapping position
    public Vector3 snapOffset;

    // Check if this drop zone can accept the shape
    public bool CanAcceptShape(GameObject shape)
    {
        // Verify the dropped object’s tag
        return shape.CompareTag(expectedShapeTag);
    }

    // Return the position where the shape should snap
    public Vector3 GetSnapPosition()
    {
        return transform.position + snapOffset;
    }

    // Called when a shape is successfully placed
    public void ShapePlaced(GameObject shape)
    {
    }

    // New Method: Called when a shape is placed correctly
    public void ShapePlacedCorrectly()
    {
        Debug.Log("Shape placed correctly!");
    }
}
