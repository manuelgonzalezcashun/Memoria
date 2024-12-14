using System.Collections.Generic;
using UnityEngine;
public class InteractableManager
{
    private List<Interactable> _interactables = new List<Interactable>();
    private Interactable _closestInteractable = null;
    public Interactable ClosestInteractable => _closestInteractable;
    public void SearchForNearestInteractable(Vector3 interactPosition, float interactDistance)
    {
        float closestDistance = interactDistance;
        _closestInteractable = null;
        EventDispatcher.Raise(new ShowInteractUI { showUI = false, interactable = null });

        foreach (Interactable interactable in _interactables)
        {
            float distance = Vector3.Distance(interactable.transform.position, interactPosition);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                _closestInteractable = interactable;

                EventDispatcher.Raise(new ShowInteractUI { showUI = true, interactable = _closestInteractable });
            }
        }
    }
    public void PickupInteractable()
    {
        if (_closestInteractable != null &&
        _closestInteractable.CanPickupInteractable)
        {
            _closestInteractable.Interact();
        }
    }
    public void InteractWithObjects()
    {
        if (_closestInteractable == null) return;

        _closestInteractable.Interact();
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
