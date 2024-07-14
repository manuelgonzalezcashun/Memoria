using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    Vector3 offset;
    Collider2D puzzleCollider;
    Image puzzleImage;
    float collisionDist = 1.0f;
    bool lockPiece = false;
    public GameObject dropArea = null;
    void Awake()
    {
        puzzleCollider = GetComponent<Collider2D>();
        puzzleImage = GetComponent<Image>();
    }

    void OnMouseDown()
    {
        if (lockPiece) return;

        transform.position = MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (lockPiece) return;

        transform.position = MouseWorldPosition() + offset;
        puzzleImage.color = new Color(puzzleImage.color.r, puzzleImage.color.g, puzzleImage.color.b, 0.5f);
    }

    void OnMouseUp()
    {
        float distance = Vector3.Distance(transform.position, dropArea.transform.position);
        puzzleCollider.enabled = false;

        if (distance < collisionDist)
        {
            EventDispatcher.Raise(new AddPuzzlePieceCount());
            transform.position = dropArea.transform.position + new Vector3(0, 0, -0.01f);
            lockPiece = true;
        }
        puzzleCollider.enabled = true;
        puzzleImage.color = new Color(puzzleImage.color.r, puzzleImage.color.g, puzzleImage.color.b, 1f);
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
