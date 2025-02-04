using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Singleton instance for easy access
    public static LevelManager Instance;

    // Count how many shapes have been placed correctly
    private int placedShapes = 0;
    // Total number of shapes required for Level 1
    public int totalShapes = 2;

    // Reference to the door object (the rectangle that will animate)
    public GameObject doorObject;

    // Reference to the Finished Door Prefab and Spawn Point
    public GameObject finishedDoorPrefab;
    public Transform spawnPoint;

    // Shapes and DropZones to hide after completion
    public GameObject[] shapesToHide;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Called by DropZone when a shape is placed
    public void ShapePlaced(GameObject shape)
    {
        placedShapes++;

        // Disable further dragging on the shape
        shape.GetComponent<Draggable>().enabled = false;

        // Check if all required shapes are placed
        if (placedShapes >= totalShapes)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        // Trigger the door’s animation (e.g., swing open)
        Animator doorAnim = doorObject.GetComponent<Animator>();
        if (doorAnim != null)
        {
            doorAnim.SetTrigger("Open");
        }
            
        // Hide shapes and drop zones
        foreach (GameObject obj in shapesToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                Debug.Log("Hiding object: " + obj.name);
            }
            else
            {
                Debug.LogWarning("Object in shapesToHide is null!");
            }
        }

        // Spawn the Finished Door Prefab
        if (finishedDoorPrefab != null && spawnPoint != null)
        {
            GameObject doorClone = Instantiate(finishedDoorPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Level Completed! Finished Door Spawned.");
        }
        else
        {
            Debug.LogWarning("Finished Door Prefab or Spawn Point is missing!");
        }
    }

}
