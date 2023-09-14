using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea4 : DropArea
{
    protected override void dropMethod(int DroppedItemID)
    {
        switch(DroppedItemID)
        {
            case 1:
                advController.JumpScenario("DropArea4_Item1");
                invent.UseItem(1);
                invent.GetItem(3);
                itemManager.showerIsCrashed = true;
                break;
        }
    }
}
