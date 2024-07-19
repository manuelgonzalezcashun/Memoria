using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] bool canPickup = false;

    public bool CanPickupInteractable => canPickup;
    public GameObject interactUI = null;


    void OnEnable()
    {
        InteractableManager.Instance.Add(this);
        EventDispatcher.AddListener<ShowInteractUI>(ShowUI);
    }
    void OnDisable()
    {
        InteractableManager.Instance.Remove(this);
        EventDispatcher.RemoveListener<ShowInteractUI>(ShowUI);
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
