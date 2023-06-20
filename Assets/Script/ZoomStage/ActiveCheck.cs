using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    [SerializeField]private GameObject[] CheckObject;
    [System.NonSerialized]public bool[] trueObject;

    public void activeCheck()
    {
        if(CheckObject == null || trueObject == null)
        {
            return;
        }

        for(int i = 0; i < CheckObject.Length; i++)
        {
            if(CheckObject[i].activeSelf)
            {
                trueObject[i] = true;
            }
            else
            {
                trueObject[i] = false;
            }
        }
    }
}
