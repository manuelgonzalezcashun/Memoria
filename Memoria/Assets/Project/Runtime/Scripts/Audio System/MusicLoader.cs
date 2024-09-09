using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    [SerializeField] private string _songName = string.Empty;

    void Start()
    {
        if (_songName == string.Empty) return;

        EventDispatcher.Raise(new PlaySoundEvent { _clipName = _songName });
    }
    void OnDisable()
    {
        if (_songName == string.Empty) return;

        EventDispatcher.Raise(new StopSoundEvent { _clipName = _songName });
    }
}
