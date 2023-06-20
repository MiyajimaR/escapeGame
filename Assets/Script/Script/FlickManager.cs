using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickManager : MonoBehaviour
{
    Vector3 _clickStartPosition = Vector2.zero;

    [SerializeField] float _threshold = 30;
    private bool nowFlick = false;
    [SerializeField]private transition tra;
    [SerializeField]private DirectionData directionData;

    public enum FlickDirection
    {
        Left,
        Right,
        Up,
        Down,
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickStartPosition = Input.mousePosition;

            if(!nowFlick)
            {
                nowFlick = true;
                Invoke("leftTimeBool",0.5f);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(!nowFlick)    return;

            CancelInvoke("leftTimeBool");
            nowFlick = false;

            Vector3 dif = Input.mousePosition - _clickStartPosition;

            //Debug.Log($"Flick: x={dif.x} y={dif.y}");

            float abs_x = Mathf.Abs(dif.x);
            float abs_y = Mathf.Abs(dif.y);

            if (abs_x >= _threshold || abs_y >= _threshold)
            {
                // 横方向
                if (abs_x > abs_y)
                {
                    Flick(dif.x > 0 ?  FlickDirection.Left : FlickDirection.Right);
                }
                // 縦方向
                else
                {
                    Flick(dif.y > 0 ? FlickDirection.Down : FlickDirection.Up);
                }
            }
        }
    }
    private void leftTimeBool()
    {
        nowFlick = false;
    }

    public void Flick(FlickDirection dir)
    {
        if(dir == FlickDirection.Left)
        {
            tra.FlickInt = 2;
            tra.TransitionButton(directionData.canDirectionList[tra.nowNumber].toLeft);
        }
        else if(dir == FlickDirection.Right)
        {
            tra.FlickInt = 1;
            tra.TransitionButton(directionData.canDirectionList[tra.nowNumber].toRight);
        }
        else if(dir == FlickDirection.Up)
        {
            tra.FlickInt = 3;
            tra.TransitionButton(directionData.canDirectionList[tra.nowNumber].toUp);
        }
        else if(dir == FlickDirection.Down)
        {
            tra.FlickInt = 4;
            tra.TransitionButton(directionData.canDirectionList[tra.nowNumber].toDown);
        }
    }

}
