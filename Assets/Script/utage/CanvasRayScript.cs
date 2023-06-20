using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRayScript : MonoBehaviour
{
    [SerializeField]private GraphicRaycaster[] graphicRay;

    void Start()
    {
        for(int i = 0; i < graphicRay.Length; i++)
        {
            graphicRay[i] = graphicRay[i].GetComponent<GraphicRaycaster>();
        }
    }
    public void PageStart()
    {
        for(int i = 0; i < graphicRay.Length; i++)
        {
            graphicRay[i].enabled = false;
        }
    }
    public void PageEnd()
    {
        for(int i = 0; i < graphicRay.Length; i++)
        {
            graphicRay[i].enabled = true;
        }
    }
}
