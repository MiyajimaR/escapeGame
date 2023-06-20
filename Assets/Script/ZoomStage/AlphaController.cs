using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaController : MonoBehaviour
{
    [HideInInspector]public bool alphaFinish = false;

    public void alphaStart(Image ima)
    {
        alphaFinish = false;
        StartCoroutine("AlphaStart",ima);
    }
    IEnumerator AlphaStart(Image image)
    {
        float al = image.color.a;
        float re = image.color.r;
        float gr = image.color.g;
        float bl = image.color.b;

        var wait = new WaitForSeconds(0.04f);

        while(al < 1)
        {
            al += 0.05f;
            image.color = new Color(re,gr,bl,al);

            yield return wait;
        }

        alphaFinish = true;
    }

    public void alphaEnd(Image ima)
    {
        alphaFinish = false;
        StartCoroutine("AlphaEnd",ima);
    }
    IEnumerator AlphaEnd(Image image)
    {
        float al = image.color.a;
        float re = image.color.r;
        float gr = image.color.g;
        float bl = image.color.b;

        var wait = new WaitForSeconds(0.04f);

        while(al > 0)
        {
            al -= 0.05f;
            image.color = new Color(re,gr,bl,al);

            yield return wait;
        }
        alphaFinish = true;
    }
}
