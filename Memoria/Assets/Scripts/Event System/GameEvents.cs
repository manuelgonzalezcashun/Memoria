using UnityEngine;
public class ShowInteractUI : Event
{
    public bool showUI;
    public Interactable interactable;
}
public class CollectedEvent : Event { }

public class GetCollectableCount : Event
{
    public Collectable collectable;
}

public class LoadRoomEvent : Event
{
    public string roomName;
}



