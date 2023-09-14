using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea3 : DropArea
{
    initItemGetButton init = null;

    private void Start()
    {
        init = gameObject.GetComponent<initItemGetButton>();
        init.canGet = itemManager.Item1_canGet;
    }
    protected override void dropMethod(int DroppedItemID)
    {
        switch(DroppedItemID)
        {
            case 0:
                break;
            case 2:
                itemManager.Item1_canGet = true;
                init.canGet = true;
                invent.UseItem(2);
                break;
        }
    }
    public void mirrorButton()
    {
        if(!itemManager.Item1_canGet)
        {
            advController.JumpScenario("DropArea3_Item1Button");
        }
    }
}
