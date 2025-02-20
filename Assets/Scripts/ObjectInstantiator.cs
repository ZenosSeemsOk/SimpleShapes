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
                Instantiate(shapes[2], shapeSpawns[0]);
                Instantiate(shapes[3], shapeSpawns[1]);
                break;
            case 3:
                objectiveText.text = objectiveNote[2];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[2], spawnPoint);
                Instantiate(shapes[4], shapeSpawns[0]);
                Instantiate(shapes[5], shapeSpawns[1]);
                break;
            case 4:
                objectiveText.text = objectiveNote[3];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[3], spawnPoint);
                Instantiate(shapes[6], shapeSpawns[0]);
                Instantiate(shapes[7], shapeSpawns[1]);
                break;
            case 5:
                objectiveText.text = objectiveNote[4];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[4], spawnPoint);
                Instantiate(shapes[8], shapeSpawns[0]);
                Instantiate(shapes[9], shapeSpawns[1]);
                break;
            case 6:
                objectiveText.text = objectiveNote[5];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[5], spawnPoint);
                Instantiate(shapes[10], shapeSpawns[0]);
                Instantiate(shapes[11], shapeSpawns[1]);
                break;
            case 7:
                objectiveText.text = objectiveNote[6];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[6], spawnPoint);
                Instantiate(shapes[12], shapeSpawns[0]);
                Instantiate(shapes[13], shapeSpawns[1]);
                break;
            case 8:
                objectiveText.text = objectiveNote[7];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[7], spawnPoint);
                Instantiate(shapes[14], shapeSpawns[0]);
                break;
            case 9:
                objectiveText.text = objectiveNote[8];
                //boardImage.sprite = boardImages[1].sprite;
                Instantiate(furnitureDropZones[8], spawnPoint);
                Instantiate(shapes[15], shapeSpawns[0]);
                break;
            case 10:
                objectiveText.text = objectiveNote[9];
                boardImage.sprite = boardImages[2].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[9], spawnPoint);
                Instantiate(shapes[16], shapeSpawns[0]);
                Instantiate(shapes[17], shapeSpawns[1]);
                break;
            case 11:
                objectiveText.text = objectiveNote[10];
                boardImage.sprite = boardImages[2].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[10], spawnPoint);
                Instantiate(shapes[18], shapeSpawns[0]);
                break;
            case 12:
                objectiveText.text = objectiveNote[11];
                boardImage.sprite = boardImages[2].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[11], spawnPoint);
                Instantiate(shapes[19], shapeSpawns[0]);
                Instantiate(shapes[20], shapeSpawns[1]);
                break;
            case 13:
                objectiveText.text = objectiveNote[12];
                boardImage.sprite = boardImages[2].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[12], spawnPoint);
                Instantiate(shapes[21], shapeSpawns[0]);
                Instantiate(shapes[22], shapeSpawns[1]);
                Instantiate(shapes[23], shapeSpawns[2]);
                Instantiate(shapes[24], shapeSpawns[3]);
                break;
            case 14:
                objectiveText.text = objectiveNote[13];
                boardImage.sprite = boardImages[2].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[13], spawnPoint);
                Instantiate(shapes[25], shapeSpawns[0]);
                Instantiate(shapes[26], shapeSpawns[1]);
                Instantiate(shapes[27], shapeSpawns[2]);
                Instantiate(shapes[28], shapeSpawns[3]);
                break;
            case 15:
                objectiveText.text = objectiveNote[14];
                boardImage.sprite = boardImages[2].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[14], spawnPoint);
                Instantiate(shapes[29], shapeSpawns[0]);
                Instantiate(shapes[30], shapeSpawns[1]);
                Instantiate(shapes[31], shapeSpawns[2]);
                Instantiate(shapes[32], shapeSpawns[3]);
                break;
            case 16:
                objectiveText.text = objectiveNote[15];
                boardImage.sprite = boardImages[3].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[15], spawnPoint);
                Instantiate(shapes[33], shapeSpawns[0]);
                Instantiate(shapes[34], shapeSpawns[1]);
                Instantiate(shapes[35], shapeSpawns[2]);
                Instantiate(shapes[36], shapeSpawns[3]);
                break;
            case 17:
                objectiveText.text = objectiveNote[16];
                boardImage.sprite = boardImages[3].sprite;
                actualBackgroundImage.sprite = backgroundImages[2].sprite;
                Instantiate(furnitureDropZones[16], spawnPoint);
                Instantiate(shapes[37], shapeSpawns[0]);
                Instantiate(shapes[38], shapeSpawns[1]);
                Instantiate(shapes[39], shapeSpawns[2]);
                Instantiate(shapes[40], shapeSpawns[3]);
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
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[1], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[1];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 3:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[2], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[2];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 4:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[3], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[3];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 5:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[4], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[4];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 6:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[5], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[5];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 7:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[6], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[6];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 8:
                if (snapCount == 1) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[7], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[7];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 9:
                if (snapCount == 1) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[8], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[8];
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;

            case 10:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[9], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[9];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 11:
                if (snapCount == 1) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[10], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[10];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 12:
                if (snapCount == 2) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[11], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[11];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 13:
                if (snapCount == 4) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[12], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[12];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 14:
                if (snapCount == 4) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[13], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[13];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 15:
                if (snapCount == 4) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[14], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[14];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 16:
                if (snapCount == 4) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[15], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[15];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
                break;
            case 17:
                if (snapCount == 4) // Check with the Number of shapes snapped in the particular scene
                {
                    spawnedFurniture = Instantiate(Furnitures[16], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = completionNote[16];
                    actualBackgroundImage.sprite = backgroundImages[3].sprite;
                }
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
