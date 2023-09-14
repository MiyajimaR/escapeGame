using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class initItemGetButton : MonoBehaviour
{
    public int ItemID;
    public bool notFalse = false;
    public Inventory inventory;
    [SerializeField]private bool _canGet = true;

    public bool canGet
    {
        get{return _canGet;}
        set
        {
            if(value)
            {
                Button buttonObj = gameObject.GetComponent<Button>();
                buttonObj.onClick.AddListener(() => inventory.GetItem(ItemID));
                buttonObj.onClick.AddListener(Clicked);  
            }
        }
    }


    void Start()
    {  
        if(GameManager.GotItemManager[ItemID])
        {
            Debug.Log("falseにする" + ItemID);

            if(!notFalse)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if(canGet)
            {
                Button buttonObj = gameObject.GetComponent<Button>();
                buttonObj.onClick.AddListener(() => inventory.GetItem(ItemID));
                buttonObj.onClick.AddListener(Clicked);  
            }
        }
    }

    public void Clicked()
    {
        if(notFalse)
        {
            GameManager.GotItemManager[ItemID] = true;
        }
        else
        {
            GameManager.GotItemManager[ItemID] = true;
            gameObject.SetActive(false);    
        }
            
    }
}
