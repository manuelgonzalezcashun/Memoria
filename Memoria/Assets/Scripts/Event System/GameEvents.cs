using UnityEngine;
public class ShowInteractUI : Event
{
    public bool showUI;
    public Interactable interactable;
}
public class CollectedEvent : Event { }
public class ClickCollectedEvent : Event { }
public class AddPuzzlePieceCount : Event { }
public class PuzzleWinEvent : Event { }
public class SpawnDoor : Event { }

public class LoadSceneEvent : Event
{
    public string sceneToLoad = string.Empty;
}

public class LoadRoomEvent : Event
{
    public string roomName;
}
public class ShowDialogueEvent : Event
{
    public bool showDialogueUI;
}
public class ContinueDialogueEvent : Event
{
    public string dialogueLine;
}



