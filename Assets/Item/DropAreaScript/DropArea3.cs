using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//コンロ

[RequireComponent(typeof(DropArea))]
public class DropArea3 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private GameObject roomManager;
    private ItemManager itemManager;
    private AlphaController alphaController; 
    private AdvEngineController adv;

    [SerializeField]private Image kettleImage;
    [SerializeField]private Image fireImage;
    [SerializeField]private Image steamImage;

    [SerializeField]private GameObject alphaPanel;
    [SerializeField]private GameObject ItemGetPanel;
    [SerializeField]private Sprite kettleSprite;
    [SerializeField]private Image ItemImage;
    [SerializeField]private GameObject steamObject;

    void Start()
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
                if(itemManager.Item6_inWater && !itemManager.Item6_boiled)
                {
                    //お湯を沸かした
                    alphaPanel.SetActive(true);
                    itemManager.Item6_boiled = true;
                    StartCoroutine("Drop6Item");
                }
                else if(itemManager.Item6_boiled)
                {
                    //すでにお湯は沸いている
                    adv.JumpScenario("Drop3_2");
                }
                else
                {
                    //まずは水を入れよう
                    adv.JumpScenario("Drop3_3");
                }
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }
    private IEnumerator Drop6Item()
    {
        kettleImage.color = new Color(1f,1f,1f,0f);
        fireImage.color = new Color(1f,1f,1f,0f);

        steamObject.SetActive(false);
        kettleImage.gameObject.SetActive(true);
        fireImage.gameObject.SetActive(true);

        alphaController.alphaStart(kettleImage);
        alphaController.alphaStart(fireImage);

        yield return new WaitForSeconds(2f);

        steamImage.color = new Color(1f,1f,1f,0f);
        steamImage.gameObject.SetActive(true);

        alphaController.alphaStart(steamImage);

        yield return new WaitForSeconds(2f);
        alphaPanel.SetActive(false);

        adv.JumpScenario("Drop3_1");
        ItemGetPanel.SetActive(true);
        ItemImage.sprite = kettleSprite;
        RectTransform rect = ItemGetPanel.GetComponent<RectTransform>();
        GameObject obj = Instantiate(steamObject,rect.anchoredPosition,Quaternion.identity,ItemGetPanel.transform);
        RectTransform ima = obj.GetComponent<RectTransform>();
        ima.anchoredPosition = new Vector2(-300f,400f);
        ima.sizeDelta = new Vector2(300f,500f);

        steamObject.SetActive(false);
        kettleImage.gameObject.SetActive(false);
        fireImage.gameObject.SetActive(false);

        var wait = new WaitForSeconds(0.5f);
        
        while(obj != null)
        {
            if(!ItemGetPanel.activeSelf)
            {
                Destroy(obj);
                obj = null;
                yield break;
            }
            yield return wait;
        }
    }
}
