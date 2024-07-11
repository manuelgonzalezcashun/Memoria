using UnityEngine;

public class Collectable : Interactable
{
    public override void Interact()
    {
        EventDispatcher.Raise(new CollectedEvent());

        Destroy(gameObject);
    }
    void Start()
    {
        EventDispatcher.Raise(new GetCollectableCount());
    }
}
