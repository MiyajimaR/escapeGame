using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea3 : DropArea
{
    protected override void dropMethod(int DroppedItemID)
    {
        switch(DroppedItemID)
        {
            case 0:
                break;
        }
    }
    public void mirrorButton()
    {
        if(itemManager.Item1_canGet)
        {
            invent.GetItem(1);
        }
        else
        {
            advController.JumpScenario("DropArea3_Item1Button");
        }
    }
}
