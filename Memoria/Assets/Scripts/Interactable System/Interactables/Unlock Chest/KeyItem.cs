using UnityEngine;

public class KeyItem : Interactable
{
    public override void Interact()
    {
        GameVariables.keyCount += 2;
        EventDispatcher.Raise(new KeyCollectedEvent());
        Destroy(gameObject);
    }
}
