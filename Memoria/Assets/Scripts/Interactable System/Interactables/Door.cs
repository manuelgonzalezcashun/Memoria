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
        if (DialogueLoader != null)
        {
            DialogueLoader.LoadDialogue();
            return;
        }

        _spawnPoint.SetActiveConnection();

        LoadSceneEvent loadSceneEvent = new LoadSceneEvent { sceneToLoad = roomToLoad.Name };
        EventDispatcher.Raise(loadSceneEvent);
    }
}
