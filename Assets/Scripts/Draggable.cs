using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;
    private Camera mainCamera;
    private SnapToPosition currentSnap;
    public bool isSnapped = false;
    public float value;
    private CardSpawner spawner;
    private Vector3 originalPosition;
    private Collider2D col; // Reference to the Collider2D

    // Add a flag to control draggability
    private bool isDraggable = true;

    [Header("Gizmos Settings")]
    [SerializeField] private bool showGizmos = true;
    [SerializeField] private Color gizmoColor = Color.yellow;

    private void Awake()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
        col = GetComponent<Collider2D>(); // Get the Collider2D

        // Ensure there's a collider
        if (col == null)
        {
            Debug.LogError("No Collider2D found! Adding a BoxCollider2D.", this);
            col = gameObject.AddComponent<BoxCollider2D>();
        }
    }

    private void Start()
    {
        spawner = CardSpawner.instance;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Prevent dragging if already snapped or not draggable
        if (!isDraggable || isSnapped) return;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(
            eventData.position.x,
            eventData.position.y,
            mainCamera.nearClipPlane
        ));

        offset = transform.position - new Vector3(worldPosition.x, worldPosition.y, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Exit if not draggable
        if (!isDraggable || isSnapped) return;

        Vector3 screenBoundsMin = mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 screenBoundsMax = mainCamera.ScreenToWorldPoint(new Vector3(
            Screen.width,
            Screen.height,
            mainCamera.nearClipPlane
        ));

        // Use collider bounds instead of renderer
        float cardHeight = col.bounds.size.y;
        float cardWidth = col.bounds.size.x;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(
            eventData.position.x,
            eventData.position.y,
            mainCamera.nearClipPlane
        ));

        Vector3 newPosition = new Vector3(
            worldPosition.x + offset.x,
            worldPosition.y + offset.y,
            0
        );

        // Clamp position using collider-based calculations
        newPosition.x = Mathf.Clamp(
            newPosition.x,
            screenBoundsMin.x + cardWidth / 2,
            screenBoundsMax.x - cardWidth / 2
        );

        newPosition.y = Mathf.Clamp(
            newPosition.y,
            screenBoundsMin.y + cardHeight / 2,
            screenBoundsMax.y - cardHeight / 2
        );

        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Exit if not draggable
        if (!isDraggable || isSnapped) return;

        SnapToPosition validSnap = FindValidSnapPoint();

        if (validSnap != null)
        {
            SnapToPosition(validSnap);
        }
        else
        {
            if (!isSnapped)
            {
                StartCoroutine(MoveBackToOriginalPosition());
            }
        }
    }

    private IEnumerator MoveBackToOriginalPosition()
    {
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 startPosition = transform.position;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, originalPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
    }

    private SnapToPosition FindValidSnapPoint()
    {
        Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(
            transform.position,
            1f // Increased detection radius
        );

        SnapToPosition closestSnap = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in overlappingColliders)
        {
            if (!collider.CompareTag("ScalePoint")) //!collider.CompareTag("Position") &&)
                continue;

            SnapToPosition snap = collider.GetComponent<SnapToPosition>();
            if (snap != null && snap.value == value && !snap.isSnapped)
            {
                float distance = Vector2.Distance(transform.position, snap.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSnap = snap;
                }
            }
        }
        return closestSnap;
    }

    private void SnapToPosition(SnapToPosition snap)
    {
        if (snap == null || snap.value != value) return;

        // Disable dragging FIRST
        isDraggable = false;
        col.enabled = false;

        // Then snap
        transform.position = snap.transform.position;
        currentSnap = snap;
        currentSnap.isSnapped = true;
        isSnapped = true;

        // Trigger snap events
        spawner.snapCount++;
        spawner.SnapCheck();
    }

    private void Update()
    {
        if (spawner.gameOverCheck)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        // Draw the detection radius as a wireframe circle
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, 0.4f); // Match the radius used in FindValidSnapPoint
    }

    // Optional: Reset draggability for reuse
    public void ResetDraggability()
    {
        isDraggable = true;
        col.enabled = true;
        isSnapped = false;
    }
}