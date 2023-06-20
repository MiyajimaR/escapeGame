using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ImageChange))]
public class inImageChange : MonoBehaviour
{
    private ImageChange imageChange;
    [SerializeField]private GameObject[] ActiveGameObject;
    [SerializeField]private int[] GameObjectNumbers;
    
    private void Start()
    {
        imageChange = GetComponent<ImageChange>();

        ItemMethod(false);
    } 
    public void inImageChangeMethod(bool bo)
    {
        ItemMethod(bo); 
    }

    private void ItemMethod(bool act)
    {
        for(int i = 0; i < ActiveGameObject.Length; i++)
        {
            if(GameObjectNumbers[i] < 0)
            {
                ActiveGameObject[i].SetActive(act);
            }
            else
            {
                int num = GameObjectNumbers[i];

                if(!GameManager.GotItemManager[num])
                {
                    ActiveGameObject[i].SetActive(act);
                }
            }
        }
    }
}
