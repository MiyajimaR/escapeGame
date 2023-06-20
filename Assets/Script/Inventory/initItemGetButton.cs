using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class initItemGetButton : MonoBehaviour
{
    //ID29をスパナの2本目にする
    public int ItemID;

    void Start()
    {
        if(GameManager.GotItemManager[ItemID])
        {
            Debug.Log("falseにする" + ItemID);
            gameObject.SetActive(false);
        }
    }

    public void Clicked()
    {
        GameManager.GotItemManager[ItemID] = true;
        gameObject.SetActive(false);       
    }
}
