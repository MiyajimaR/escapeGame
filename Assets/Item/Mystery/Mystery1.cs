using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mystery1 : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textMesh;
    [SerializeField]private TMP_Dropdown dropdown;
    [SerializeField]private TMP_Dropdown dropdown1;
    [SerializeField]private TMP_Dropdown dropdown2;
    [SerializeField]private TMP_Dropdown dropdown3;

    [SerializeField]private Button DisplayButton;
    [SerializeField]private PopNotMove notMoveScript;

    [SerializeField]private transition tran;
    [SerializeField]private GameObject pc;

    private void OnEnable()
    {
        textMesh.text = "PASSWORD?";
        StartCoroutine("textChange",textMesh);
    }
    
    public void EnterDropdown()
    {
        if(dropdown.value == 3 && dropdown1.value == 2 && dropdown2.value == 5 && dropdown3.value == 1)
        {
            textMesh.text = "Login!!";
            StartCoroutine("textChange",textMesh);
            LoginPCButton();
        }
        else
        {
            textMesh.text = "INCORRECT";
            StartCoroutine("textChange",textMesh);
        }
    }
    public void LoginPCButton()
    {
        tran.xTransitionButton(3);
        gameObject.SetActive(false);
        pc.SetActive(false);
    }

    IEnumerator textChange(TextMeshProUGUI TextMesh)
    {
        
        //一文字づつ増やす
        var wait = new WaitForSeconds(0.1f);

        for(int i = 0; i < TextMesh.text.Length; i++)
        {
            TextMesh.maxVisibleCharacters = i;
            yield return wait;
        }

        TextMesh.maxVisibleCharacters = TextMesh.text.Length;
    }   
}
