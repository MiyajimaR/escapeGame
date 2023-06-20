using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionData : MonoBehaviour
{
    public List<canDirection> canDirectionList = new List<canDirection>();
}
[Serializable]
public class canDirection
{
    public Vector2 nowPos;

    public bool canRight = false;
    public bool canLeft = false;
    public bool canUp = false;
    public bool canDown = false;

    public Vector2 toRight;
    public Vector2 toLeft;
    public Vector2 toUp;
    public Vector2 toDown;
}
