using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using Microsoft.Unity.VisualStudio.Editor;

public class ItemManager : MonoBehaviour
{
   [SerializeField]private GameObject mirror;
   [SerializeField]private Sprite toiletPaper;
   [SerializeField]private Image toiletPaperImage;
   [SerializeField]private Image mirrorDebris;
   [SerializeField]private Sprite mirrorDebrisSprite;
   [SerializeField]private GameObject showerPanel;
   [SerializeField]private GameObject showerObj;
   [SerializeField]private GameObject showerHook;



   [HideInInspector]public bool Item0_inWater = false;
   private bool _Item1_canGet = false;
   private bool _mirrorIsCrashed = false;
   private bool _showerIsCrashed = false;
   private bool _stickHook = false;



   public bool mirrorIsCrashed
   {
      get{return _mirrorIsCrashed;}
      set
      {
         if(!_mirrorIsCrashed && value)
         {
            _mirrorIsCrashed = value;
            if(mirror != null)
            {
               mirror.SetActive(true);
            }
         }
      }
   }
   public bool Item1_canGet
   {
      get{return _Item1_canGet;}
      set
      {
         if(!_Item1_canGet && value)
         {
            _Item1_canGet = value;
            mirrorDebris = mirrorDebris.GetComponent<Image>();
            mirrorDebris.sprite = mirrorDebrisSprite;
         }
      }
   }
   public bool showerIsCrashed
   {
      get{return _showerIsCrashed;}
      set
      {
         if(value)
         {
            _showerIsCrashed = value;
            Destroy(showerPanel);
            Destroy(showerObj);
            showerPanel = null;
            showerObj = null;
         }
      }
   }
   public bool stickHook
   {
      get{return _stickHook;}
      set
      {
         if(value)
         {
            _stickHook = value;
            showerHook.SetActive(true);
         }
      }
   }

   void Start()
   {
      //鏡の破片を取ったことがないor鏡が壊れていない
      if(!mirrorIsCrashed || GameManager.GotItemManager[1])
      {
         mirror.SetActive(false);
      }
      //トイレットペーパーを取っていたら芯だけにする
      if(GameManager.GotItemManager[2])
      {
         toiletPaperImage = toiletPaperImage.GetComponent<Image>();
         toiletPaperImage.sprite = toiletPaper;
      }
      //破片にトイレットペーパーが巻き付いている状態
      if(Item1_canGet)
      {
         mirrorDebris = mirrorDebris.GetComponent<Image>();
         mirrorDebris.sprite = mirrorDebrisSprite;
      }
      //シャワーを壊したらオブジェクトも壊す
      if(showerIsCrashed || GameManager.GotItemManager[3])
      {
         Destroy(showerPanel);
         Destroy(showerObj);
         showerPanel = null;
         showerObj = null;
      }
      //棒にシャワーをひっかけている
      if(stickHook)
      {
         showerHook.SetActive(true);
      }
   }
}
