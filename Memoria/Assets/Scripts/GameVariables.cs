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
    List<string> _collectedPieces = new(); // * Tracks all of the pieces that were collected by name
    private string _comicToLoad = string.Empty; // * Loads comic in Video Manager by name
    public string ComicToLoad => _comicToLoad;
    private int keysCollected = 0; // * Tracks how many keys were collected
    public int KeysCollected => keysCollected;

    public RoomConnection ActiveConnection = null; // * Check whick rooms are connected so player can spawn in the room's spawn point

    // * After an item in collected, item is put in list to track if it was collected
    public void AddCollectedCount(Interactable interactable)
    {
        _collectedPieces.Add(interactable.name);
    }

    // * When Scene Loads, Checks if item was collected
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
        keysCollected++;
        EventDispatcher.Raise(new KeyCollectedEvent());
    }
    public void SubtractKeyCount()
    {
        keysCollected--;
        EventDispatcher.Raise(new KeyUsedEvent());
    }

    // * Sets Player's Spawnpoint in a different room
    public void SetActiveRoomConnection(RoomConnection connection)
    {
        ActiveConnection = connection;
    }
    public void SetComicToLoad(string comic)
    {
        _comicToLoad = comic;
    }

    // * Reset after Player beats the Game or Exits to Main Menu 
    public void ResetValues()
    {
        ActiveConnection = null;
        _collectedPieces.Clear();
        _comicToLoad = string.Empty;
        keysCollected = 0;

        ChangeActionMapEvent changeActionMap = new ChangeActionMapEvent { newActionMap = "Player" };
        EventDispatcher.Raise(changeActionMap);
    }
}

