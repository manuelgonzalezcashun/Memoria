using UnityEngine;

public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D objectCollider;
    IDragable dragable;

    void Awake()
    {
        objectCollider = GetComponent<Collider2D>();
        dragable = GetComponent<IDragable>();
    }

    void OnMouseDown()
    {
        dragable.Click();
    }

    void OnMouseDrag()
    {
        dragable.Drag();
    }

    void OnMouseUp()
    {
        dragable.Release();
    }
    public Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
