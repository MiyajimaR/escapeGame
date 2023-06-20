using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//面接時のPlayer  suit: 6,3  T-Shirt:7,3  HeartShirt:7,3  Hoodies: 6,6.5

[RequireComponent(typeof(DropArea))]
public class DropArea7 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private ItemManager itemManager;

    [SerializeField]private GameObject targetObj;
    private Image image;

    [SerializeField]private ItemData itemData;

    private void Start()
    {
        dropArea = GetComponent<DropArea>();
        image = targetObj.GetComponent<Image>();
    }

    void Update()
    {
        if(dropArea.Dropped)
        {
            dropArea.Dropped = false;
            ItemMethod();
        }
    }

    private void ItemMethod()
    {
        int ItemNum = dropArea.DroppedItemID;

        switch(ItemNum)
        {
            case 0:
                Debug.Log("アイテム０");
                break;

            case 11:
            case 12:
            case 13:
                ClothesMethod(ItemNum);
                break;

            case 14:
                ClothesMethod(ItemNum);
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }

    private void ClothesMethod(int ItemID)
    {
        if(!targetObj.activeSelf)
        {
            targetObj.SetActive(true);
        }
            
        if(ItemID == 11)
        {
            targetObj.transform.localScale = new Vector2(6,3);
        }
        else if(ItemID == 14)
        {
            targetObj.transform.localScale = new Vector2(6,6.5f);
        }
        else
        {
            targetObj.transform.localScale = new Vector2(7,3);
        }
            
        image.sprite = itemData.ItemDataList[ItemID].itemSprite;
    }
}
