using System.Collections.Generic;
using UnityEngine;

public class GameVariables
{
    private static GameVariables _instance = null;
    public static GameVariables Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameVariables();

            return _instance;
        }
    }
    List<string> _collectedPieces = new();
    public static int keyCount;

    public void AddCollectedCount(Interactable interactable)
    {
        _collectedPieces.Add(interactable.name);
    }
    public void CheckIfCollected(Interactable interactable)
    {
        foreach (var pieceNames in _collectedPieces)
        {
            if (interactable.name == pieceNames)
            {
                interactable.gameObject.SetActive(false);
            }
        }
    }
}

