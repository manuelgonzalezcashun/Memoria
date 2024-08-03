using UnityEngine;
using Eflatun.SceneReference;

public class Door : Interactable
{
    [SerializeField] private SceneReference roomToLoad;
    [SerializeField] private RoomConnection _connection = null;
    [SerializeField] private Transform _spawnPoint = null;

    void Start()
    {
        if (_spawnPoint != null && RoomConnection.ActiveConnection == _connection)
        {
            EventDispatcher.Raise(new SpawnPlayerEvent { spawnPos = _spawnPoint.position });
        }
    }
    public override void Interact()
    {
        RoomConnection.ActiveConnection = _connection;
        EventDispatcher.Raise(new LoadRoomEvent { roomName = roomToLoad.Name });
    }
}
