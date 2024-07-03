using System.Collections.Generic;
using UnityEngine;
public class InteractableManager
{
    private List<Interactable> _interactables = new List<Interactable>();
    private Interactable closestInteractable = null;

    public void SearchForNearestInteractable(Vector3 interactPosition, float interactDistance)
    {
        float closestDistance = interactDistance;
        closestInteractable = null;
        EventDispatcher.Raise(new ShowInteractUI { showUI = false, interactable = null });

        foreach (Interactable interactable in _interactables)
        {
            float distance = Vector3.Distance(interactable.transform.position, interactPosition);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestInteractable = interactable;

                EventDispatcher.Raise(new ShowInteractUI { showUI = true, interactable = closestInteractable });
            }
        }
    }
    public void PickupInteractable()
    {
        if (closestInteractable != null &&
        closestInteractable.CanPickupInteractable)
        {
            closestInteractable.Interact();
        }
    }
    public void InteractWithObjects()
    {
        if (closestInteractable == null) return;

        closestInteractable.Interact();
    }

    public void Add(Interactable interactable)
    {
        _interactables.Add(interactable);
    }
    public void Remove(Interactable interactable)
    {
        _interactables.Remove(interactable);
    }

    #region Instance
    private static InteractableManager _instance;
    public static InteractableManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new InteractableManager();

            return _instance;
        }
    }
    #endregion
}
