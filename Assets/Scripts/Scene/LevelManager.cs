using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour
{
    
    public TaskEnum[] tasks;

    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(ShowCoinTaskParams))]
    public CollectCoinTask coinTask;

    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(ShowTimeAttackTaskParams))]
    public TimeAttackTask timeAttackTask;

    [ShowIf(ActionOnConditionFail.DontDraw, ConditionOperator.And, nameof(ShowDefeatEnemiesTaskParams))]
    public DefeatEnemiesTask defeatEnemiesTask;



    private bool canFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckCanFinish();
    } 

    public void PassLevel()
    {
        CheckCanFinish();
        if (canFinish == true)
        {
            Debug.Log("You passed the level");
        }else
        {
            Debug.Log("You need to finish your tasks");
        }
    }
    public Dictionary<TaskEnum, Task> GetDictionaryTasks()
    {
        Dictionary<TaskEnum, Task> taskDictionary = new Dictionary<TaskEnum, Task>();
        foreach (TaskEnum task in tasks)
        {
            switch (task)
            {
                case TaskEnum.COLLECT_COINS:
                    taskDictionary.Add(TaskEnum.COLLECT_COINS, coinTask);
                    break;
                case TaskEnum.DEFEAT_ENEMIES:
                    taskDictionary.Add(TaskEnum.DEFEAT_ENEMIES, defeatEnemiesTask);
                    break;
                case TaskEnum.TIME_ATTACK:
                    taskDictionary.Add(TaskEnum.TIME_ATTACK, timeAttackTask);
                    break;
                default:
                    break;
            }
        }
        return taskDictionary;
    }
    private void CheckCanFinish()
    {
        canFinish = true;
        if (tasks.Length != 0)
        {
            foreach (var task in tasks)
            {
               canFinish = CheckEachTask(task);
            }
        }

    }

    private bool CheckEachTask(TaskEnum task)
    {
        switch (task)
        {
            case TaskEnum.COLLECT_COINS:
                return coinTask.GetComplete();
            case TaskEnum.DEFEAT_ENEMIES:
                return defeatEnemiesTask.GetComplete();
            case TaskEnum.TIME_ATTACK:
                return timeAttackTask.GetComplete();
            default:
                return true;
        }
    }


    private bool ShowCoinTaskParams()
    {
        return GetActiveTask(TaskEnum.COLLECT_COINS);
    }
    private bool ShowTimeAttackTaskParams()
    {
        return GetActiveTask(TaskEnum.TIME_ATTACK); 
    }
    private bool ShowDefeatEnemiesTaskParams()
    {
        return GetActiveTask(TaskEnum.DEFEAT_ENEMIES);
    }
    private bool GetActiveTask(TaskEnum taskToCheck)
    {
        bool isTaskActive = false;
        foreach (var task in tasks)
        {
            if(task == taskToCheck)
            {
                isTaskActive = true;
            }
            
        }

        return isTaskActive;
    }



}
