using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//mirror

public class DropArea1 : DropArea
{
    [SerializeField]private Sprite crashedMirror;

    void Start()
    {
        if(itemManager.mirrorIsCrashed)
        {
            gameObject.GetComponent<Image>().sprite = crashedMirror;
        }
        
    }

    protected override void dropMethod(int DroppedItemID)
    {
        int ItemNum = DroppedItemID;

        switch(ItemNum)
        {
            case 0:
                if(itemManager.Item0_inWater)
                {
                    advController.JumpScenario("DropArea1_Item1");
                    gameObject.GetComponent<Image>().sprite = crashedMirror;
                    itemManager.mirrorIsCrashed = true;
                    invent.UseItem(0);
                }
                else
                {
                    advController.JumpScenario("DropArea1_Item1Not");
                }
                break;

            default :
                Debug.Log("DropArea1の該当なし");
                break;
        }
    }
}
