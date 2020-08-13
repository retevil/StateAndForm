using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUI : MonoBehaviour
{
    public LevelManager levelManager;

    public RectTransform titleTransform;

    public GameObject taskInfoPrefab;

    public Animation winAnimation;

    private Dictionary<TaskEnum, Task> tasks;

    private float lastHeight;

    // Start is called before the first frame update
    void Start()
    {
        lastHeight = GetHeight(titleTransform) * -1; ;
        tasks = levelManager.GetDictionaryTasks();
        GenerateTasksUI(tasks);
    }

    private void OnEnable()
    {
        LevelManager.OnWin += OnLevelPass;
    }
    private void OnDisable()
    {
        LevelManager.OnWin -= OnLevelPass;
    }

    private void OnLevelPass()
    {
        if (winAnimation)
        {
            winAnimation.Play(); Debug.Log("you passed the level from the UI");
        }


    }

    private void GenerateTasksUI(Dictionary<TaskEnum, Task> tasks)
    {
        if (tasks != null && tasks.Count > 0)
        {
            foreach (TaskEnum task in tasks.Keys)
            {
                Task taskInfo;
                tasks.TryGetValue(task, out taskInfo);
                if (taskInfo != null)
                {
                    GenerateTextComp(taskInfo);
                }

            }
        }
        else
        {
            this.titleTransform.gameObject.SetActive(false);
        }

    }
    private void GenerateTextComp(Task taskInfo)
    {
        GameObject uiText = Instantiate(taskInfoPrefab, gameObject.transform, false);
        taskInfo.UITaskInfo = uiText.GetComponent<UITaskInfo>();

        if (taskInfo.UITaskInfo)
        {
            taskInfo.UITaskInfo.SetPosRelativeAnchors(-160, lastHeight);
            taskInfo.SetUIText();
            lastHeight = taskInfo.UITaskInfo.GetNextPositionUnder() * -1;
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
}
