using UnityEngine;
using Eflatun.SceneReference;

public class Door : Interactable
{
    [SerializeField] private SceneReference roomToLoad;
    [SerializeField] private SpawnPoint _spawnPoint;

    [SerializeField] private bool _doorLocked;

    void Start()
    {
        if (_spawnPoint == null) return;

        _spawnPoint.SpawnAtPoint();
    }
    public override void Interact()
    {
        if (_doorLocked)
        {
            base.Interact();
            return;
        }

        _spawnPoint.SetActiveConnection();

        LoadSceneEvent loadSceneEvent = new LoadSceneEvent { sceneToLoad = roomToLoad.Name };
        EventDispatcher.Raise(loadSceneEvent);
    }
    public void UnlockDoor()
    {
        _doorLocked = false;
    }
}
