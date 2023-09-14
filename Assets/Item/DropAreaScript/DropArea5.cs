using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea5 : DropArea
{
    protected override void dropMethod(int DroppedItemID)
    {
        switch(DroppedItemID)
        {
            case 3:
                invent.UseItem(3);
                itemManager.stickHook = true;
                break;
        }
    }

    public void stickButton()
    {
        if(itemManager.stickHook)
        {
            invent.GetItem(4);
        }
        else
        {
            Debug.Log("手が届かない");
        }
    }
}
