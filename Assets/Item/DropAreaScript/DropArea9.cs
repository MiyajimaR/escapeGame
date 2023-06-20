using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DropArea))]
public class DropArea9 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private ItemManager itemManager;
    [SerializeField]private AlphaController alController;
    [SerializeField]private GameObject alphaPanel;
    [SerializeField]private GameObject inkitChenLock;

    [SerializeField]private GameObject lockObj;
    [SerializeField]private GameObject[] chein;
    [SerializeField]private Image Spanner,Spanner2;
    [SerializeField]private Mystery2 mystery2;

    private void Start()
    {
        dropArea = GetComponent<DropArea>();

        if(mystery2.firstUse)
        {
            Spanner.gameObject.SetActive(true);
            Spanner2.gameObject.SetActive(false);
        }
        else
        {
            Spanner.gameObject.SetActive(false);
            Spanner2.gameObject.SetActive(false);
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
                break;

            case 8:

                if(!mystery2.firstUse)
                {
                    mystery2.firstUse = true;
                    inventory.UseItem(8);
                    Spanner.gameObject.SetActive(true);
                }
                else
                {
                    Spanner2.gameObject.SetActive(true);
                    alphaPanel.SetActive(true);
                    mystery2.openLock = true;
                    inventory.UseItem(8);
                    StartCoroutine("breakLock");
                }
                break;
                
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }

    IEnumerator breakLock()
    {
        var wait = new WaitForSeconds(0.04f);

        alController.alphaEnd(Spanner);
        alController.alphaEnd(Spanner2);

        float speed = 2f;

        for(int i = 0; i < 20; i++)
        {
            chein[0].transform.Rotate(0f,0f,30);
            Vector2 pos = chein[0].transform.position;
            pos.x += speed * Time.deltaTime;
            pos.y += speed * Time.deltaTime;
            chein[0].transform.position = pos;

            chein[1].transform.Rotate(0f,0f,30);
            Vector2 pos1 = chein[1].transform.position;
            pos.x += speed * Time.deltaTime;
            pos.y -= speed * Time.deltaTime;
            chein[1].transform.position = pos;

            chein[2].transform.Rotate(0f,0f,30);
            Vector2 pos2 = chein[2].transform.position;
            pos.x -= speed * Time.deltaTime;
            pos.y += speed * Time.deltaTime;
            chein[2].transform.position = pos;

            chein[3].transform.Rotate(0f,0f,30);
            Vector2 pos3 = chein[3].transform.position;
            pos.x -= speed * Time.deltaTime;
            pos.y -= speed * Time.deltaTime;
            chein[3].transform.position = pos;


            Vector2 Lockpos = lockObj.transform.position;
            Lockpos.y -= 2 * Time.deltaTime;
            lockObj.transform.position = Lockpos;

            yield return wait;
        }
        
        Destroy(lockObj);
        for(int i = 0; i < chein.Length; i++)
        {
            Destroy(chein[i]);
            chein[i] = null;
        }
        Destroy(Spanner.gameObject);
        Destroy(Spanner2.gameObject);
        Destroy(inkitChenLock);
        inkitChenLock = null;
        lockObj = null;

        Spanner = null;
        Spanner2 = null;
        alphaPanel.SetActive(false);
    }
}
