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
    private string _comicToLoad = string.Empty;
    public string ComicToLoad => _comicToLoad;
    private int keyCount = 0;
    public int KeyCount => keyCount;

    public RoomConnection ActiveConnection = null;
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
    public void AddKeyCount()
    {
        keyCount++;
        EventDispatcher.Raise(new KeyCollectedEvent());
    }
    public void SubtractKeyCount()
    {
        keyCount--;
        EventDispatcher.Raise(new KeyUsedEvent());
    }
    public void SetActiveRoomConnection(RoomConnection connection)
    {
        ActiveConnection = connection;
    }
    public void SetComicToLoad(string comic)
    {
        _comicToLoad = comic;
    }

    public void ResetValues()
    {
        ActiveConnection = null;
        _collectedPieces.Clear();
        _comicToLoad = string.Empty;
        keyCount = 0;
    }
}

