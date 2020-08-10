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
    }
}
