using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Singleton Data
    private static CameraManager _instance;
    public static CameraManager Instance => _instance;

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
    }
    void OnDisable()
    {
        _instance = null;
    }
    #endregion
    Dictionary<string, Camera> m_camerasDict = new();
    List<Camera> cameras = new();
    string _currentCam = string.Empty, _defaultCam = string.Empty;
    public string DefaultCamera => _defaultCam;
    public void Add(Camera cam)
    {
        if (cameras.Count < 1)
        {
            _defaultCam = cam.name;
        }

        cameras.Add(cam);

        if (!m_camerasDict.ContainsKey(cam.name))
            m_camerasDict.Add(cam.name, cam);
        else
            m_camerasDict[cam.name] = cam;
    }
    public void Remove(Camera cam)
    {
        cameras.Remove(cam);
    }
    public void SetCamera(string camName)
    {
        if (cameras.Count < 1) return;

        _currentCam = camName;

        foreach (Camera camera in cameras)
        {
            if (camera.name != _currentCam)
            {
                camera.gameObject.SetActive(false);
            }
        }

        m_camerasDict[_currentCam].gameObject.SetActive(true);
    }
}
