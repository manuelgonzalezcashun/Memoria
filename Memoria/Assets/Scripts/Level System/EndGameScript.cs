using Eflatun.SceneReference;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private SceneReference endScene;
    [SerializeField] private RoomConnection endConnection;
    public void InvokeEndGameEvent()
    {
        if (endScene == null) return;

        // !PuzzleWinEvent puzzleWinEvent = new PuzzleWinEvent();
        // !EventDispatcher.Raise(puzzleWinEvent);

        GameVariables.Instance.SetActiveRoomConnection(endConnection);

        LoadPuzzleEvent loadPuzzleEvent = new LoadPuzzleEvent { loaded = false };
        EventDispatcher.Raise(loadPuzzleEvent);

        LoadSceneEvent loadSceneEvent = new LoadSceneEvent { sceneToLoad = endScene.Name };
        EventDispatcher.Raise(loadSceneEvent);
    }
}
