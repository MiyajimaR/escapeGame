using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Utage;

public class ResumeScript : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI eduText;
    [SerializeField]private TextMeshProUGUI motivaText;
    [SerializeField]private TextMeshProUGUI reqText;
    [SerializeField]private PCManager Pmanager;

    private int _eduSelect,_motivaSelect,_reqSelect = 0;

    public int eduSelect
    {
        get{return _eduSelect; }
        set
        {
            if(_eduSelect != value)
            {
                _eduSelect = value;
                ChangeEdu();
            }
        }
    }
    public int motivaSelect
    {
        get{return _motivaSelect; }
        set
        {
            if(_motivaSelect != value)
            {
                _motivaSelect = value;
                ChangeMoti();
            }
        }
    }
    public int reqSelect
    {
        get{return _reqSelect; }
        set
        {
            if(_reqSelect != value)
            {
                _reqSelect = value;
                ChangeReq();
            }
        }
    }
    private void Start()
    {
        if(_eduSelect == 0)
        {
            eduText.text = null;
        }
        if(_motivaSelect == 0)
        {
            motivaText.text = null;
        }
        if(_reqSelect == 0)
        {
            reqText.text = null;
        }
    }

    private void ChangeEdu()
    {
        switch(_eduSelect)
        {
            case 1:
                eduText.text = "東側大学 文学部 日本文学科 入学\n東側大学 文学部 日本文学科 卒業";
                break;
            case 2:
                eduText.text = "ウルトラ大学 エキスパート学科 入学\nウルトラ大学 エキスパート学科 卒業";
                break;
        }
        StartCoroutine("textChange",eduText);
    }
    private void ChangeMoti()
    {
        switch(_motivaSelect)
        {
            case 1:
                motivaText.text = "世間体と経済的な安定のため、貴社を選びました。楽な環境で働くことで充実した日々を過ごしたいと思っています。";
                break;
            case 2:
                motivaText.text = "新しい環境で成長し、チームと共に挑戦する機会に魅力を感じ、自己成長と組織貢献を目指したいと思い志望しました。";
                break;
        }
        StartCoroutine("textChange",motivaText);
    }
    private void ChangeReq()
    {
        switch(_reqSelect)
        {
            case 1:
                reqText.text = "年収は一千万円以上を希望する。";
                break;
            case 2:
                reqText.text = "貴社の規定に従います。";
                break;
        }
        StartCoroutine("textChange",reqText);
    }
    IEnumerator textChange(TextMeshProUGUI TextMesh)
    {
        //一文字づつ増やす
        var wait = new WaitForSeconds(0.05f);

        for(int i = 0; i < TextMesh.text.Length; i++)
        {
            TextMesh.maxVisibleCharacters = i;
            yield return wait;
        }

        TextMesh.maxVisibleCharacters = TextMesh.text.Length;
        Pmanager.SendEmail();
    }   
}
