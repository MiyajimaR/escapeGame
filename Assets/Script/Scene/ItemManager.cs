using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
   [SerializeField]private GameObject mirror;
   [HideInInspector]public bool Item0_inWater = false;
   [HideInInspector]public bool Item1_canGet = false;
   private bool _mirrorIsCrashed = false;
   public bool mirrorIsCrashed
   {
      get{return _mirrorIsCrashed;}
      set
      {
         Debug.Log("ifbefore");
         if(!_mirrorIsCrashed && value)
         {
            Debug.Log("ifafter");
            _mirrorIsCrashed = value;
            if(mirror != null)
            {
               mirror.SetActive(true);
            }
         }
      }
   }

   void Start()
   {
      //鏡の破片を取ったことがないor鏡が壊れていない
      if(!mirrorIsCrashed || GameManager.GotItemManager[2])
      {
         mirror.SetActive(false);
      }
   }
}
