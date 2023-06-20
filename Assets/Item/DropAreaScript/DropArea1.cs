using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//teddyBear

[RequireComponent(typeof(DropArea))]
[RequireComponent(typeof(ImageCheck))]
public class DropArea1 : MonoBehaviour
{
    private DropArea dropArea;
    private ImageCheck imagecheck;
    [SerializeField]private Inventory inventory;
    [SerializeField]private GameObject roomManager;
    private ItemManager itemManager;
    private StoryManager storyManager;
    private AdvEngineController advController;

    private void Start()
    {
        dropArea = GetComponent<DropArea>();
        imagecheck = GetComponent<ImageCheck>();
        itemManager = roomManager.GetComponent<ItemManager>();
        storyManager = roomManager.GetComponent<StoryManager>();
        advController = roomManager.GetComponent<AdvEngineController>();
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
                if(itemManager.Item0_inWater)
                {
                    //Debug.Log("クマにカップ麺を食べさせた");
                    advController.JumpScenario("Drop1_3");
                    inventory.UseItem(0);
                    storyManager.Story1();
                }
                else if(!itemManager.Item0_inWater)
                {
                    //Debug.Log("お湯ぐらい入れてくれよ");
                    advController.JumpScenario("Drop1_4");
                }
                break;

            default :
                Debug.Log("DropArea1の該当なし");
                break;
        }
    }

    //人形を押した時のボタン
    public void TeddyBearButton()
    {
        imagecheck.imageCheck();

        if(imagecheck.Check_changeImage[0])
        {
          // 布団とってくれてありがと、食べ物持ってきてくれない？
            advController.JumpScenario("Drop1_1");
        }
        else
        {
            //Debug.Log("暑いぜ");
            advController.JumpScenario("Drop1_2");
        }
    }
}


/*Template

[RequireComponent(typeof(DropArea))]
public class DropArea2 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private ItemManager itemManager;

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
        int ItemNum = dropArea.DroppedItemID;

        switch(ItemNum)
        {
            case 0:
                Debug.Log("アイテム０");
                break;

            case 6:
                if(!itemManager.Item6_inWater)
                {
                    itemManager.Item6_inWater = true;
                    Debug.Log("水を入れた"); 
                }
                else if(itemManager.Item6_inWater)
                {
                    Debug.Log("すでに水が入っている");
                }
                else
                {
                    Debug.Log("すでに水が入っている");
                }
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }
}

*/
