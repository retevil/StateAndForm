using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeAttackTask : Task
{
    public float timeLimit;
    public float UserTime { get => userTime; set => userTime = value; }
    private float userTime;


    public TimeAttackTask() : base(TaskEnum.TIME_ATTACK) { }

    public override void setComplete()
    {
        Complete = UserTime <= timeLimit;
        UpdateUIText();
    }

    public override void SetUIText()
    {

        string titleText = "Finish the level within " + timeLimit + " seconds: ";
        string bodyText = UserTime + " / " + timeLimit;
        string completionText = "You have finished the level within the time";

        UITaskInfo.SetTexts(titleText, bodyText, completionText);
    }
    protected override void UpdateUIText()
    {
        if (Complete)
        {
            UITaskInfo.SetCompletionText();
        }
        else
        {
            UITaskInfo.bodyText = UserTime + " / " + timeLimit;
            UITaskInfo.RefreshText();
        }

    }
}
