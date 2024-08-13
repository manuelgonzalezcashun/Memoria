using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] bool canPickup = false;
    public bool CanPickupInteractable => canPickup;

    private DialogueLoader dialogueLoader = null;
    public DialogueLoader DialogueLoader => dialogueLoader;
    public GameObject interactUI = null;
    protected void OnEnable()
    {
        InteractableManager.Instance.Add(this);
        EventDispatcher.AddListener<ShowInteractUI>(ShowUI);
    }
    protected void OnDisable()
    {
        InteractableManager.Instance.Remove(this);
        EventDispatcher.RemoveListener<ShowInteractUI>(ShowUI);
    }
    void Awake()
    {
        TryGetComponent(out dialogueLoader);
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
