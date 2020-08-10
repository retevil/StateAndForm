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
    }

}
