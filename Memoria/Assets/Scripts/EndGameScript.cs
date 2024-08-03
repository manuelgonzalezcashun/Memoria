using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public void InvokeEndGameEvent()
    {
        //! EventDispatcher.Raise(new SpawnDoor());
        EventDispatcher.Raise(new PuzzleWinEvent());
    }
}
