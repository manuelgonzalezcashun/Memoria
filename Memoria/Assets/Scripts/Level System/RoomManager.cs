using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen = null;
    [SerializeField] SceneReference _roomToLoad = null;
    [SerializeField] private float _loadingTime = 3.0f;

    private string _currentRoom = string.Empty;
    void OnEnable()
    {
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => StartCoroutine(LoadingScreen(ctx.endSceneName)));
        EventDispatcher.AddListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => StartCoroutine(LoadingScreen(ctx.endSceneName)));
        EventDispatcher.RemoveListener<LoadRoomEvent>(ctx => StartCoroutine(LoadingScreen(ctx.roomName)));
    }
    void Start()
    {
        if (_roomToLoad != null)
        {
            LoadRoom(_roomToLoad.Name);
        }
    }
    void LoadRoom(string roomName)
    {
        if (_currentRoom != roomName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);
            _currentRoom = roomName;
        }
    }
    void UnloadCurrentRoom()
    {
        if (_currentRoom == string.Empty) return;

        SceneManager.UnloadSceneAsync(_currentRoom);
        _currentRoom = string.Empty;
    }
    void UnloadRoom(string roomName)
    {
        SceneManager.UnloadSceneAsync(roomName);
    }
    IEnumerator LoadingScreen(string roomName)
    {
        UnloadCurrentRoom();
        loadingScreen.SetActive(true);
        EventDispatcher.Raise(new SceneLoadingEvent { isSceneLoading = true });
        LoadRoom(roomName);

        yield return new WaitForSeconds(_loadingTime);

        loadingScreen.SetActive(false);
        EventDispatcher.Raise(new SceneLoadingEvent { isSceneLoading = false });
    }
    // Method to find the Gameplay camera and modify it only in Backyard scene, return to normal otherwise
    void AdjustCamera(string roomName)
    {
        Scene gameplayScene = SceneManager.GetSceneByName("Gameplay");
        Scene backyardScene = SceneManager.GetSceneByName("Backyard");

        if (gameplayScene.isLoaded)
        {
            GameObject gameplayCamera = GameObject.FindWithTag("MainCamera");
            Camera mainCamera = gameplayCamera.GetComponent<Camera>();
            CameraFollow cameraFollow = gameplayCamera.GetComponent<CameraFollow>();
            if (roomName == "Backyard" && mainCamera)
            {
                mainCamera.orthographicSize = 12f;
                cameraFollow.xLimit = new Vector2(-28f, 29.3f);
            }
            else if (roomName == "LivingRoom")
            {
                mainCamera.orthographicSize = 5.31f;
            }
            else
            {
                mainCamera.orthographicSize = 7f;
                cameraFollow.xLimit = new Vector2(-37f, 37f);
            }

        }

    }
}