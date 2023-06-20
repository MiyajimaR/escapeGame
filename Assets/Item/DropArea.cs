using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour,IDropHandler
{
    [System.NonSerialized]public bool Dropped = false;
    [System.NonSerialized]public int DroppedItemID;
    private ItemDrag itemDrag;

    public void OnDrop(PointerEventData eventData)
    {
        itemDrag = eventData.pointerDrag.GetComponent<ItemDrag>();
        
        if(itemDrag == null)
        {
            return;
        }

        DroppedItemID = itemDrag.ItemNumber;
        Dropped = true;

        //Debug.Log(gameObject.name + "に" + DroppedItemID + "がドロップされた");
    }
}