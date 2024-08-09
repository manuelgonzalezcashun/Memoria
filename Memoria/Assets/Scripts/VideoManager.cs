using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;
using System;

public class VideoManager : MonoBehaviour
{
    #region Initialized Variables
    private Dictionary<string, Comic> m_ComicDict = new();
    private VideoPlayer vp = null;
    #endregion

    #region Edited Variables
    [SerializeField] List<Comic> comics = new();
    [SerializeField] GameObject startGameButton = null;
    [SerializeField] bool itchBuild = false;
    #endregion

    #region Runtime Variables
    List<VideoClip> _comicVideos = new();
    int currentIndex = 0;
    bool autoPlayVideo = false;
    #endregion
    void Awake()
    {
        vp = GetComponent<VideoPlayer>();

        foreach (var comic in comics)
        {
            m_ComicDict.Add(comic.name, comic);
        }
    }
    void Start() => PlayVideo(GameVariables.Instance.ComicToLoad);
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayNextVideo();
        }
    }
    private void PlayVideo(VideoClip videoClip)
    {
        if (itchBuild)
        {
            vp.source = VideoSource.Url;
            vp.url = $"{Application.streamingAssetsPath}/{videoClip.name}.mp4";
        }
        else
        {
            vp.source = VideoSource.VideoClip;
            vp.clip = videoClip;
        }
        vp.Play();
    }
    private void PlayVideo(string comicName)
    {
        if (!m_ComicDict.ContainsKey(comicName))
        {
            Debug.LogError($"{comicName} does not exist in the database");
            return;
        }
        InitializeVideoList(comicName);
        VideoClip videoClip = _comicVideos[currentIndex];

        PlayVideo(videoClip);
    }
    private void PlayNextVideo()
    {
        currentIndex++;

        if (currentIndex >= _comicVideos.Count)
        {
            startGameButton.SetActive(true);
            return;
        }

        PlayVideo(_comicVideos[currentIndex]);
    }

    private void InitializeVideoList(string comicName)
    {
        if (_comicVideos == null || _comicVideos.Count <= 0)
        {
            _comicVideos = m_ComicDict[comicName].comicVideos;
        }
    }
    public void SetAutoPlayToggle(bool isAuto)
    {
        autoPlayVideo = isAuto;

        if (autoPlayVideo) vp.loopPointReached += ctx => PlayNextVideo();
    }
}

[Serializable]
public class Comic
{
    public string name = string.Empty;
    public List<VideoClip> comicVideos = new();
}