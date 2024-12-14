using UnityEngine;

public class DialogueTrigger : Interactable
{
    [SerializeField] TextAsset storyJSON;
    public override void Interact()
    {
        InkDialogueManager.Instance.LoadStory(storyJSON);
        EventDispatcher.Raise(new ShowDialogueEvent { showDialogueUI = true });
    }
}
