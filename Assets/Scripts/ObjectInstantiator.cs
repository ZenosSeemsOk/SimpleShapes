using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private float fadeinTime;
    [SerializeField] private GameObject[] shapes;
    [SerializeField] private RectTransform[] shapeSpawns;
    [SerializeField] private Image actualBackgroundImage;
    [SerializeField] private Image[] backgroundImages;
    [SerializeField] private Image boardImage;
    [SerializeField] private Image[] boardImages;
    [SerializeField] private string[] objectiveNote;
    [SerializeField] private string[] completionNote;
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private TextMeshProUGUI completionText;
    [SerializeField] private GameObject[] Furnitures;
    [SerializeField] private RectTransform spawnPoint;
    [SerializeField] private GameObject[] furnitureDropZones;
    private LevelManager levelManager;
    public int snapCount = 0;
    public bool gameOverCheck;
    public bool isSnapped;
    public bool hasInstantiated = false; // Prevent multiple instantiations
    GameObject new_Frame_1;

    public static CardSpawner instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelManager = LevelManager.Instance;
        snapCount = 0;
        hasInstantiated = false; // Reset at the start of the level
        completionText.gameObject.SetActive(false);
        objectiveText.gameObject.SetActive(true);
        actualBackgroundImage.sprite = backgroundImages[0].sprite;
        switch (levelManager.Level)
        {
            case 1:
                objectiveText.text = objectiveNote[0];
                //boardImage.sprite = boardImages[1].sprite;
                new_Frame_1 = Instantiate(furnitureDropZones[0], spawnPoint);
                Instantiate(shapes[0], shapeSpawns[0]);
                Instantiate(shapes[1], shapeSpawns[1]);
                break;
            case 2:
                objectiveText.text = objectiveNote[1];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[1], spawnPoint);
                Instantiate(shapes[0], shapeSpawns[0]);
                Instantiate(shapes[1], shapeSpawns[1]);
                break;
            case 3:
                objectiveText.text = objectiveNote[2];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[2], spawnPoint);
                Instantiate(shapes[0], shapeSpawns[0]);
                Instantiate(shapes[1], shapeSpawns[1]);
                break;
            case 4:
                objectiveText.text = objectiveNote[3];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[3], spawnPoint);
                Instantiate(shapes[0], shapeSpawns[0]);
                Instantiate(shapes[1], shapeSpawns[1]);
                break;
            case 5:
                objectiveText.text = objectiveNote[4];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[4], spawnPoint);
                Instantiate(shapes[0], shapeSpawns[0]);
                Instantiate(shapes[1], shapeSpawns[1]);
                break;
        }
    }

    public void SnapCheck()
    {
        GameObject spawnedFurniture = null;

        switch (levelManager.Level)
        {
            case 1:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[0], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[0];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 2:
                spawnedFurniture = Instantiate(Furnitures[1], spawnPoint);
                hasInstantiated = true;
                break;
            case 3:
                spawnedFurniture = Instantiate(Furnitures[2], spawnPoint);
                hasInstantiated = true;
                break;
            case 4:
                spawnedFurniture = Instantiate(Furnitures[3], spawnPoint);
                hasInstantiated = true;
                break;
            case 5:
                spawnedFurniture = Instantiate(Furnitures[4], spawnPoint);
                hasInstantiated = true;
                break;
        }

        if (spawnedFurniture != null)
        {
            StartCoroutine(FadeInUI(spawnedFurniture, fadeinTime));
        }
    }

    private IEnumerator FadeInUI(GameObject obj, float duration)
    {
        // Get the Image component from the child object
        Image image = obj.GetComponentInChildren<Image>();
        if (image == null) yield break; // Exit if no Image found

        Color color = image.color;
        color.a = 0f; // Start fully transparent
        image.color = color;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            image.color = color;
            yield return null;
        }

        color.a = 1f; // Ensure full opacity at the end
        image.color = color;
    }


    /*private void DisableDragDropOnAllCards()
    {
        // Iterate over all the cards in the parent transform
        foreach (Transform child in parentTransform)
        {
            DragDrop2D dragDrop = child.GetComponent<DragDrop2D>();
            if (dragDrop != null)
            {
                dragDrop.enabled = false; // Disable DragDrop2D component
            }
        }
    }*/
}
