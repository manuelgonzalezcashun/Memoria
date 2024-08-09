using UnityEngine;
public class ShowInteractUI : Event
{
    public bool showUI;
    public Interactable interactable;
}
public class CollectedEvent : Event { }
public class KeyCollectedEvent : Event { }
public class KeyUsedEvent : Event { }
public class AddPuzzlePieceCount : Event { }
public class PuzzleWinEvent : Event
{
    public string endSceneName;
}
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
public class SpawnPlayerEvent : Event
{
    public Vector2 spawnPos;
}
public class SceneLoadingEvent : Event
{
    public bool isSceneLoading = false;
}
public class ChangeCameraSettings : Event
{
    public Vector2 newXlimit, newYLimit;
    public float newCamZoom;
}
