using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
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
            EventDispatcher.Raise(new PuzzleWinEvent());
        }
    }

}
