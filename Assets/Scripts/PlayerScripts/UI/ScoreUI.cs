using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    public LevelManager levelManager;

    public RectTransform titleTransform;

    public GameObject taskInfoPrefab;

    private Dictionary<TaskEnum, Task> tasks;

    private float lastHeight;

    // Start is called before the first frame update
    void Start()
    {
        lastHeight = GetHeight(titleTransform) * -1; ;
        tasks = levelManager.GetDictionaryTasks();
        GenerateTasksUI(tasks);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateTasksUI(Dictionary<TaskEnum, Task> tasks)
    {
        foreach (TaskEnum task in tasks.Keys)
        {
            Task taskInfo;
            tasks.TryGetValue(task, out taskInfo);
            if (taskInfo != null)
            {
                GenerateTextComp(task, taskInfo);
            }

        }
    }

    private void GenerateTextComp(TaskEnum taskType, Task taskInfo)
    {

        GameObject uiText = Instantiate(taskInfoPrefab, gameObject.transform, false);
        RectTransform[] textTransformArr = uiText.GetComponentsInChildren<RectTransform>();

        if (textTransformArr.Length > 0)
        {
            RectTransform textTransform = textTransformArr[0];
            SetPosRelativeAnchors(textTransform);
            SetTexts(taskType, taskInfo, uiText);
            lastHeight = GetHeight(textTransformArr) * -1;
        }

    }

    private void SetTexts(TaskEnum taskType, Task taskInfo, GameObject uiText)
    {
        Text[] texts = uiText.GetComponentsInChildren<Text>();
        switch (taskType)
        {
            case TaskEnum.COLLECT_COINS:
                CollectCoinTask coinTaskInfo = taskInfo as CollectCoinTask;
                if (texts.Length > 0)
                {
                    texts[0].text = "Collect " + coinTaskInfo.coinNumber + " coins: ";
                    texts[1].text = coinTaskInfo.PlayerCoins + " / " + coinTaskInfo.coinNumber;
                }
                break;
            case TaskEnum.DEFEAT_ENEMIES:
                DefeatEnemiesTask defeatEnemiesTaskInfo = taskInfo as DefeatEnemiesTask;
                if (texts.Length > 0)
                {
                    texts[0].text = "Defeat " + defeatEnemiesTaskInfo.enemiesToDefeat + " enemies: ";
                    texts[1].text = defeatEnemiesTaskInfo.UserKills + " / " + defeatEnemiesTaskInfo.enemiesToDefeat;
                }
                break;
            case TaskEnum.TIME_ATTACK:
                TimeAttackTask timeAttackTaskInfo = taskInfo as TimeAttackTask;
                if (texts.Length > 0)
                {
                    texts[0].text = "Finish the level within " + timeAttackTaskInfo.timeLimit + " seconds: ";
                    texts[1].text = timeAttackTaskInfo.UserTime + " / " + timeAttackTaskInfo.timeLimit;
                }
                break;
            default:
                break;
        }
    }

    private float GetHeight(params RectTransform[] rectTransforms)
    {
        float finalHeight = 0f;
        foreach (RectTransform rectTransform in rectTransforms)
        {
            float height = rectTransform.rect.height;


            finalHeight += height;
        }
        float pos = Mathf.Abs(rectTransforms[0].anchoredPosition.y);
        return finalHeight + pos;
    }


    private void SetPosRelativeAnchors(RectTransform textTransform)
    {

        textTransform.anchorMin = new Vector2(1, 1);
        textTransform.anchorMax = new Vector2(1, 1);
        textTransform.pivot = new Vector2(0.5f, 0.5f);
        textTransform.anchoredPosition = new Vector2(-160, lastHeight);

    }
}
