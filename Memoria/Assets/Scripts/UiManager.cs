using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour
{
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
        count = InteractableManager.Instance.Interactables.Count;
        collectableTextUI.text = $"Memories Collected {score}/{count}";
    }

    void AddScore()
    {
        score++;
        collectableTextUI.text = $"Memories Collected {score}/{count}";
    }
}
