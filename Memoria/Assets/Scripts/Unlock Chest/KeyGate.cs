using UnityEngine;

public class KeyGate : Interactable
{
    [SerializeField] GameObject puzzlepiece;
    public override void Interact()
    {
        if (GameVariables.keyCount > 0)
        {
            GameVariables.keyCount--;

            Destroy(gameObject);
            puzzlepiece.SetActive(true);
        }

    }
}
