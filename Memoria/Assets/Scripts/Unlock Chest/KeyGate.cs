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
        if (GameVariables.keyCount > 0)
        {
            GameVariables.keyCount--;

            Destroy(gameObject);
            puzzlepiece.SetActive(true);
        }

    }
}
