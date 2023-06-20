using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemZoomScript : MonoBehaviour
{
    private bool DoubleTap = false;

    private Inventory inventory;

    private Transform parent = null;
    private RectTransform rect = null;
    private GameObject obj = null;
    private bool nowTap = false;

    public void OnTap(int ItemID)
    {
        if(inventory == null || parent == null || rect == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            parent = inventory.ItemZoomPanel.transform.GetChild(1);
            rect = inventory.ItemZoomPanel.transform.GetChild(1).GetComponent<RectTransform>();
        }
        if(inventory.ItemZoomPanel.transform.GetChild(1).childCount != 0 || nowTap)
        {
            return;
        }

        if(!DoubleTap)
        {
            DoubleTap = true;
            Invoke("Seconds",0.5f);
        }
        else if(DoubleTap)
        {
            nowTap = true;
            DoubleTap = false;
            CancelInvoke();
            inventory.ItemZoomPanel.SetActive(true);
            for(int i = 0; i < inventory.itemDataManager.ItemDataList.Count; i++)
            {
                if(i == ItemID)
                {   
                    inventory.ItemZoomScriptNumber = i;
                    obj = inventory.itemDataManager.ItemDataList[i].zoomObject;
                    StartCoroutine("ItemZoomStaging",ItemID);
                    break;
                }
            }
        }
    }
    private void Seconds()
    {
        DoubleTap = false;
    }
    private IEnumerator ItemZoomStaging(int ItemID)
    {
        Vector2 oldPos = inventory.ItemZoomPanel.transform.position; //元の場所を保存
        Vector2 oldDelta = rect.sizeDelta;

        inventory.ItemZoomPanel.transform.position = gameObject.transform.position;
        rect.sizeDelta = new Vector2(0f,0f);
        float rex = 0f;
        float rey = 0f;

        float SlerpNow = 0f;
        var wait = new WaitForSeconds(0.03f);
        while( SlerpNow <= 1)
        {
            SlerpNow += 0.4f;
            inventory.ItemZoomPanel.transform.position = Vector3.Slerp(gameObject.transform.position,oldPos,SlerpNow);

            rex += 160;
            rey += 200;

            rect.sizeDelta = new Vector2(rex,rey);

            yield return wait;
        }

        inventory.ItemZoomPanel.transform.position = oldPos;
        rect.sizeDelta = oldDelta;

        Instantiate(obj,inventory.ItemZoomPanel.transform.position,Quaternion.identity,parent);
        nowTap = false;
    }
}
