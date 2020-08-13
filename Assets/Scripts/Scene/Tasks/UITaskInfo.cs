using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITaskInfo : MonoBehaviour
{
    public string titleText;
    public string bodyText;
    public string completionText;


    private RectTransform RT;
    private Text[] texts;



    private void Start()
    {
        RT = GetComponent<RectTransform>();
        texts = GetComponentsInChildren<Text>();

        if (titleText != null)
        {
            SetTitleText(titleText);
        }
        if (bodyText != null)
        {
            SetBodyText(bodyText);
        }

    }
    public void SetTexts(string title, string body, string completion)
    {
        titleText = title;
        bodyText = body;
        completionText = completion;

    }
    public float GetNextPositionUnder()
    {
        if (RT == null)
        {
            RT = GetComponent<RectTransform>();
        }
        float yPos = Mathf.Abs(RT.anchoredPosition.y);

        float height = RT.rect.height;

        return yPos + height;
    }

    public void RefreshText()
    {
        SetTitleText(titleText);
        SetBodyText(bodyText);

    }

    public void SetCompletionText()
    {
        SetBodyText(completionText);
    }

    public void SetPosRelativeAnchors(float x, float y)
    {
        if (RT == null)
        {
            RT = GetComponent<RectTransform>();
        }
        RT.anchorMin = new Vector2(1, 1);
        RT.anchorMax = new Vector2(1, 1);
        RT.pivot = new Vector2(0.5f, 0.5f);
        RT.anchoredPosition = new Vector2(x, y);

    }
    private void SetTitleText(string text)
    {
        if (texts != null && texts.Length > 0)
        {
            texts[0].text = text;
        }
    }

    private void SetBodyText(string text)
    {
        if (texts != null && texts.Length > 0)
        {
            texts[1].text = text;
        }
    }





}
