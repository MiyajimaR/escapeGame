using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewStart : MonoBehaviour
{
    [SerializeField]private GameObject Suit_11;
    [SerializeField]private GameObject TShirt_12;
    [SerializeField]private GameObject HeartShirt_13;
    [SerializeField]private GameObject Hoodies_14;

    //ゴミの代わりに置くものを順番通り入れること
    [SerializeField]private DropArea5[] DArea5 = new DropArea5[6];
    [SerializeField]private Image[] InterviewTrashImage = new Image[6];
    [SerializeField]private ItemData itemData;
    public int nowClothes = 0; //InterviewTextで使用。0=裸、1=スーツ 2=Tシャツ 3=ハート 4=Hoodie
    

    //DropArea5を参考にImageを６個用意して変えて表示する

    public void InterviewStartMethod()
    {
        //クローゼットの服
        bool haveClothes = false;
        
        for(int i = 0; i < 10; i++)
        {
            int InventoryItemNum = GameManager.ItemManager[i];
            
            switch(InventoryItemNum)
            {
                case 11:
                    Suit_11.SetActive(false);
                    nowClothes = 1;
                    haveClothes = true;
                    break;

                case 12:
                    TShirt_12.SetActive(false);
                    nowClothes = 2;
                    haveClothes = true;
                    break;
                
                case 13:
                    HeartShirt_13.SetActive(false);
                    nowClothes = 3;
                    haveClothes = true;
                    break;

                case 14:
                    Hoodies_14.SetActive(false);
                    nowClothes = 4;
                    haveClothes = true;
                    break;

                default:
                    break;
            }  
        }
        if(!haveClothes)
        {
            Debug.Log("しまった服を準備するのを忘れた！ 仕方がないので服を着ないで面接をするしかない");
        }
        else
        {
            Debug.Log("面接官が来る前にまずは服をきよう");
        }

        //ゴミの代わりにおいてあるものを取得して表示
        for(int i = 0; i < DArea5.Length; i++)
        {
            if(DArea5[i].ItemNum != -1)  //-1だったらImageを変えずゴミのまま
            {
                InterviewTrashImage[i].sprite = itemData.ItemDataList[DArea5[i].ItemNum].itemSprite;
            }
        }
        
    }
}
