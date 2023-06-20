using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DropArea))]
public class TrashPlace : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private ItemData itemData;
    [SerializeField]private GameObject TrashObj;

    private Image image;
    private bool Cleaned = false;
    private int ItemNum = -1;
    private bool notButton = false;

    void Start()
    {
        dropArea = GetComponent<DropArea>();
        image = TrashObj.GetComponent<Image>();
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

