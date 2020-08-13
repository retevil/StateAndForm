using UnityEngine;

[System.Serializable]
public abstract class Task
{
    private TaskEnum taskType;
    public TaskEnum TaskType { get => taskType; private set => taskType = value; }

    private UITaskInfo uITaskInfo;
    public UITaskInfo UITaskInfo { get => uITaskInfo; set => uITaskInfo = value; }

    protected bool Complete { get; set; }


    protected Task(TaskEnum taskType)
    {
        TaskType = taskType;
    }

    public abstract void setComplete();

    public abstract void SetUIText();

    protected abstract void UpdateUIText();
    public bool GetComplete()
    {
        return Complete;
    }
}
