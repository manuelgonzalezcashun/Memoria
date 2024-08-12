using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] bool canPickup = false;
    public bool CanPickupInteractable => canPickup;

    [SerializeField] DialogueDatabase database;
    public DialogueDatabase Database => database;

    public GameObject interactUI = null;
    protected void OnEnable()
    {
        InteractableManager.Instance.Add(this);
        EventDispatcher.AddListener<ShowInteractUI>(ShowUI);

        if (database != null) EventDispatcher.AddListener<DialoguePressedEvent>(database.StepThroughDialogue);
    }
    protected void OnDisable()
    {
        InteractableManager.Instance.Remove(this);
        EventDispatcher.RemoveListener<ShowInteractUI>(ShowUI);

        if (database != null) EventDispatcher.RemoveListener<DialoguePressedEvent>(database.StepThroughDialogue);
    }
    void ShowUI(ShowInteractUI evtData)
    {
        if (interactUI == null) return;

        evtData.showUI = false;

        if (evtData.interactable != null && evtData.interactable == this)
        {
            evtData.showUI = true;
        }

        interactUI.SetActive(evtData.showUI);
    }
    public abstract void Interact();
}
