using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This static variable is used to implement the singleton pattern, which ensures that
    //only one instance of GameManager exists throughout the game.
    //Other scripts can easily access it by using GameManager.Instance.
    public static GameManager Instance;

    //These are references to two SnapSection objects (other scripts/components you’ve set up that manage snapping behavior).
    //You assign these in the Unity Inspector.
    [Header("Snap Sections")]
    public SnapSection section1;
    public SnapSection section2;

    //This is a reference to a prefab (a pre-configured GameObject saved as an asset) that represents the combined image.
    [Header("Combined Image Prefab")]
    public GameObject combinedImagePrefab;

    //This boolean flag ensures that the combined image is spawned only once.After the image is spawned,
    //imageSpawned is set to true to prevent additional instantiations if CheckSnaps() is called again.
    private bool imageSpawned = false;

    //This method is called by Unity when the script instance is being loaded.
    private void Awake()
    {
        //It means no other GameManager exists yet, so we assign the current instance (this)
        //to the static Instance variable.
        if (Instance == null)
            Instance = this;
        else
            //If Instance is already set (i.e., there’s another GameManager), we destroy the current GameObject to ensure only one instance exists.
            Destroy(gameObject);
    }

    // This function is called by the SnapSection script when an object is snapped
    public void CheckSnaps()
    {
        if (!imageSpawned && section1.isSnapped && section2.isSnapped)
        {
            SpawnCombinedImage();
        }
    }

    //This method handles the actual spawning of the combined image prefab once both snap sections are satisfied.
    private void SpawnCombinedImage()
    {
        // Calculate a position between the two snap points, or choose a specific location
        Vector3 spawnPosition = (section1.snapPoint.position + section2.snapPoint.position) / 2f;
        Instantiate(combinedImagePrefab, spawnPosition, Quaternion.identity);
        imageSpawned = true;
    }
}
