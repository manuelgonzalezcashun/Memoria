using UnityEngine;

public class PointClick : MonoBehaviour
{
    Vector3 offset;
    Collider2D objectCollider;
    IClickable clickable;

    void Awake()
    {
        objectCollider = GetComponent<Collider2D>();
        clickable = GetComponent<IClickable>();
    }

    void OnMouseDown()
    {
        clickable.Click();
    }

    void OnMouseDrag()
    {
        clickable.Drag();
    }

    void OnMouseUp()
    {
        clickable.Release();
    }
    public Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
