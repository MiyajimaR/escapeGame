using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//棒

public class DropArea5 : DropArea
{
    protected override void dropMethod(int DroppedItemID)
    {
        switch(DroppedItemID)
        {
            case 3:
                invent.UseItem(3);
                itemManager.stickHook = true;
                initItemGetButton init = gameObject.GetComponent<initItemGetButton>();
                init.canGet = true;
                break;
        }
    }

    public void stickButton()
    {
        if(itemManager.stickHook)
        {
            itemManager.stickHook = false;
        }
        else
        {
            Debug.Log("手が届かない");
        }
    }
}
