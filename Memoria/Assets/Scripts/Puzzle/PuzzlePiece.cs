using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour, IClickable
{
    PointClick pointClick;
    Collider2D puzzleCollider;
    Image puzzleImage;
    float collisionDist = 1.0f;
    bool lockPiece = false;
    public GameObject dropArea = null;
    void Awake()
    {
        puzzleCollider = GetComponent<Collider2D>();
        puzzleImage = GetComponent<Image>();
        pointClick = GetComponent<PointClick>();
    }

    public void Click()
    {
        if (lockPiece) return;

        transform.position = pointClick.MouseWorldPosition();
    }

    public void Drag()
    {
        if (lockPiece) return;

        transform.position = pointClick.MouseWorldPosition();
        puzzleImage.color = new Color(puzzleImage.color.r, puzzleImage.color.g, puzzleImage.color.b, 0.5f);
    }

    public void Release()
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
}
