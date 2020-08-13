using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class DefeatEnemiesTask : Task
{
    public int enemiesToDefeat;

    private int userKills;

    public int UserKills { get => userKills; set => userKills = value; }

    public DefeatEnemiesTask() : base(TaskEnum.DEFEAT_ENEMIES) { }

    public override void setComplete()
    {
        Complete = enemiesToDefeat == UserKills;
        UpdateUIText();
    }

    public override void SetUIText()
    {

        string titleText = "Defeat " + enemiesToDefeat + " enemies: ";
        string bodyText = UserKills + " / " + enemiesToDefeat;
        string completionText = "You have defeated every enemy";
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
            UITaskInfo.bodyText = UserKills + " / " + enemiesToDefeat;
            UITaskInfo.RefreshText();
        }

    }

}
