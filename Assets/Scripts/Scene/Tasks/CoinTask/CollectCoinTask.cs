using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollectCoinTask : Task
{
    public int coinNumber;

    private int playerCoins;


    public int PlayerCoins { get => playerCoins; set => playerCoins = value; }
    public CollectCoinTask() : base(TaskEnum.COLLECT_COINS) { }
    public override void setComplete()
    {
        Complete = coinNumber == playerCoins;
        UpdateUIText();
    }

    public override void SetUIText()
    {

        string titleText = "Collect " + coinNumber + " coins: ";
        string bodyText = PlayerCoins + " / " + coinNumber;
        string completionText = "You have collected every coin";

        if (UITaskInfo != null)
        {
            UITaskInfo.SetTexts(titleText, bodyText, completionText);
        }

    }
    protected override void UpdateUIText()
    {
        if (Complete)
        {
            UITaskInfo.SetCompletionText();
        }
        else
        {
            UITaskInfo.bodyText = PlayerCoins + " / " + coinNumber;
            UITaskInfo.RefreshText();
        }

    }

}
