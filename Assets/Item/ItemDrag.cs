using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private bool goPre = false;
    private Image image;
    public int ItemNumber;
    private Inventory inventory;
    private int inventoryNum;

    public void OnBeginDrag(PointerEventData eventData)
    {
     //   goPre = false;
        image.raycastTarget = false;

        for(int i = 0; i < 5; i++)
        {
            if(GameManager.ItemManager[i] == ItemNumber) //現在ItemNumberのアイテムを所持しているスロットはi
            {
                inventoryNum = i;
                inventory.itemSlot[i].transform.SetAsLastSibling();
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint (eventData.position);
		TargetPos.z = 0;
		transform.position = TargetPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ドラッグ前の位置に戻す
        goPre = true;

        for(int i = 0; i < 5; i++)
        {
            inventory.itemSlot[i].transform.SetSiblingIndex(i);
        }
    }
    private void Start()
    {
        image = GetComponent<Image>();
        inventory = GetComponentInParent<Inventory>();
    }
    private void Update()
    {
        if(!goPre)    return;

        transform.position = Vector2.MoveTowards(transform.position, inventory.itemSlot[inventoryNum].transform.position, 25 * Time.deltaTime);

        if(Vector2.Distance(transform.position,inventory.itemSlot[inventoryNum].transform.position) < 0.5f)
        {
            goPre = false;
            image.raycastTarget = true;
            transform.position = inventory.itemSlot[inventoryNum].transform.position;
        }
    }
}