using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class UiManager : MonoBehaviour
{
    private List<Collectable> _collectables = new();
    [SerializeField] private Canvas UICanvas = null;
    [SerializeField] TMP_Text collectableTextUI = null;

    int score = 0;
    int count = 0;

    void OnEnable()
    {
        // TODO EventDispatcher.AddListener<CollectedEvent>(ctx => AddScore());
        EventDispatcher.AddListener<LoadSceneEvent>(ctx => EnableUI(false));
        EventDispatcher.AddListener<PuzzleWinEvent>(ctx => EnableUI(true));
    }
    void OnDisable()
    {
        //TODO EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddScore());
        EventDispatcher.RemoveListener<LoadSceneEvent>(ctx => EnableUI(false));
        EventDispatcher.RemoveListener<PuzzleWinEvent>(ctx => EnableUI(true));
    }
    // void Start()
    // {
    //     count = _collectables.Count;
    //     collectableTextUI.text = $"Memories Collected {score}/{count}";
    // }

    // void AddScore()
    // {
    //     score++;
    //     collectableTextUI.text = $"Memories Collected {score}/{count}";
    // }

    void EnableUI(bool enable)
    {
        UICanvas.gameObject.SetActive(enable);
    }
}
