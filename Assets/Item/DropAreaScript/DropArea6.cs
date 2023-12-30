using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utage;

public class DropArea6 : DropArea
{
    [SerializeField]private transition tranObj;
    private void Start()
    {
        tranObj = tranObj.GetComponent<transition>();
        Debug.Log(itemManager.DropArea6_DoorIsCrashed);
        
        if(!itemManager.DropArea6_DoorIsCrashed)
        {
            Button doorButton = GetComponent<Button>();
            doorButton.onClick.RemoveAllListeners();
            doorButton.onClick.AddListener(notCrashed);
        }
        else
        {
            Button doorButton = GetComponent<Button>();
            doorButton.onClick.RemoveAllListeners();
            doorButton.onClick.AddListener(() => tranObj.xTransitionButton(1));
        }
    }
    protected override void dropMethod(int DroppedItemID)
    {
        int ItemNum = DroppedItemID;

        switch(ItemNum)
        {
            case 4:
                advController.JumpScenario("DropArea6_Item4");
                invent.UseItem(4);
                itemManager.DropArea6_DoorIsCrashed = true;
                break;

            default :
                Debug.Log("DropArea4の該当なし");
                break;
        }
    }

    public void notCrashed()
    {
        advController.JumpScenario("DropArea6_notCrashed");
    }
}
