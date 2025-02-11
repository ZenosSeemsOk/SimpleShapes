using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;

public class FromScratchDraggable : MonoBehaviour
{
    //This variable stores the offset between the point where you click on the object and the object’s pivot(or center).
    //This offset is used so that the object doesn’t jump such that its center aligns with the mouse cursor when you start dragging.
    private Vector3 offset;

    //This Boolean flag tracks whether the object is currently being dragged.
    private bool isDragging = false;

    void OnMouseDown()
    {
        // calculate the offset between the mouse world position and object position

        //This line saves the difference between where the object currently is and where the mouse clicked in world space.
        //It ensures that the object maintains its relative position to the mouse pointer while dragging.
        Vector3 mousePos = Input.mousePosition;
        // Set z to the absolute distance between the camera and the object.
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePos);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        // Get the current mouse position in world coordinates, then add the offset.
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos) + offset; 
        //Since this is a 2D game, you typically want the object to remain on the same z-plane (usually z = 0). This line guarantees that even if the
        //conversion brings a non-zero z value, it gets corrected.
        newPos.z = 0f;
        transform.position = newPos;
        //The object’s position is updated to the new calculated position, making it follow the mouse.
    }


    void OnMouseUp()
    {
        isDragging = false;
    }
}
