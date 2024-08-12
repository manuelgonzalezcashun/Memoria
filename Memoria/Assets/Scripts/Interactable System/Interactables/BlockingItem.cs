public class BlockingItem : Interactable, IClickable
{
    public override void Interact()
    {
        RemoveItemEvent removeItemEvent = new();
        EventDispatcher.Raise(removeItemEvent);

        gameObject.SetActive(false);
    }
    public void Click()
    {
        Interact();
    }
}
