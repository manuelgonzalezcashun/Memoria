using UnityEngine;

public class Thunder : MonoBehaviour
{
    public void Crash()
    {
        ScreenShakeEvent screenShakeEvent = new ScreenShakeEvent();
        EventDispatcher.Raise(screenShakeEvent);
    }
}
