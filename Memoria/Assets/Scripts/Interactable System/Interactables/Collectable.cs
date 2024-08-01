using UnityEngine;

public class Collectable : Interactable, IDragable
{
    [SerializeField] DialogueDatabase database;
    [SerializeField] bool debugMode = false;

    private bool collectableClicked = false;
    private bool currentlyPlayingDialogue = false;
    private int currentIndex = 0;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex < database.DialogueLines.Count - 1)
            {
                currentIndex++;
                EventDispatcher.Raise(new ContinueDialogueEvent { dialogueLine = database.DialogueLines[currentIndex] });
            }
            else
            {
                currentlyPlayingDialogue = false;
                EventDispatcher.Raise(new ShowDialogueEvent { showDialogueUI = false });

                if (collectableClicked)
                {
                    ClickCollect();
                }
                else
                {
                    Collect();
                }
            }
        }

    }

    private void Collect()
    {
        EventDispatcher.Raise(new CollectedEvent());
        Destroy(gameObject);
    }
    private void ClickCollect()
    {
        EventDispatcher.Raise(new ClickCollectedEvent());
        Destroy(gameObject);
    }

    void Update()
    {
        StepThroughDialogue();
    }

    public void Click()
    {
        collectableClicked = true;
        Interact();
    }

    public void Drag()
    {
        return;
    }

    public void Release()
    {
        return;
    }
}
