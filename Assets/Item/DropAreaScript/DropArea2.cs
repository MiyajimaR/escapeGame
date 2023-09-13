using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//洗面台

public class DropArea2 : DropArea
{
    protected override void dropMethod(int DroppedItemID)
    {
        int ItemNum = DroppedItemID;

        switch(ItemNum)
        {
            case 0 :
                itemManager.Item0_inWater = true;
                advController.JumpScenario("DropArea2_Item0");
                break;

        }
    }
}
