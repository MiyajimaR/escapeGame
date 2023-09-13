using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour,IDropHandler
{
    [System.NonSerialized]public int DroppedItemID;
    private ItemDrag itemDrag;
    [SerializeField]protected AdvEngineController advController;
    [SerializeField]protected Inventory invent;
    [SerializeField]protected ItemManager itemManager;

    public void OnDrop(PointerEventData eventData)
    {
        itemDrag = eventData.pointerDrag.GetComponent<ItemDrag>();
        
        if(itemDrag == null)
        {
            return;
        }

        DroppedItemID = itemDrag.ItemNumber;

        dropMethod(DroppedItemID);
        //Debug.Log(gameObject.name + "に" + DroppedItemID + "がドロップされた");
    }

    protected virtual void dropMethod(int DroppedItemID)
    {
        Debug.Log("これは親オブジェ");
    }
}