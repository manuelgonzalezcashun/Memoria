using UnityEngine;

public class Collectable : Interactable
{
    public override void Interact()
    {
        Debug.Log($"Collected {name}");

        Destroy(gameObject);
    }
}
