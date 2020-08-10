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
    }
}
