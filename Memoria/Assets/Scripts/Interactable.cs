using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
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
        interactUI.SetActive(evtData.showUI);
    }

    public abstract void Interact();
}
