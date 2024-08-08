using UnityEngine;
using Eflatun.SceneReference;

public class Door : Interactable
{
    [SerializeField] private SceneReference roomToLoad;
    [SerializeField] private SpawnPoint _spawnPoint;

    void Start()
    {
        if (_spawnPoint == null) return;

        _spawnPoint.SpawnAtPoint();
    }
    public override void Interact()
    {
        _spawnPoint.SetActiveConnection();

        EventDispatcher.Raise(new LoadRoomEvent { roomName = roomToLoad.Name });
    }
}
