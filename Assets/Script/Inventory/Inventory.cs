using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [HideInInspector]public ItemData itemDataManager;
    public ItemSlot[] itemSlot = new ItemSlot[5];
    public TextMeshProUGUI[] itemSlotNumber = new TextMeshProUGUI[5];
    [System.NonSerialized]public GameObject[] ItemSlotChild = new GameObject[5]; 

    //このクラスではなく、ItemZoomScriptで使用
    public GameObject ItemZoomPanel;
    private GameObject ItemZoomChild;
    
    [HideInInspector][SerializeField]private GameObject ItemGetPanel;
    [HideInInspector][SerializeField]private Image ItemImage;
    [SerializeField]private AdvEngineController advEngineController;

    private GameObject ItemObj;
    private Sprite ItemSprite;

    public int ItemZoomScriptNumber = -1;
    private RectTransform rect;

    void Start()
    {
        
        ItemImage = ItemImage.GetComponent<Image>();
        ItemZoomChild = ItemZoomPanel.transform.GetChild(1).gameObject;
        rect = ItemZoomChild.GetComponent<RectTransform>();

        //ここから初期化
        for(int i = 0; i < 5; i++)
        {
            if(GameManager.ItemManager[i] != -1)
            {
                itemSlot[i].nowItem = true;
                ItemObj = itemDataManager.ItemDataList[GameManager.ItemManager[i]].ObjPrefab;

                itemSlotNumber[i].text = GameManager.ItemQuantity[i].ToString();

                if(GameManager.ItemQuantity[i] < 2)
                {
                    itemSlotNumber[i].gameObject.SetActive(false);
                }

                Transform parent = itemSlot[i].transform;
                ItemSlotChild[i] = Instantiate(ItemObj,itemSlot[i].transform.position,Quaternion.identity,parent);
                ItemSlotChild[i].transform.SetAsFirstSibling();
                
            }
            else //何も持っていなくても数字をリセットしておく
            {
                itemSlotNumber[i].text = "0";
                itemSlotNumber[i].gameObject.SetActive(false);
            }
        }
    }

    public void GetItem(int ItemID)
    {
        for(int i = 0; i < 5; i++)
        {
            if(itemSlot[i].nowItem)
            {
                if(GameManager.ItemManager[i] == ItemID)
                {
                    GameManager.ItemQuantity[i] += 1;

                    if(GameManager.ItemQuantity[i] > 1)
                    {
                        if(!itemSlotNumber[i].gameObject.activeSelf)
                        {
                            itemSlotNumber[i].gameObject.SetActive(true);
                        }

                        itemSlotNumber[i].text = GameManager.ItemQuantity[i].ToString();
                    }
                    
                    return;
                }
            }
        }
        for(int i = 0; i < 5; i++)
        {
            if(!itemSlot[i].nowItem)
            {
                itemSlot[i].nowItem = true;

                for(int ii = 0; ii < itemDataManager.ItemDataList.Count; ii++)
                {
                    if(itemDataManager.ItemDataList[ii].id == ItemID)
                    {
                        ItemObj = itemDataManager.ItemDataList[ii].ObjPrefab;
                        ItemSprite = itemDataManager.ItemDataList[ii].itemSprite;
                        GameManager.ItemManager[i] = ItemID;
                        GameManager.ItemQuantity[i] += 1;
                        itemSlotNumber[i].gameObject.SetActive(false);
              //          GameManager.GotItemManager[ItemID] = true;

                        //宴の表示

                        string UtageParam = itemDataManager.ItemDataList[ii].name;
                        advEngineController.UtageStringParam(UtageParam);
                        advEngineController.JumpScenario("GetItemWindow");
                        
                        
                        break;
                    }
                }

                //ゲットした時のパネル
                ItemGetPanel.SetActive(true);
                ItemImage.sprite = ItemSprite;
                
                Transform parent = itemSlot[i].transform;
                ItemSlotChild[i] = Instantiate(ItemObj,itemSlot[i].transform.position,Quaternion.identity,parent);
                ItemSlotChild[i].transform.SetAsFirstSibling();
                break;
            }
        }
    }
    public void UseItem(int ItemID)
    {
        for(int i = 0; i < 5; i++)
        {
            if(GameManager.ItemManager[i] == ItemID)
            {
                GameManager.ItemQuantity[i] -= 1;

                if(GameManager.ItemQuantity[i] == 0)
                {
                    itemSlot[i].nowItem = false;
                    Destroy(ItemSlotChild[i]);
                    ItemSlotChild[i] = null;
                    GameManager.ItemManager[i] = -1;
                
                    break;
                }
                else
                {
                    if(GameManager.ItemQuantity[i] < 2)
                    {
                        itemSlotNumber[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        itemSlotNumber[i].text = GameManager.ItemQuantity[i].ToString();
                    }
                    break;
                }
            }
        }
    }

    public void cancelZoomButton()
    {
        if(ItemZoomChild.transform.childCount == 0)
        {
            return;
        }
        
        Destroy(ItemZoomChild.transform.GetChild(0).gameObject);

        for(int i = 0; i < GameManager.ItemManager.Length; i++)
        {
            if(GameManager.ItemManager[i] == ItemZoomScriptNumber)
            {
                StartCoroutine("CancelZoomButton",i);
                break;
            }
        }
    }
    IEnumerator CancelZoomButton(int objNum)
    {
        Vector2 oldPos = ItemZoomPanel.transform.position; //元の場所を保存
        Vector2 oldDelta = rect.sizeDelta;

        rect.sizeDelta = new Vector2(800f,1000f);
        float rex = 800f;
        float rey = 1000f;

        float SlerpNow = 0f;
        var wait = new WaitForSeconds(0.03f);
        while(SlerpNow <= 1)
        {
            SlerpNow += 0.4f;
            ItemZoomPanel.transform.position = Vector3.Slerp(oldPos,itemSlot[objNum].transform.position,SlerpNow);

            rex -= 320; //80
            rey -= 400;  //100
            
            rect.sizeDelta = new Vector2(rex,rey);

            yield return wait;
        }

        ItemZoomPanel.transform.position = oldPos;
        rect.sizeDelta = oldDelta;

        ItemZoomPanel.SetActive(false);
    }
}
