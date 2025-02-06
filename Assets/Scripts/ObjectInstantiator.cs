using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInstantiator : MonoBehaviour
{
    [SerializeField] private Image actualBackgroundImage;
    [SerializeField] private Image[] backgroundImages;
    [SerializeField] private Image boardImage;
    [SerializeField] private Image[] boardImages;
    [SerializeField] private TextMeshProUGUI objectiveText;
    [SerializeField] private TextMeshProUGUI completionText;
    [SerializeField] private GameObject[] Furnitures;
    [SerializeField] private RectTransform spawnPoint;
    [SerializeField] private DropZone[] furnitureDropZones;
    private LevelManager levelManager;
    public int snapCount = 0;
    public bool gameOverCheck;
    public bool isSnapped;
    public bool hasInstantiated = false; // Prevent multiple instantiations

    public static ObjectInstantiator instance;

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
                objectiveText.text = "Build a door by combining two triangles";
                boardImage.sprite = boardImages[0].sprite;
                Instantiate(furnitureDropZones[0], spawnPoint.position, Quaternion.identity);
                break;
            case 2:
                objectiveText.text = "Build a door by combining two triangles";
                boardImage.sprite = boardImages[0].sprite;
                Instantiate(furnitureDropZones[1], spawnPoint.position,Quaternion.identity);
                break;
            case 3:
                objectiveText.text = "Build a door by combining two triangles";
                boardImage.sprite = boardImages[0].sprite;
                Instantiate(furnitureDropZones[2], spawnPoint.position, Quaternion.identity);
                break;
            case 4:
                objectiveText.text = "Build a door by combining two triangles";
                boardImage.sprite = boardImages[0].sprite;
                Instantiate(furnitureDropZones[3], spawnPoint.position, Quaternion.identity);
                break;
            case 5:
                objectiveText.text = "Build a door by combining two triangles";
                boardImage.sprite = boardImages[0].sprite;
                Instantiate(furnitureDropZones[4], spawnPoint.position, Quaternion.identity);
                break;
        }
    }

    public void SnapCheck()
    {
        switch (levelManager.Level)
        {
            case 1:
                if (snapCount == 2)
                {
                    Instantiate(Furnitures[0], spawnPoint);
                    hasInstantiated = true;
                    gameOverCheck = true;
                    objectiveText.gameObject.SetActive(false);
                    completionText.gameObject.SetActive(true);
                    completionText.text = "You Built a Door !";
                    actualBackgroundImage.sprite = backgroundImages[1].sprite;
                }
                break;
            case 2:
                Instantiate(Furnitures[1], spawnPoint);
                hasInstantiated = true;
                break;
            case 3:
                Instantiate(Furnitures[2], spawnPoint);
                hasInstantiated = true;
                break;
            case 4:
                Instantiate(Furnitures[3], spawnPoint);
                hasInstantiated = true;
                break;
            case 5:
                Instantiate(Furnitures[4], spawnPoint);
                hasInstantiated = true;
                break;
        }
    }
}
