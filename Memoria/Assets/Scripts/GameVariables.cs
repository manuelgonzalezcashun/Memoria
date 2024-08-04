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

    public void AddCollectedCount(Collectable collectable)
    {
        _collectedPieces.Add(collectable.name);
    }
    public void CheckIfCollected(Collectable collectable)
    {
        foreach (var pieceNames in _collectedPieces)
        {
            if (collectable.name == pieceNames)
            {
                collectable.gameObject.SetActive(false);
            }
        }
    }
}

