using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    [SerializeField] DialogueDatabase database;
    public DialogueDatabase Database => database;

    private Collectable _currentCollectable = null;
    private int currentIndex = 0;
    private bool currentlyPlayingDialogue = false;

    void OnEnable()
    {
        if (database == null) return;

        EventDispatcher.AddListener<DialoguePressedEvent>(StepThroughDialogue);
    }
    void OnDisable()
    {
        if (database == null) return;

        EventDispatcher.RemoveListener<DialoguePressedEvent>(StepThroughDialogue);
    }
    public void SetCollectable(Collectable collectable)
    {
        _currentCollectable = collectable;
    }
    public void LoadDialogue()
    {
        currentlyPlayingDialogue = true;

        ShowDialogueEvent showDialogueEvent = new ShowDialogueEvent { showDialogueUI = true };
        ChangeActionMapEvent changeActionMapEvent = new ChangeActionMapEvent { newActionMap = "Dialogue" };
        ContinueDialogueEvent continueDialogueEvent = new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] };

        EventDispatcher.Raise(showDialogueEvent);
        EventDispatcher.Raise(changeActionMapEvent);
        EventDispatcher.Raise(continueDialogueEvent);
    }
    public void StepThroughDialogue(DialoguePressedEvent evt) => StepThroughDialogue();
    void StepThroughDialogue()
    {
        if (!currentlyPlayingDialogue) return;

        if (currentIndex < Database.DialogueLines.Count - 1)
        {
            currentIndex++;

            ContinueDialogueEvent continueDialogueEvent = new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] };
            EventDispatcher.Raise(continueDialogueEvent);
        }
        else
        {
            currentlyPlayingDialogue = false;
            ShowDialogueEvent showDialogueEvent = new ShowDialogueEvent { showDialogueUI = false };
            ChangeActionMapEvent changeActionMapEvent = new ChangeActionMapEvent { newActionMap = "Player" };

            EventDispatcher.Raise(showDialogueEvent);
            EventDispatcher.Raise(changeActionMapEvent);

            if (_currentCollectable != null)
            {
                _currentCollectable.Collect();
                _currentCollectable = null;
            }
        }
    }

}
