using UnityEngine;

public class KeyItem : Interactable
{
    public override void Interact()
    {
        GameVariables.keyCount += 2;
        Destroy(gameObject);
    }
}
