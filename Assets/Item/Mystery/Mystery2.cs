using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キッチンの南京錠
public class Mystery2 : MonoBehaviour
{
    [SerializeField]private Button thisButton;
    private bool _openLock = false;
    [HideInInspector]public bool firstUse = false;
    [SerializeField]private ImageChange imageChange;
    [SerializeField]private GameObject kitchenObj;
    private RectTransform rect;

    [SerializeField]private GameObject[] destroyObj;

    public bool openLock
    {
        get{return _openLock; }
        set
        {
            if(value)
            {
                _openLock = value;
                thisButton.onClick.RemoveListener(Shake);
                thisButton.onClick.AddListener(imageChange.ChangeImage);
            }
        }
    }

    private void Start()
    {
        rect = kitchenObj.GetComponent<RectTransform>();

        if(openLock)
        {
            for(int i = 0; i < destroyObj.Length; i++)
            {
                Destroy(destroyObj[i]);
                destroyObj[i] = null;
            }
        }

        if(!openLock)
        {
            thisButton.onClick.AddListener(Shake);
            thisButton.onClick.RemoveListener(imageChange.ChangeImage);
        }
        openLock = _openLock;
    }
    public void Shake()
    {
        StartCoroutine("shake");
    }
    IEnumerator shake()
    {
        float oldPos = rect.anchoredPosition.x;
        float YoldPos = rect.anchoredPosition.y;

        var wait = new WaitForSeconds(0.04f);

        for(int i = 0; i < 6; i++)
        {
            float xPos = 0f;

            if(i == 0)
            {
                xPos = rect.anchoredPosition.x + 5f;
            }
            else if(i == 5)
            {
                xPos = rect.anchoredPosition.x - 5f;
            }
            else if(i == 1 || i == 3)
            {
                xPos = rect.anchoredPosition.x - 10f;
            }
            else
            {
                xPos = rect.anchoredPosition.x + 10f;
            }

            rect.anchoredPosition = new Vector2(xPos,YoldPos);
            yield return wait;
        }

        rect.anchoredPosition = new Vector2(oldPos,YoldPos);
    }
}
