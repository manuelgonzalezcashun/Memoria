using UnityEngine;

public class Collectable : Interactable, IClickable
{
    [SerializeField] DialogueDatabase database;
    [SerializeField] bool debugMode = false;

    private bool currentlyPlayingDialogue = false;
    private int currentIndex = 0;

    void Awake()
    {
        GameVariables.Instance.CheckIfCollected(this);
        InputManager.Instance.DialogueAction.performed += ctx => StepThroughDialogue();
    }
    public override void Interact()
    {
        if (database == null && !debugMode)
        {
            Debug.LogWarning("This collectable doesn't have a database. Create a database and attach it to this collectable.");
            return;
        }
        else if (debugMode)
        {
            Collect();
            return;
        }

        currentlyPlayingDialogue = true;
        EventDispatcher.Raise(new ShowDialogueEvent { showDialogueUI = true });
        EventDispatcher.Raise(new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] });
    }

    void StepThroughDialogue()
    {
        if (!currentlyPlayingDialogue) return;

        if (currentIndex < database.DialogueLines.Count - 1)
        {
            currentIndex++;
            EventDispatcher.Raise(new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] });
        }
        else
        {
            currentlyPlayingDialogue = false;
            EventDispatcher.Raise(new ShowDialogueEvent { showDialogueUI = false });

            Collect();
        }
    }

    private void Collect()
    {
        GameVariables.Instance.AddCollectedCount(this);
        EventDispatcher.Raise(new CollectedEvent());
        Destroy(gameObject);
    }

    public void Click()
    {
        Interact();
    }
}
