using UnityEngine;
using Eflatun.SceneReference;

public class Door : Interactable
{
    public static event System.Action<string> LoadRoomEvent = null;
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

        LoadRoomEvent?.Invoke(roomToLoad.Name);
    }
}
