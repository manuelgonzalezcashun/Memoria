using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class UiManager : MonoBehaviour
{
    private List<Collectable> _collectables = new();
    public TMP_Text collectableTextUI = null;

    int score = 0;
    int count = 0;

    void OnEnable()
    {
        EventDispatcher.AddListener<CollectedEvent>(ctx => AddScore());
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<CollectedEvent>(ctx => AddScore());
    }
    void Start()
    {
        count = _collectables.Count;
        collectableTextUI.text = $"Memories Collected {score}/{count}";
    }

    void AddScore()
    {
        score++;
        collectableTextUI.text = $"Memories Collected {score}/{count}";

    }
}
