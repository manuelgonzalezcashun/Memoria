using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class FinalCutscene : MonoBehaviour
{
    [SerializeField] UnityEvent endSceneEvent;
    private PlayableDirector director;
    private PlayerController player;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        player = FindObjectOfType<PlayerController>();
    }
    void OnEnable()
    {
        director.stopped += ctx => CutsceneEnded();
    }
    void OnDisable()
    {
        director.stopped -= ctx => CutsceneEnded();
    }

    public void Play()
    {
        Debug.Log("Hello Sy!");
        EventDispatcher.Raise(new ChangeActionMapEvent { newActionMap = "Disable" });
        director.Play();
    }

    void CutsceneEnded()
    {
        endSceneEvent?.Invoke();
    }
}
