using UnityEngine;

public class Collectable : Interactable, IClickable
{
    private const string k_CollectSound = "Collect";
    void Awake()
    {
        GameVariables.Instance.CheckIfCollected(this);
    }
    void CheckIfClosestCollectable()
    {
        if (this == InteractableManager.Instance.ClosestInteractable)
        {
            Database.SetCollectable(this);
        }
    }
    void LateUpdate()
    {
        CheckIfClosestCollectable();
    }
    public override void Interact()
    {
        Database.LoadDialogue();
    }
    public void Collect()
    {
        PlaySoundEvent playSoundEvent = new PlaySoundEvent { _clipName = k_CollectSound };
        CollectedEvent collectedEvent = new CollectedEvent();

        GameVariables.Instance.AddCollectedCount(this);
        EventDispatcher.Raise(collectedEvent);
        EventDispatcher.Raise(playSoundEvent);

        Destroy(gameObject);
    }

    public void Click()
    {
        Interact();
        Database.SetCollectable(this);
    }
}
