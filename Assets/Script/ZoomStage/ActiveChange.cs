using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ImageChange))]
public class ActiveChange : MonoBehaviour
{
    private ImageChange imageChange;
    [SerializeField]private GameObject[] ActiveObject;

    private void Start()
    {
        imageChange = GetComponent<ImageChange>();
    }

    public void Active_ImageChange()
    {
        if(imageChange.changeImage)
        {
            for(int i = 0; i < ActiveObject.Length; i++)
            {
                ActiveObject[i].SetActive(true);
            }
            
        }
        else if(!imageChange.changeImage)
        {
            for(int i = 0; i < ActiveObject.Length; i++)
            {
                ActiveObject[i].SetActive(false);
            }
        }
    }
}
