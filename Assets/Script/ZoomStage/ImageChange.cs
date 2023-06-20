using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    private Image image;
    [System.NonSerialized]public bool changeImage = false;

    [SerializeField]private Sprite ChangeSprite;
    private Sprite DefaultSprite;

    [SerializeField]private bool ItemIn = false;

    private inImageChange inImage;

    void Start()
    {
        image = GetComponent<Image>();
        DefaultSprite = image.sprite;

        if(ItemIn)
        {
            inImage = GetComponent<inImageChange>();
        }
    }

    public void ChangeImage()
    {
        if(!changeImage)
        {
            image.sprite = ChangeSprite;
            changeImage = !changeImage;

            if(ItemIn)
            {
                inImage.inImageChangeMethod(true);
            }
        }
        else
        {
            image.sprite = DefaultSprite;
            changeImage = !changeImage;

            if(ItemIn)
            {
                inImage.inImageChangeMethod(false);
            }
        }

        
    }
}
