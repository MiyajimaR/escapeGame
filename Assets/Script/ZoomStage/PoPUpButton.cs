using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoPUpButton : MonoBehaviour
{
    [SerializeField]private RectTransform StartPos;
    [SerializeField]private RectTransform GoalPos;
    [SerializeField]private RectTransform PopUpTarget;

    [SerializeField]private Vector2 StartDelta;
    [SerializeField]private Vector2 TargetDelta;

    [SerializeField]private GameObject[] activeObj;
    [SerializeField]private GameObject[] notActiveObj;
    private bool nowPush = false;

    public void PopUpZoomButton()
    {
        if(nowPush)    return;
        nowPush = true;
        StartCoroutine("popUp");
    }
    public void PopCancelZoomButton()
    {
        if(nowPush)    return;
        nowPush = true;
        StartCoroutine("cancelPopup");
    }
    private IEnumerator popUp()
    {
        for(int i = 0; i < activeObj.Length; i++)
        {
            activeObj[i].SetActive(true);
        }

        float wid = StartDelta.x;
        float hei = StartDelta.y;

        var wait = new WaitForSeconds(0.03f);
        for(int i = 0; i < 4; i++)
        {
            wid += TargetDelta.x / 3f;
            hei += TargetDelta.y / 3f;

            if(TargetDelta.x <= wid)    wid = TargetDelta.x;
            if(TargetDelta.y <= hei)    hei = TargetDelta.y;

            PopUpTarget.sizeDelta = new Vector2(wid,hei);

            if(((i + 1) / 4f) <= 1f)
            {
                PopUpTarget.anchoredPosition = Vector3.Slerp(StartPos.anchoredPosition,GoalPos.anchoredPosition,i / 4f);
            }
            
            yield return wait;
        }
        PopUpTarget.sizeDelta = TargetDelta;
        PopUpTarget.anchoredPosition = GoalPos.anchoredPosition;
        nowPush = false;
    }
    private IEnumerator cancelPopup()
    {
        float wid = TargetDelta.x;
        float hei = TargetDelta.y;

        var wait = new WaitForSeconds(0.03f);

        for(int i = 0; i < 4; i++)
        {
            wid -= TargetDelta.x / 5f;
            hei -= TargetDelta.y / 5f;

            if(StartDelta.x >= wid)    wid = StartDelta.x;
            if(StartDelta.y >= hei)    hei = StartDelta.y;

            PopUpTarget.sizeDelta = new Vector2(wid,hei);

            if(((i + 1) / 4f) <= 1f)
            {
                PopUpTarget.anchoredPosition = Vector3.Slerp(GoalPos.anchoredPosition,StartPos.anchoredPosition,i / 4f);
            }
            yield return wait;
        }
        PopUpTarget.sizeDelta = StartDelta;
        PopUpTarget.anchoredPosition = StartPos.anchoredPosition;

        if(notActiveObj != null)
        {
            for(int i = 0; i < notActiveObj.Length; i++)
            {
                if(notActiveObj[i].activeSelf)
                {
                    notActiveObj[i].SetActive(false);
                }
            }
        }
        
        for(int i = 0; i < activeObj.Length; i++)
        {
            activeObj[i].SetActive(false);
        }
        nowPush = false;
    }
}
