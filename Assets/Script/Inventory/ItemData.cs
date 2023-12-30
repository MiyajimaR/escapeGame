using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

    
[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public List<itemData> ItemDataList = new List<itemData>();
}
[Serializable]
public class itemData
{
    public int id;
    public GameObject ObjPrefab;
    public string name;
    public Sprite itemSprite;
    public Vector2 getScale;
    public GameObject zoomObject;
}

