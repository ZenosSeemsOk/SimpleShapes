using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Canvas canvas; // Needed if you’re dragging UI elements; for world objects, adjust accordingly.
    private ObjectInstantiator instantiator;
    private LevelManager levelManager;
    private bool mySnapCheck;
    private void Start()
    {
        // If using UI (with RectTransform), get the parent Canvas.
        canvas = GetComponentInParent<Canvas>();
        instantiator = ObjectInstantiator.instance;
    }

    // Called when the drag starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
    }

    // Called while dragging
    public void OnDrag(PointerEventData eventData)
    {
        // Use a fixed z distance to ensure the object stays at the correct depth
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10f));
        newPos.z = 0; // Ensure the object remains on the correct plane
        transform.position = newPos;
    }


    // Called when drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if dropped over a valid drop zone
        DropZone dropZone = GetDropZoneUnderPointer(eventData);
        if (dropZone != null && dropZone.CanAcceptShape(gameObject))
        {
            // Snap into place and let the drop zone handle any extra logic
            transform.position = dropZone.GetSnapPosition();
            instantiator.isSnapped = true;
            if(!instantiator.gameOverCheck && !mySnapCheck)
            {
                instantiator.snapCount += 1;
                mySnapCheck = true;
            }
            if (instantiator.isSnapped && !instantiator.hasInstantiated)
            {
                instantiator.SnapCheck();
            }
        }
        else
        {
            // Return to original position if not dropped correctly
            transform.position = startPosition;
            // Optionally, play an "oops" sound here or add a wiggle animation.
        }
    }

    // Helper method to detect drop zone under pointer
    private DropZone GetDropZoneUnderPointer(PointerEventData eventData)
    {
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var result in results)
        {
            DropZone zone = result.gameObject.GetComponent<DropZone>();
            if (zone != null)
            {
                Debug.Log("Drop zone detected: " + zone.gameObject.name);
                return zone;
            }
        }
        Debug.Log("No drop zone detected.");
        return null;
    }

    private void Update()
    {
        if(instantiator.gameOverCheck)
        {
            gameObject.SetActive(false);
        }
    }

}
