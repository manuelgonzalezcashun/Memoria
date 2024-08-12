using UnityEngine;

public class KeyItem : Interactable
{
    void Awake()
    {
        GameVariables.Instance.CheckIfCollected(this);
    }
    public override void Interact()
    {
        GameVariables.Instance.AddKeyCount();
        GameVariables.Instance.AddCollectedCount(this);
        Destroy(gameObject);
    }
}
