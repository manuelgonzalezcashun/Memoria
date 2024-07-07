using UnityEngine;

public class Door : Interactable
{
    public string RoomToLoad = string.Empty;
    public override void Interact()
    {
        EventDispatcher.Raise(new LoadRoomEvent { roomName = RoomToLoad });
    }
}
