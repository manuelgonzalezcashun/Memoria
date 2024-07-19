using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

public class VideoManager : MonoBehaviour
{
    #region Initialized Variables
    private Dictionary<string, VideoClip> m_ComicDict = new();
    private VideoPlayer vp = null;
    #endregion

    #region Edited Variables
    [SerializeField] List<ComicVideos> comicVideos = new();
    [SerializeField] GameObject button = null;
    #endregion

    #region Runtime Variables
    int currentIndex = 0;
    #endregion
    void OnEnable()
    {
        vp = GetComponent<VideoPlayer>();

        foreach (var clips in comicVideos)
        {
            m_ComicDict.Add(clips.name, clips.videoClip);
        }
    }
    void Start()
    {
        PlayVideo(currentIndex);
    }
    public void PlayVideo(string clipName)
    {
        Debug.Log($"We are at {currentIndex}: {clipName}");

        if (!m_ComicDict.ContainsKey(clipName))
        {
            Debug.LogWarning($"{clipName} does not exist in the database");
            return;
        }

        vp.clip = m_ComicDict[clipName];
        vp.Play();

        vp.loopPointReached += ctx => PlayNextVideo();
    }
    private void PlayVideo(int index)
    {
        PlayVideo(comicVideos[index].name);
    }
    private void PlayNextVideo()
    {
        currentIndex++;

        if (currentIndex < comicVideos.Count)
        {
            PlayVideo(currentIndex);
        }
        else if (currentIndex > comicVideos.Count)
        {
            button.SetActive(true);
        }
    }


}

[System.Serializable]
public class ComicVideos
{
    public string name = string.Empty;
    public VideoClip videoClip = null;
}
