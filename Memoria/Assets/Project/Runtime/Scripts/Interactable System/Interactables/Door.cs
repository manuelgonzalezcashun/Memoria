using UnityEngine;
using Eflatun.SceneReference;

public class Door : Interactable
{
    [SerializeField] private SceneReference roomToLoad;
    [SerializeField] private SpawnPoint _spawnPoint;

    [SerializeField] private bool _doorLocked;
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
