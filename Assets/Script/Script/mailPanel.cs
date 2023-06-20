using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mailPanel : MonoBehaviour
{
    private Image image;
    [SerializeField]private bool after = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        if(!after)
        { 
            image.color = new Color(1f,1f,0,125f / 255f);
        }
        else
        {
            image.color = new Color(38f / 255f,38f / 255f,38f / 255f,125f / 255f);
        }
    }

    public void MyButton()
    {
        image.color = new Color(38f /255f,38f / 255f,38f / 255f,125f / 255f);
        after = true;
    }
}
