using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : DropArea
{
    [HideInInspector]public bool nowItem = false;
    public int SlotID;

    [SerializeField]private Inventory inventory;

    protected override void dropMethod(int droppedItemID)
    {
        CancelInvoke("InitSlot");

        int destinationItemID = -1;

        for(int i = 0; i < 5; i++)
        {
            if(GameManager.ItemManager[i] == droppedItemID) //ドロップ元のアイテムスロットはinventory.itemslot[i]
            {
                inventory.itemSlot[i].nowItem = nowItem;
                nowItem = true;
                
                //GameManagerのアイテムIDの管理を交換する
                destinationItemID = GameManager.ItemManager[SlotID];
                GameManager.ItemManager[i] = destinationItemID;
                GameManager.ItemManager[SlotID] = droppedItemID;

                Destroy(inventory.ItemSlotChild[i]);
                inventory.ItemSlotChild[i] = null;

                if(GameManager.ItemManager[i] != -1) //ドロップ先にアイテムがあった場合
                {
                    //アイテムスロットに所属するオブジェクトの破壊と生成
                    Destroy(transform.GetChild(0).gameObject);
                }

                GameObject ItemObj = inventory.itemDataManager.ItemDataList[GameManager.ItemManager[SlotID]].ObjPrefab;
                Transform parent = inventory.itemSlot[SlotID].transform;
                inventory.ItemSlotChild[SlotID] = Instantiate(ItemObj,inventory.itemSlot[SlotID].transform.position,Quaternion.identity,parent);
                inventory.ItemSlotChild[SlotID].transform.SetAsFirstSibling();

                if(GameManager.ItemManager[i] != -1) //ドロップ先にアイテムがあった場合
                {
                    ItemObj = inventory.itemDataManager.ItemDataList[GameManager.ItemManager[i]].ObjPrefab;
                    parent = inventory.itemSlot[i].transform;
                    inventory.ItemSlotChild[i] = Instantiate(ItemObj,inventory.itemSlot[i].transform.position,Quaternion.identity,parent);
                    inventory.ItemSlotChild[i].transform.SetAsFirstSibling();
                }
                Invoke("InitSlot",0.1f);
                break;
            }
        }
    }
    private void InitSlot()
    {
        for(int i = 0; i < 5; i++)
        {
            if(inventory.itemSlot[i].transform.childCount > 1)
            {
                Debug.Log("ItemSlotにてアイテム重複を消すため初期化しました");
                DoInit();
                break;
            }
        }
    }

    private void DoInit()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject obj = inventory.itemSlot[i].gameObject;
            for(int ii = 0; ii < inventory.itemSlot[i].transform.childCount - 1; ii++)
            {
                if(ii != -1)
                {
                    GameObject child = obj.transform.GetChild(ii).gameObject;
                    Destroy(child);
                }
            }
        }
        for(int i = 0; i < 5; i++)
        {
            if(GameManager.ItemManager[i] != -1)
            {
                inventory.itemSlot[i].nowItem = true;
                GameObject ItemObj = inventory.itemDataManager.ItemDataList[GameManager.ItemManager[i]].ObjPrefab;

                Transform parent = inventory.itemSlot[i].transform;
                inventory.ItemSlotChild[i] = Instantiate(ItemObj,inventory.itemSlot[i].transform.position,Quaternion.identity,parent);
                inventory.ItemSlotChild[i].transform.SetAsFirstSibling();
            }
            else //何も持っていなくても数字をリセットしておく
            {
                if(inventory.ItemSlotChild[i] != null)
                {
                    Destroy(inventory.ItemSlotChild[i]);
                    inventory.ItemSlotChild[i] = null;
                }
            }
        }
    }
}
