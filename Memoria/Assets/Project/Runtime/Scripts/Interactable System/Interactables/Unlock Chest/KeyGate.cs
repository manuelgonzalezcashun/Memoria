using UnityEngine;

public class KeyGate : Interactable
{
    [SerializeField] GameObject puzzlepiece;

    void Start()
    {
        if (puzzlepiece == null) return;

        puzzlepiece.SetActive(false);
    }
    public override void Interact()
    {
        if (GameVariables.Instance.KeysCollected < 1)
        {
            base.Interact();
            return;
        }

        GameVariables.Instance.SubtractKeyCount();
        gameObject.SetActive(false);
        puzzlepiece.SetActive(true);
    }
}
