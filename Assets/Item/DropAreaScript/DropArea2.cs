using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//水道

[RequireComponent(typeof(DropArea))]
public class DropArea2 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private GameObject roomManager;
    private ItemManager itemManager;
    private AlphaController alphaController;
    private AdvEngineController adv;

    [SerializeField]private GameObject WaterImage, KettleImage;
    [SerializeField]private GameObject alphaPanel;

    [SerializeField]private GameObject ItemGetPanel;
    [SerializeField]private Sprite KettleSprite;
    [SerializeField]private Image ItemImage;

    private void Start()
    {
        dropArea = GetComponent<DropArea>();
        itemManager = roomManager.GetComponent<ItemManager>();
        alphaController = roomManager.GetComponent<AlphaController>();
        adv = roomManager.GetComponent<AdvEngineController>();
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
                    //水を入れた
                    alphaPanel.SetActive(true);
                    StartCoroutine("Drop6Item");
                }
                else
                {
                    //すでに水が入っている
                    adv.JumpScenario("Drop2_2");
                }
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }
    private IEnumerator Drop6Item() //ヤカンに水を入れる演出
    {
        itemManager.Item6_inWater = true;
        WaterImage.SetActive(true);

        Image waterImage = WaterImage.GetComponent<Image>();
        Image kettleImage = KettleImage.GetComponent<Image>();

        //透明から徐々にヤカンとみずが現れる
        kettleImage.color = new Color(1,1,1,0);
        waterImage.color = new Color(waterImage.color.r,1,1,0);
        alphaController.alphaStart(waterImage);
        alphaController.alphaStart(kettleImage);   

        yield return new WaitForSeconds(3f);

        alphaPanel.SetActive(false);

        adv.JumpScenario("Drop2_1");
        ItemGetPanel.SetActive(true);
        ItemImage.sprite = KettleSprite;
        WaterImage.SetActive(false);
        KettleImage.SetActive(false);
    }
}

