using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class transition : MonoBehaviour
{
    private const int Hol = -3000;
    private const int Ver = -4000;
    private RectTransform rect;
    [SerializeField]private DirectionData directionData;

    [HideInInspector]public int nowXPos = 0;
    [HideInInspector]public int nowYPos = 0;
    [HideInInspector]public int nowNumber = 0;

    [HideInInspector]public int FlickInt = 0;
    private bool nowShake = false;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        nowTransition();
    }
    public void xTransitionButton(int horizontal)
    {
        if(nowShake) return;

        int xTransition = horizontal * Hol;
        float yVec = transform.localPosition.y;
        transform.localPosition = new Vector2(xTransition,yVec);
        nowTransition();
    }
    public void yTransitionButton(int vertical)
    {
        if(nowShake) return;

        int yTransition = vertical * Ver;
        float xVec = transform.localPosition.x;
        transform.localPosition = new Vector2(xVec,yTransition);
        nowTransition();
    }
    public void TransitionButton(Vector2 toVec)
    {
        bool can = FlickIntBool();
        if(!can || nowShake)    return;

        float vecX = toVec.x * Hol;
        float vecY = toVec.y * Ver;
        transform.localPosition = new Vector2(vecX,vecY);

        nowTransition();
    }

    private IEnumerator cannotMove(int dir) //1,right   2, left   3,up   4,down
    {
        nowShake = true;

        float oldPos = rect.anchoredPosition.x;
        float YoldPos = rect.anchoredPosition.y;

        float movement = 30f;
        bool isY = false;

        if(dir == 1 || dir == 3)
        {
            movement = -movement;
        }
        if(dir == 3 || dir == 4)
        {
            isY = true;
        }

        var wait = new WaitForSeconds(0.03f);

        for(int i = 0; i < 13; i++)
        {
            float Pos = rect.anchoredPosition.x;

            if(isY)
            {
                Pos = rect.anchoredPosition.y;
            }

            if(i < 6)
            {
                Pos += (movement / 2);
            }
            else if(i == 11 || i == 12) 
            {
                Pos += movement;
            }
            else if(i > 6)
            {
                Pos -= movement;
            }

            if(isY)
            {
                rect.anchoredPosition = new Vector2(oldPos,Pos);
            }
            else
            {
                rect.anchoredPosition = new Vector2(Pos,YoldPos);
            }

            yield return wait;
        }

        rect.anchoredPosition = new Vector2(oldPos,YoldPos);

        nowShake = false;
    }
    private bool FlickIntBool()
    {
        if(FlickInt == 1) //右に行こうとしている
        {
            if(!directionData.canDirectionList[nowNumber].canRight)
            {
                if(!nowShake)
                    StartCoroutine("cannotMove",1);
               
                return false;
            }    
        }
        else if(FlickInt == 2)
        {
            if(!directionData.canDirectionList[nowNumber].canLeft)
            {
                if(!nowShake)
                    StartCoroutine("cannotMove",2);
                return false;
            }    
        }
        else if(FlickInt == 3)
        {
            if(!directionData.canDirectionList[nowNumber].canUp)
            {
                if(!nowShake)
                    StartCoroutine("cannotMove",3);
                return false;
            }   
        }
        else if(FlickInt == 4)
        {
            if(!directionData.canDirectionList[nowNumber].canDown)
            {
                if(!nowShake)
                    StartCoroutine("cannotMove",4);
                return false;
            } 
        }
        return true;
    }

    public void nowTransition()
    {
        nowXPos = (int)rect.anchoredPosition.x / (int)Hol;
        nowYPos = (int)rect.anchoredPosition.y / (int)Ver;

        Vector2 vec = new Vector2(nowXPos,nowYPos);

        for(int i = 0; i < directionData.canDirectionList.Count; i++)
        {
            if(directionData.canDirectionList[i].nowPos == vec)
            {
                nowNumber = i;
                return;
            }
        }
        Debug.Log("transitionの例外");
    }
}

