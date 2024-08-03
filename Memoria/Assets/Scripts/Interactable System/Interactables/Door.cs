using UnityEngine;
using Eflatun.SceneReference;

public class Door : Interactable
{
    [SerializeField] private SceneReference roomToLoad;
    public override void Interact()
    {
        if (roomToLoad == null)
        {
            Debug.LogWarning($"{name} is missing a scene reference. Please assign a scene reference!");
            return;
        }
        EventDispatcher.Raise(new LoadRoomEvent { roomName = roomToLoad.Name });
    }
}
