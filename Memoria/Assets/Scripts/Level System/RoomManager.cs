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
        EventDispatcher.AddListener<LoadSceneEvent>(LoadScreen);
        EventDispatcher.AddListener<LoadVideoComics>(LoadVideoScene);

    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<LoadSceneEvent>(LoadScreen);
        EventDispatcher.RemoveListener<LoadVideoComics>(LoadVideoScene);
    }
    void Start()
    {
        if (_roomToLoad == null) return;

        LoadRoom(_roomToLoad.Name);
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
    void LoadScreen(LoadSceneEvent evt)
    {
        if (loadingScreen == null) return;
        StartCoroutine(PlayLoadingScreen(evt.sceneToLoad));
    }
    IEnumerator PlayLoadingScreen(string roomName)
    {

        UnloadCurrentRoom();
        loadingScreen.SetActive(true);

        EventDispatcher.Raise(new ChangeActionMapEvent { newActionMap = "Disable" });
        LoadRoom(roomName);

        yield return new WaitForSeconds(_loadingTime);

        loadingScreen.SetActive(false);
        EventDispatcher.Raise(new ChangeActionMapEvent { newActionMap = "Player" });
    }
    void LoadVideoScene(LoadVideoComics evt)
    {
        SceneManager.LoadScene("Video Scene", LoadSceneMode.Additive);
    }
}