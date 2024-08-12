using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Database", menuName = "Dialogue System / Create new Dialogue Database")]

public class DialogueDatabase : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private List<string> dialogueLines = new();
    private bool currentlyPlayingDialogue = false;
    public bool CurrentlyPlayingDialogue => currentlyPlayingDialogue;
    private int currentIndex = 0;
    private Collectable _collectable = null;

    public void SetCollectable(Collectable collectable)
    {
        if (_collectable == null)
        {
            _collectable = collectable;
        }
    }
    public void LoadDialogue()
    {
        currentlyPlayingDialogue = true;

        ShowDialogueEvent showDialogueEvent = new ShowDialogueEvent { showDialogueUI = true };
        ChangeActionMapEvent changeActionMapEvent = new ChangeActionMapEvent { newActionMap = "Dialogue" };
        ContinueDialogueEvent continueDialogueEvent = new ContinueDialogueEvent { dialogueLine = dialogueLines[currentIndex] };

        EventDispatcher.Raise(showDialogueEvent);
        EventDispatcher.Raise(changeActionMapEvent);
        EventDispatcher.Raise(continueDialogueEvent);
    }
    public void StepThroughDialogue(DialoguePressedEvent evt) => StepThroughDialogue();
    void StepThroughDialogue()
    {
        if (!currentlyPlayingDialogue) return;

        if (currentIndex < dialogueLines.Count - 1)
        {
            currentIndex++;

            ContinueDialogueEvent continueDialogueEvent = new ContinueDialogueEvent { dialogueLine = dialogueLines[currentIndex] };
            EventDispatcher.Raise(continueDialogueEvent);
        }
        else
        {
            currentlyPlayingDialogue = false;
            ShowDialogueEvent showDialogueEvent = new ShowDialogueEvent { showDialogueUI = false };
            ChangeActionMapEvent changeActionMapEvent = new ChangeActionMapEvent { newActionMap = "Player" };

            EventDispatcher.Raise(showDialogueEvent);
            EventDispatcher.Raise(changeActionMapEvent);
            CollectItem();
        }
    }

    void CollectItem()
    {
        if (_collectable == null) return;

        _collectable.Collect();
        _collectable = null;
    }
}
