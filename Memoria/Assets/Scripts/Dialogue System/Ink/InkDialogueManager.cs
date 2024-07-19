using UnityEngine;
using Ink.Runtime;

public class InkDialogueManager
{
    #region Singleton Data
    private static InkDialogueManager _instance = null;
    public static InkDialogueManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }
    }
    #endregion
    Story _inkStory = null;
    private string sentence = string.Empty;
    private string _loadedState = string.Empty;


    private InkDialogueObserver observer = new();
    private InkExternalFunctions inkExternalFunctions = new();
    private InkTagHandler tagHandler = new();

    public void LoadStory(TextAsset storyJSON)
    {
        _inkStory = new Story(storyJSON.text);

        observer.ObserveInkVariables(_inkStory);
        //TODO inkExternalFunctions.Bind(_inkStory);
    }
    public void DisplayNextLine()
    {
        if (_inkStory.canContinue)
        {
            sentence = _inkStory.Continue();
            EventDispatcher.Raise(new ContinueDialogueEvent { dialogueLine = sentence });
        }
        else if (!_inkStory.canContinue)
        {
            EndStory();
        }

        //TODO tagHandler.HandleTags(_inkStory.currentTags);
    }
    private void EndStory()
    {
        _inkStory = null;
        sentence = string.Empty;

        EventDispatcher.Raise(new ShowDialogueEvent { showDialogueUI = false });
        //TODO inkExternalFunctions.Unbind(_inkStory);
    }
}
