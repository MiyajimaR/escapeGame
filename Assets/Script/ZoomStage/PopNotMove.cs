using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopNotMove : MonoBehaviour
{
    [SerializeField]private RectTransform PopUpTarget;

    [SerializeField]private Vector2 StartDelta;
    private Vector2 TargetDelta;

    [SerializeField]private GameObject activeObj;
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
        TargetDelta = PopUpTarget.sizeDelta;

        activeObj.SetActive(true);

        float wid = StartDelta.x;
        float hei = StartDelta.y;

        var wait = new WaitForSeconds(0.03f);
        for(int i = 0; i < 5; i++)
        {
            wid += TargetDelta.x / 5f;
            hei += TargetDelta.y / 5f;

            if(TargetDelta.x <= wid)    wid = TargetDelta.x;
            if(TargetDelta.y <= hei)    hei = TargetDelta.y;

            PopUpTarget.sizeDelta = new Vector2(wid,hei);
            yield return wait;
        }
        PopUpTarget.sizeDelta = TargetDelta;
        nowPush = false;
    }
    private IEnumerator cancelPopup()
    {
        TargetDelta = PopUpTarget.sizeDelta;
        float wid = TargetDelta.x;
        float hei = TargetDelta.y;

        var wait = new WaitForSeconds(0.03f);

        for(int i = 0; i < 5; i++)
        {
            wid -= TargetDelta.x / 5f;
            hei -= TargetDelta.y / 5f;

            if(StartDelta.x >= wid)    wid = StartDelta.x;
            if(StartDelta.y >= hei)    hei = StartDelta.y;

            PopUpTarget.sizeDelta = new Vector2(wid,hei);
            yield return wait;
        }
        PopUpTarget.sizeDelta = StartDelta;

        activeObj.SetActive(false);
        PopUpTarget.sizeDelta = TargetDelta;
        nowPush = false;
    }
}
