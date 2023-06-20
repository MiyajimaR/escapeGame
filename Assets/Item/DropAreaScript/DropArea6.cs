using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ベランダの木、同時に窓に映る木のボタン管理の関数も入っている
[RequireComponent(typeof(DropArea))]
public class DropArea6 : MonoBehaviour
{
    public Sprite NormalWood;
    [SerializeField]private Image WindowImage;
    [SerializeField]private Image InterviewImage;

    private Image sr;

    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    private ItemManager itemManager;

    void Start()
    {
        dropArea = GetComponent<DropArea>();
        sr = GetComponent<Image>();
        itemManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<ItemManager>();
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

            case 5:
                if(itemManager.Item5_inWater)
                {
                    Debug.Log("水を上げた");
                    itemManager.Item5_inWater = false;
                    GameManager.DropArea6_LivingWood = true;
                    sr.sprite = NormalWood;
                    WindowImage.sprite = NormalWood;
                    InterviewImage.sprite = NormalWood;
                }
                else
                {
                    Debug.Log("水が入っていない");
                }
                break;

            case 6:
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }

    public void DropArea6Button()
    {
        if(GameManager.DropArea6_LivingWood)
        {
            Debug.Log("生き生きとした木が生えている");
        }
        else
        {
            Debug.Log("最近水を上げていなかったから枯れてきている");
        }
    }
    public void WindowWoodButton()
    {
        if(GameManager.DropArea6_LivingWood)
        {
            Debug.Log("生き生きとした木が生えている");
        }
        else
        {
            Debug.Log("ベランダの木が透けて見える。枯れかかっている");
        }
    }
}
