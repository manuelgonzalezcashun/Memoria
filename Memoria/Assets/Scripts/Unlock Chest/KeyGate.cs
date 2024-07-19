using UnityEngine;

public class KeyGate : Interactable
{
    [SerializeField] GameObject puzzlepiece;
    public override void Interact()
    {
        GameVariables.keyCount--;

        Destroy(gameObject);
        puzzlepiece.SetActive(true);
    }
}
