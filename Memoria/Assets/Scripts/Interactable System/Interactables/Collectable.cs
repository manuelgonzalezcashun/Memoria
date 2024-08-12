using UnityEngine;

public class Collectable : Interactable, IClickable
{
    [SerializeField] DialogueDatabase database;
    [SerializeField] bool debugMode = false;

    private bool currentlyPlayingDialogue = false;
    private int currentIndex = 0;

    private const string k_CollectSound = "Collect";

    void Awake()
    {
        InputManager.Instance.DialogueAction.performed += ctx => StepThroughDialogue();
        GameVariables.Instance.CheckIfCollected(this);
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

        ShowDialogueEvent showDialogueEvent = new ShowDialogueEvent { showDialogueUI = true };
        ChangeActionMapEvent changeActionMapEvent = new ChangeActionMapEvent { newActionMap = "Dialogue" };
        ContinueDialogueEvent continueDialogueEvent = new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] };

        EventDispatcher.Raise(showDialogueEvent);
        EventDispatcher.Raise(changeActionMapEvent);
        EventDispatcher.Raise(continueDialogueEvent);
    }

    void StepThroughDialogue()
    {
        if (!currentlyPlayingDialogue) return;

        if (currentIndex < database.DialogueLines.Count - 1)
        {
            currentIndex++;

            ContinueDialogueEvent continueDialogueEvent = new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] };
            EventDispatcher.Raise(continueDialogueEvent);
        }
        else
        {
            currentlyPlayingDialogue = false;

            ShowDialogueEvent showDialogueEvent = new ShowDialogueEvent { showDialogueUI = false };
            EventDispatcher.Raise(showDialogueEvent);

            Collect();
        }
    }

    private void Collect()
    {
        PlaySoundEvent playSoundEvent = new PlaySoundEvent { _clipName = k_CollectSound };
        ChangeActionMapEvent changeActionMapEvent = new ChangeActionMapEvent { newActionMap = "Player" };
        CollectedEvent collectedEvent = new CollectedEvent();

        GameVariables.Instance.AddCollectedCount(this);
        EventDispatcher.Raise(collectedEvent);
        EventDispatcher.Raise(playSoundEvent);
        EventDispatcher.Raise(changeActionMapEvent);

        Destroy(gameObject);
    }

    public void Click()
    {
        Interact();
    }
}
