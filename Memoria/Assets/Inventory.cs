using UnityEngine;
using TMPro; 

public class Inventory : MonoBehaviour
{
    int pieceCount = 0;
    public TMP_Text counterText; 
    void OnEnable()
    {
        EventDispatcher.AddListener<CollectedEvent>(ctx => AddToCount());
        counterText.text = "0/6";
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddToCount());
    }
    void AddToCount()
    {
        Debug.Log("Colledcted Puzzle Piece!");

        pieceCount++;
        counterText.text = pieceCount + "/6";

        if (pieceCount == 6)
        {
            EventDispatcher.Raise(new LoadPuzzleEvent());
            pieceCount = 0;
        }
    }
}
