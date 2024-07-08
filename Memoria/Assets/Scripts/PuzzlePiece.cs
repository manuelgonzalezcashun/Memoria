using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    Vector3 offset;
    Collider2D puzzleCollider;
    public GameObject dropArea = null;
    void Awake()
    {
        puzzleCollider = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        transform.position = MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        puzzleCollider.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;
        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hitInfo.collider.gameObject == dropArea)
            {
                Debug.Log($"Found Pair: {name} / {hitInfo.collider.gameObject.name}");
                transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
            }
        }
        puzzleCollider.enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
