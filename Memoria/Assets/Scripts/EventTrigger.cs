using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : Interactable
{
    public UnityEvent _event = null;
    public override void Interact()
    {
        _event?.Invoke();
    }
}
