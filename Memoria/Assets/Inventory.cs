using UnityEngine;

public class Inventory : MonoBehaviour
{
    int pieceCount = 0;
    void OnEnable()
    {
        EventDispatcher.AddListener<CollectedEvent>(ctx => AddToCount());
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddToCount());
    }
    void AddToCount()
    {
        pieceCount++;

        if (pieceCount == 6)
        {
            EventDispatcher.Raise(new LoadPuzzleEvent());
            pieceCount = 0;
        }
    }
}
