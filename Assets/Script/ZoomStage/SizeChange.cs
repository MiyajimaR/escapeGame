using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChange : MonoBehaviour
{
    [SerializeField]private float Xsize;
    [SerializeField]private float Ysize;

    private Vector2 nowVector2;
    private Vector2 nowSize;

    void Start()
    {
        nowVector2 = transform.localScale;
        nowSize = transform.localScale;
    }

    public void CnageSize()
    {
        if(nowSize == nowVector2)
        {
            //変更なし
            transform.localScale = new Vector2(Xsize,Ysize);
            nowSize = transform.localScale;
        }
        else
        {
            transform.localScale = nowVector2;
            nowSize = transform.localScale;
        }
        
    }
}
