using UnityEngine;

public class Thunder : MonoBehaviour
{
    // * Listens to Unity Animator Event for Lightning during Issac's Mindscape
    public void Crash()
    {
        ScreenShakeEvent screenShakeEvent = new ScreenShakeEvent();
        EventDispatcher.Raise(screenShakeEvent);
    }
}
