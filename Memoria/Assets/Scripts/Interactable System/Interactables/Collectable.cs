using UnityEngine;

public class Collectable : Interactable, IClickable
{
    private const string k_CollectSound = "Collect";
    void Start()
    {
        GameVariables.Instance.CheckIfCollected(this);
    }
    public override void Interact()
    {
        if (DialogueLoader != null)
        {
            DialogueLoader.SetCollectable(this);
            DialogueLoader.LoadDialogue();
            return;
        }

        Collect();
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
    }
}
