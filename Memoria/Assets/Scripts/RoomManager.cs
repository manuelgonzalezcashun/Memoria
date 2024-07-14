using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen = null;
    [SerializeField] string _roomToLoad = string.Empty;
    private string _currentRoom = string.Empty;
    private string _puzzleScene = "Puzzle Scene";
    void OnEnable()
    {
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => UnloadRoom());
        EventDispatcher.AddListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
        EventDispatcher.AddListener<LoadPuzzleEvent>(ctx => LoadRoom(_puzzleScene));
        DontDestroyOnLoad(this);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => UnloadRoom());
        EventDispatcher.RemoveListener<LoadPuzzleEvent>(ctx => LoadRoom(_puzzleScene));
        EventDispatcher.RemoveListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void Start()
    {
        if (_roomToLoad != string.Empty)
        {
            LoadRoom(_roomToLoad);
        }
    }
    void LoadRoom(string roomName)
    {
        if (_currentRoom != roomName)
        {
            SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
            _currentRoom = roomName;
        }
    }
    void UnloadRoom()
    {
        if (_currentRoom == string.Empty) return;

        SceneManager.UnloadSceneAsync(_currentRoom);
        _currentRoom = string.Empty;
    }
    IEnumerator LoadingScreen(string roomName)
    {
        UnloadRoom();
        AsyncOperation operation = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            yield return null;

            if (operation.isDone)
            {
                _currentRoom = roomName;
                loadingScreen.SetActive(false);
            }
        }

    }
}