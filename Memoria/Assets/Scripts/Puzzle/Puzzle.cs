using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    public UnityEvent PuzzleWinEvent;
    public List<GameObject> puzzleDropAreas = new();
    int pieceCount = 0;

    void OnEnable()
    {
        EventDispatcher.AddListener<AddPuzzlePieceCount>(ctx => AddToPieceCount());
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<AddPuzzlePieceCount>(ctx => AddToPieceCount());
    }

    void AddToPieceCount()
    {
        pieceCount++;

        if (pieceCount == puzzleDropAreas.Count)
        {
            PuzzleWinEvent?.Invoke();
        }
    }

}
