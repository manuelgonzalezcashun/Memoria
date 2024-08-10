using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, Sounds> m_sfxClipDict = new(), m_musicClipDict = new();
    [SerializeField] List<Sounds> sfx_SoundList = new(), music_SoundList = new();

    private static AudioManager _instance = null;
    public static AudioManager Instance => _instance;

    void OnEnable()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }

        EventDispatcher.AddListener<PlaySoundEvent>(ctx => Play(ctx._clipName));
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<PlaySoundEvent>(ctx => Play(ctx._clipName));
    }

    void Awake()
    {
        foreach (Sounds sfxClips in sfx_SoundList)
        {
            sfxClips._audioSource = gameObject.AddComponent<AudioSource>();
            m_sfxClipDict.Add(sfxClips.clipName, sfxClips);
        }
        foreach (Sounds musicClips in music_SoundList)
        {
            musicClips._audioSource = gameObject.AddComponent<AudioSource>();
            m_musicClipDict.Add(musicClips.clipName, musicClips);
        }
    }
    public void Play(string clipName)
    {
        if (clipName == null) return;

        if (m_sfxClipDict.ContainsKey(clipName))
        {
            AudioSource source = m_sfxClipDict[clipName]._audioSource;
            source.clip = m_sfxClipDict[clipName].audioClip;
            source.Play();
        }
        else if (m_musicClipDict.ContainsKey(clipName))
        {
            AudioSource source = m_musicClipDict[clipName]._audioSource;
            source.clip = m_musicClipDict[clipName].audioClip;
            source.Play();
        }
        else
        {
            Debug.LogWarning($"Could not find {clipName} in the database");
        }
    }

}
[System.Serializable]
public class Sounds
{
    public string clipName = string.Empty;
    public AudioClip audioClip = null;

    [HideInInspector] public AudioSource _audioSource;
}