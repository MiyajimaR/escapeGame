using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObjectScript : MonoBehaviour
{
    [HideInInspector]public bool canMove = true;
    private float ranX;
    private float ranY;
    private float ranZ;
    private SpriteRenderer sr;

    private void OnEnable()
    {
        if(sr == null)    sr = GetComponent<SpriteRenderer>();

        Invoke("dis",0.3f);
        ranX = Random.Range(-1.5f,1.5f);
        if(ranX < 0.5f && ranX > -0.5f)
        {
            if(ranX > 0)    ranX = 0.5f;
            else    ranX = -0.5f;    
        }
        ranY = Random.Range(-1.5f,1.5f);
        if(ranY < 0.5f && ranY > -0.5f)
        {
            if(ranY > 0)    ranY = 0.5f;
            else    ranY = -0.5f;    
        }
        ranZ = Random.Range(-10f,10f);
        transform.Rotate(0f,0f,ranZ);
    }
    private void Update()
    {
        transform.Rotate(0f,0f,ranZ);
        if(!canMove)    return;

        Vector2 pos = transform.position;
        pos.x += ranX * Time.deltaTime;
        pos.y += ranY * Time.deltaTime;
        transform.position = pos;
    }
    private void dis()
    {
        StartCoroutine("AlphaStart");
    }
    private void OnDisable()
    {
        canMove = true;
        sr.color = new Color(1f,1f,1f,1f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        CancelInvoke();
    }

    IEnumerator AlphaStart()
    {
        float al = sr.color.a;

        var wait = new WaitForSeconds(0.04f);

        while(al > 0f)
        {
            al -= 0.05f;
            if(al <= 0)    al = 0f;

            sr.color = new Color(1f,1f,1f,al);

            yield return wait;
        }
        gameObject.SetActive(false);
    }
}
