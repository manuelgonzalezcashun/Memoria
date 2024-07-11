using UnityEngine;

public class Collectable : Interactable
{
    public override void Interact()
    {
        EventDispatcher.Raise(new CollectedEvent());

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
    void Start()
    {
        EventDispatcher.Raise(new GetCollectableCount());
    }
}
