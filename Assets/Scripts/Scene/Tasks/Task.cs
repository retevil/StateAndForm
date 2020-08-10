using UnityEngine;

[System.Serializable]
public abstract class Task 
{
    private TaskEnum taskType;
    public TaskEnum TaskType { get => taskType; private set => taskType = value; }

    protected bool Complete { get; set; }

    protected Task(TaskEnum taskType)
    {
        TaskType = taskType;
    }

    public abstract void setComplete();

    public bool GetComplete()
    {
        return Complete;
    }
}
