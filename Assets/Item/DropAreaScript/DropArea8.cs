using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//パソコンの画面


[RequireComponent(typeof(DropArea))]
public class DropArea8 : MonoBehaviour
{
    private DropArea dropArea;
    [SerializeField]private Inventory inventory;
    [SerializeField]private ItemManager itemManager;
    [SerializeField]private TextMeshProUGUI textMesh;
    [SerializeField]private transition tran;
    [SerializeField]private GameObject pc;

    private void Start()
    {
        dropArea = GetComponent<DropArea>();
    }
    private void OnEnable()
    {
        textMesh.text = "PASSWORD?";
        StartCoroutine("textChange",textMesh);
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

            case 8:
                inventory.UseItem(8);
                textMesh.text = "LOGIN";
                StartCoroutine("textChange",textMesh);
                Invoke("tete",2f);
                break;
            
            default:
                Debug.Log("該当なし");
                break;
        }
    }
    private void tete()
    {
        tran.xTransitionButton(3);
        pc.SetActive(false);

    }
    IEnumerator textChange(TextMeshProUGUI TextMesh)
    {
        
        //一文字づつ増やす
        var wait = new WaitForSeconds(0.1f);

        for(int i = 0; i < TextMesh.text.Length; i++)
        {
            TextMesh.maxVisibleCharacters = i;
            yield return wait;
        }

        TextMesh.maxVisibleCharacters = TextMesh.text.Length;
    }   
}
