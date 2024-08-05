using UnityEngine;

public class ComicLoader : MonoBehaviour
{
    [SerializeField] string comicToLoad = string.Empty;

    public void LoadVideoComic()
    {
        if (comicToLoad == string.Empty || comicToLoad == null)
        {
            Debug.LogError($"{comicToLoad} is invalid!");
            return;
        }

        GameVariables.Instance.SetComicToLoad(comicToLoad);
    }
}
