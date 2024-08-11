using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    Dictionary<string, Sounds> m_soundDict = new();
    [SerializeField] List<Sounds> _soundList = new();
    void OnEnable()
    {
        EventDispatcher.AddListener<PlaySoundEvent>(Play);
    }
    void OnDisable()
    {
        EventDispatcher.RemoveListener<PlaySoundEvent>(Play);
    }
    void Start()
    {
        foreach (Sounds soundClips in _soundList)
        {
            m_soundDict.Add(soundClips.clipName, soundClips);

            soundClips.audioSource = gameObject.AddComponent<AudioSource>();
            soundClips.audioSource.clip = soundClips.audioClip;
            soundClips.audioSource.loop = soundClips.loop;
        }
    }
    private void Play(PlaySoundEvent evt)
    {
        Play(evt._clipName);
    }
    public void Play(string clipName)
    {
        if (!m_soundDict.ContainsKey(clipName))
        {
            Debug.LogError($"Could not find {clipName} in the database");
            return;
        }

        AudioSource source = m_soundDict[clipName].audioSource;
        if (source != null)
        {
            source.Play();
        }
    }

}
[System.Serializable]
public class Sounds
{
    public string clipName = string.Empty;
    public AudioClip audioClip = null;
    public bool loop = false;

    [HideInInspector] public AudioSource audioSource = null;
}