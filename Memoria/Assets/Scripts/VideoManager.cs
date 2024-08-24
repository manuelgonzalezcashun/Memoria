using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class VideoManager : MonoBehaviour
{
    #region Initialized Variables
    private Dictionary<string, Comic> m_ComicDict = new();
    private VideoPlayer vp = null;
    private InputAction pressedAction = null;
    #endregion

    #region Edited Variables
    [SerializeField] List<Comic> comics = new();
    [SerializeField] bool itchBuild = false;
    #endregion

    #region Runtime Variables
    Comic _currentComic = null;
    List<VideoClip> _comicVideos = new();
    int currentIndex = 0;
    bool autoPlayVideo = false;
    #endregion
    void Awake()
    {
        pressedAction = EventSystem.current.GetComponent<InputSystemUIInputModule>().actionsAsset["Submit"];
        vp = GetComponent<VideoPlayer>();

        // * Initializes Comic Dictionary from the list of comics using the comic name as the key
        foreach (var comic in comics)
        {
            m_ComicDict.Add(comic.name, comic);
        }
    }
    void Start() => PlayVideo(GameVariables.Instance.ComicToLoad);
    void Update()
    {
        // * When Space is pressed, play the next video in the dictionary 
        if (pressedAction.WasPerformedThisFrame())
        {
            PlayNextVideo();
        }
    }
    private void PlayVideo(VideoClip videoClip)
    {
        if (itchBuild) // * Changes the way videos are loaded for WebGL Builds
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

    // * Checks if comic video exists in Dictionary, then plays the video
    private void PlayVideo(string comicName)
    {
        if (!m_ComicDict.ContainsKey(comicName))
        {
            Debug.LogError($"{comicName} does not exist in the database");
            return;
        }

        _currentComic = m_ComicDict[comicName];
        InitializeVideoList(comicName);
        VideoClip videoClip = _comicVideos[currentIndex];

        PlayVideo(videoClip);
    }

    // * Plays next video in the list of comic videos
    private void PlayNextVideo()
    {
        currentIndex++;

        if (currentIndex >= _comicVideos.Count)
        {
            if (_currentComic._comicEvent != null)
            {
                _currentComic._comicEvent?.Invoke();
            }
            return;
        }

        PlayVideo(_comicVideos[currentIndex]);
    }

    // * Creates a list of comic videos from the dictionary
    private void InitializeVideoList(string comicName)
    {
        if (_comicVideos == null || _comicVideos.Count <= 0)
        {
            _comicVideos = m_ComicDict[comicName].comicVideos;
        }
    }

    // * Toggle for auto play videos
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
    public UnityEvent _comicEvent = null;
}