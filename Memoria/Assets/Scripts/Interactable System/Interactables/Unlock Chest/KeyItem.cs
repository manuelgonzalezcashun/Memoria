using UnityEngine;

public class KeyItem : Interactable
{
    void Awake()
    {
        GameVariables.Instance.CheckIfCollected(this);
    }
    public override void Interact()
    {
        GameVariables.keyCount += 2;
        GameVariables.Instance.AddCollectedCount(this);
        EventDispatcher.Raise(new KeyCollectedEvent());
        Destroy(gameObject);
    }
}
