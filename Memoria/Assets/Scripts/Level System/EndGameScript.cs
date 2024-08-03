using Eflatun.SceneReference;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private SceneReference endScene;
    public void InvokeEndGameEvent()
    {
        EventDispatcher.Raise(new PuzzleWinEvent { endSceneName = endScene.Name });
    }
}
