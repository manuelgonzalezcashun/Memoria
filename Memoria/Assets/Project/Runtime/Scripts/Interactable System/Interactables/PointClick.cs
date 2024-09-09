using UnityEngine;

public class PointClick : MonoBehaviour
{
    private Camera pointClickCam = null;
    Vector3 offset;
    Collider2D objectCollider;
    IClickable clickable;

    void Awake()
    {
        objectCollider = GetComponent<Collider2D>();
        clickable = GetComponent<IClickable>();
    }

    void Start()
    {
        pointClickCam = CameraManager.Instance.GetCurrentCamera();
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
        mouseScreenPos.z = pointClickCam.WorldToScreenPoint(transform.position).z;
        return pointClickCam.ScreenToWorldPoint(mouseScreenPos);
    }
}
