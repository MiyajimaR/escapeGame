using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ドロップエリアで使うスクリプト。布団が退けてありかつ何かしてあったら、など
public class ImageCheck : MonoBehaviour
{
    [SerializeField]private ImageChange[] imageChange;
    [System.NonSerialized]public bool[] Check_changeImage;
    

    private void Start()
    {
        if(imageChange == null)  return;

        Check_changeImage = new bool[imageChange.Length];

        for(int i = 0; i < imageChange.Length; i++)
        {
            imageChange[i] = imageChange[i].GetComponent<ImageChange>();
        }
    }
    public void imageCheck()
    {
        for(int i = 0; i < imageChange.Length; i++)
        {
            Check_changeImage[i] = imageChange[i].changeImage;
        }
    }
}
