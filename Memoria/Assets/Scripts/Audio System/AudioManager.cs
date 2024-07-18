using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, AudioClip> m_sfxClipDict = new(), m_musicClipDict = new();
    [SerializeField] List<Sounds> sfx_SoundList = new(), music_SoundList = new();
    AudioSource sfx_AudioSource = null, music_AudioSource = null;

    void OnEnable()
    {
        sfx_AudioSource = gameObject.AddComponent<AudioSource>();
        music_AudioSource = gameObject.AddComponent<AudioSource>();

        foreach (Sounds sfxClips in sfx_SoundList)
        {
            m_sfxClipDict.Add(sfxClips.clipName, sfxClips.audioClip);
        }
        foreach (Sounds musicClips in music_SoundList)
        {
            m_musicClipDict.Add(musicClips.clipName, musicClips.audioClip);
        }
    }

    public void Play(string clipName)
    {
        if (m_sfxClipDict.ContainsKey(clipName))
        {
            sfx_AudioSource.clip = m_sfxClipDict[clipName];
            sfx_AudioSource.Play();
        }
        else if (m_musicClipDict.ContainsKey(clipName))
        {
            music_AudioSource.clip = m_musicClipDict[clipName];
            music_AudioSource.Play();
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
}