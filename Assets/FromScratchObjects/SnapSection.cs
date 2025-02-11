using UnityEditor.PackageManager;
using UnityEngine;

public class SnapSection : MonoBehaviour
{

    //The[Header] attribute improves the Unity Inspector UI by adding a label above this variable.

    [Header("Assign the Snap Point (child Transform)")]
    //The snapPoint is a public Transform where objects will snap when they enter the trigger zone.
    public Transform snapPoint;

    //[HideInInspector] prevents it from showing in the Unity Inspector, but it can still be accessed and modified by scripts.
    [HideInInspector]

    //A flag (isSnapped) to track whether an object has already snapped into this section.
    public bool isSnapped = false;

    //This function is automatically called when another 2D Collider enters this GameObject’s trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is draggable and if this section hasn't already snapped an object
        if (!isSnapped && other.gameObject.CompareTag("Draggable"))
        {
            // Ensures that only objects with the tag "Draggable" can be snapped.

            // Snap the object to the snap point's position
            other.transform.position = snapPoint.position;
            isSnapped = true;
            //Sets isSnapped to true to prevent other objects from snapping into the same section.

            // Disable this section's collider so it doesn’t interfere further
            GetComponent<BoxCollider2D>().enabled = false;

            // (Optional) Inform the GameManager that an object has been snapped.
            GameManager.Instance.CheckSnaps();

            //GameManager is a singleton (GameManager.Instance), meaning there is only one instance in the game.
        }
    }
}

//VERSION 2

