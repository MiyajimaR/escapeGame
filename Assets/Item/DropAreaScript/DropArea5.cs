using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//ゴミの代わりの置く場所
[RequireComponent(typeof(DropArea))]
public class DropArea5 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private ItemData itemData;
    [SerializeField]private GameObject TrashObj;

    private Image image;
    private bool Cleaned = false;
    private bool notButton = false;
    public int ItemNum = -1; //InterviewStartで使います

    void Start()
    {
        dropArea = GetComponent<DropArea>();
        image = TrashObj.GetComponent<Image>();

        if(ItemNum != -1)
        {
            image.sprite = itemData.ItemDataList[ItemNum].itemSprite;
        }
    }

    void Update()
    {
        if(dropArea.Dropped)
        {
            dropArea.Dropped = false;

            if(!Cleaned)
                return;

            ItemMethod();
        }
    }
    private void ItemMethod()
    {
        ItemNum = dropArea.DroppedItemID;
        notButton = false;
        image.color = new Color(1f,1f,1f,1f);
        inventory.UseItem(ItemNum);
        image.sprite = itemData.ItemDataList[ItemNum].itemSprite;

        /*switch(ItemNum)
        {
            case 0:
                Debug.Log("アイテム０");
                break;

            case 6:
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }*/
    }

    public void NewItemButton()
    {
        if(notButton)
            return;

        if(!Cleaned)
        {
            image.color = new Color(1f,1f,1f,0f);
            Cleaned = true;
            notButton = true;
            Debug.Log("掃除をした。代わりにここに何か置けそうだ");
        }
        else
        {
            inventory.GetItem(ItemNum);
            notButton = true;
            image.color = new Color(1f,1f,1f,0f);
        }
    }
}
