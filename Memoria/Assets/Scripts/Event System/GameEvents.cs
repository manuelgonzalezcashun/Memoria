using UnityEngine;
public class ShowInteractUI : Event
{
    public bool showUI;
    public Interactable interactable;
}
public class CollectedEvent : Event { }
public class LoadPuzzleEvent : Event { }

public class LoadRoomEvent : Event
{
    public string roomName;
}
public class AddPuzzlePieceCount : Event { }
public class PuzzleWinEvent : Event { }




