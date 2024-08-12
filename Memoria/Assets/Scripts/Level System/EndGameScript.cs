using Eflatun.SceneReference;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private SceneReference endScene;
    public void InvokeEndGameEvent()
    {
        if (endScene == null) return;

        // !PuzzleWinEvent puzzleWinEvent = new PuzzleWinEvent();
        // !EventDispatcher.Raise(puzzleWinEvent);

        LoadPuzzleEvent loadPuzzleEvent = new LoadPuzzleEvent { loaded = false };
        EventDispatcher.Raise(loadPuzzleEvent);

        LoadSceneEvent loadSceneEvent = new LoadSceneEvent { sceneToLoad = endScene.Name };
        EventDispatcher.Raise(loadSceneEvent);
    }
}
