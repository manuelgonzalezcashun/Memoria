using Ink.Runtime;
public class InkDialogueObserver
{
    private bool _saveState = false;
    public void ObserveInkVariables(Story story)
    {
        _saveState = (bool)story.variablesState["saveState"];

        story.ObserveVariable("saveState", (arg, value) =>
        {
            _saveState = (bool)value;
        });
    }
}
