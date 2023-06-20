using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//カップ麺のズーム

[RequireComponent(typeof(DropArea))]
public class DropArea4 : MonoBehaviour
{
    private DropArea dropArea;
    private Inventory inventory;
    private ItemManager itemManager;
    private AdvEngineController adv;
    private GameObject roomManager;
    private GameObject steamObj = null;

    [SerializeField]private Sprite kettleImage,waterImage,steamImage;

    void Start()
    {
        if(inventory == null)    inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        if(dropArea == null)    dropArea = GetComponent<DropArea>();
        
        while(roomManager == null || itemManager == null || adv == null)
        {
            if(roomManager == null)    roomManager = GameObject.FindGameObjectWithTag("RoomManager");

            if(roomManager != null)
            {
                itemManager = roomManager.GetComponent<ItemManager>();
                adv = roomManager.GetComponent<AdvEngineController>();
            }
        }
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
                    Debug.Log("お湯が入っていない");
                }
                else if(!itemManager.Item6_boiled)
                {
                    Debug.Log("水を入れるわけにはいかない");
                }
                else if(itemManager.Item6_boiled)
                {
                   // Debug.Log("お湯を入れた");
                    
                    itemManager.Item0_inWater = true;
                    StartCoroutine("Drop6Item");
                }
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }
    
    private IEnumerator Drop6Item()
    {
        GameObject alphaPanel = GameObject.Find("StoryPanel").transform.GetChild(1).gameObject;
        alphaPanel.SetActive(true);

        AlphaController alphaController = roomManager.GetComponent<AlphaController>();

        Image kettle = Instantiate(gameObject,transform.position,Quaternion.identity,inventory.ItemZoomPanel.transform).GetComponent<Image>();
        kettle.sprite = kettleImage;
        kettle.GetComponent<DropArea4>().enabled = false;
        RectTransform kettleRect = kettle.gameObject.GetComponent<RectTransform>();
        kettleRect.anchoredPosition = new Vector2(350f,500f);
        kettleRect.sizeDelta = new Vector2(550f,450f);
        kettle.color = new Color(1f,1f,1f,0f);
        alphaController.alphaStart(kettle);

        yield return new WaitForSeconds(0.5f);
        var wait = new WaitForSeconds(0.1f);
        for(int i = 1; i < 10; i++)
        {
            kettleRect.Rotate(0f,0f,i);
            yield return wait;
        }

        Image water = Instantiate(gameObject,transform.position,Quaternion.identity,inventory.ItemZoomPanel.transform).GetComponent<Image>();
        water.sprite = waterImage;
        water.GetComponent<DropArea4>().enabled = false;
        RectTransform waterRect = water.gameObject.GetComponent<RectTransform>();
        water.color = new Color(0.4f,1f,1f,0f);
        waterRect.sizeDelta = new Vector2(40f,210f);

        waterRect.anchoredPosition = new Vector2(140f,270f);
        alphaController.alphaStart(water);

        yield return new WaitForSeconds(1f);

        alphaController.alphaEnd(water);

        yield return new WaitForSeconds(0.5f);

        for(int i = 1; i < 10; i++)
        {
            kettleRect.Rotate(0f,0f,-i);
            yield return wait;
        }
        yield return new WaitForSeconds(0.5f);
        alphaController.alphaEnd(kettle);
        Destroy(water.gameObject);
        water = null;
        waterRect = null;

        steamObj = Instantiate(gameObject,transform.position,Quaternion.identity,inventory.ItemZoomPanel.transform);
        Image steam = steamObj.GetComponent<Image>();
        steam.sprite = steamImage;
        steam.GetComponent<DropArea4>().enabled = false;
        RectTransform steamRect = steam.gameObject.GetComponent<RectTransform>();
        steamRect.anchoredPosition = new Vector2(0f,550f);
        steam.color = new Color(1f,1f,1f,0f);
        alphaController.alphaStart(steam);

        yield return new WaitForSeconds(1f);
        Destroy(kettle.gameObject);
        kettle = null;
        kettleRect = null;

        alphaPanel.SetActive(false);

        adv.JumpScenario("Drop4_1");
    }
    private void OnDisable()
    {
        if(steamObj != null)
        {
            Destroy(steamObj);
            steamObj = null;
        }
            
    }
}