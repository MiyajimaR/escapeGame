using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(DropArea))]
public class ItemSlot : MonoBehaviour
{
    [HideInInspector]public bool nowItem = false;
    public int SlotID;

    private DropArea dropArea;
    [SerializeField]private Inventory inventory;

    private void Start()
    {
        dropArea = GetComponent<DropArea>();
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
        CancelInvoke("InitSlot");
        int ItemNum = dropArea.DroppedItemID; //ドロップ元のアイテムID

        int destinationItemID = -1;

        for(int i = 0; i < 5; i++)
        {
            if(GameManager.ItemManager[i] == ItemNum) //ドロップ元のアイテムスロットはinventory.itemslot[i]
            {
                inventory.itemSlot[i].nowItem = nowItem;
                nowItem = true;
                
                //GameManagerのアイテムIDの管理を交換する
                destinationItemID = GameManager.ItemManager[SlotID];
                GameManager.ItemManager[i] = destinationItemID;
                GameManager.ItemManager[SlotID] = ItemNum;

                destinationItemID = GameManager.ItemQuantity[SlotID];
                GameManager.ItemQuantity[SlotID] = GameManager.ItemQuantity[i];
                GameManager.ItemQuantity[i] = destinationItemID;

                inventory.itemSlotNumber[i].text = GameManager.ItemQuantity[i].ToString();
                inventory.itemSlotNumber[SlotID].text = GameManager.ItemQuantity[SlotID].ToString();

                if(GameManager.ItemQuantity[i] < 2)
                {
                    inventory.itemSlotNumber[i].gameObject.SetActive(false);
                }
                else if(GameManager.ItemQuantity[i] > 1)
                {
                    inventory.itemSlotNumber[i].gameObject.SetActive(true);
                }

                if(GameManager.ItemQuantity[SlotID] < 2)
                {
                    inventory.itemSlotNumber[SlotID].gameObject.SetActive(false);
                }
                else if(GameManager.ItemQuantity[SlotID] > 1)
                {
                    inventory.itemSlotNumber[SlotID].gameObject.SetActive(true);
                }

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
            if(inventory.itemSlot[i].transform.childCount > 2)
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

                inventory.itemSlotNumber[i].text = GameManager.ItemQuantity[i].ToString();

                if(GameManager.ItemQuantity[i] < 2)
                {
                    inventory.itemSlotNumber[i].gameObject.SetActive(false);
                }

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
                inventory.itemSlotNumber[i].text = "0";
                inventory.itemSlotNumber[i].gameObject.SetActive(false);
            }
        }
    }
}
