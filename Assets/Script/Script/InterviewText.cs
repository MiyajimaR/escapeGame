using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterviewText : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI InnerText;
    private InterviewStart inStart;
    private WaitForSeconds wait_01 = new WaitForSeconds(0.1f);
    private bool canNext = false;
    private string textContent = null;
    private bool nowAlpha = false;
    private int phase = 1;

    private void Contents()
    {
        int waitTime = 0;

        switch(phase)
        {
            case 1:
                switch(inStart.nowClothes)
                {
                    case 0:
                        textContent = "<size=3>......裸！？</size> \n もうやだあ、お家に帰りたいよお";
                        break;

                    case 1:
                        textContent = "";//スーツの場合反応なし
                        break;

                    case 2:
                        textContent = "白Tシャツかあ。まあとりあえず面接してみるか";
                        break;
                    
                    case 3:
                        textContent = "......ほう。まあ、落ち着け。まだわからない\n 緊張でおかしな格好をしてしまっただけかもしれない";
                        break;
                    
                    case 4:
                        textContent = "......やべえ。個性が爆発してるなあ。三十分もこいつと話すのか.......。\n どうしよ";
                        break;
                        
                }
                break;
        }
        waitTime = 10;
        Invoke("NextPage",waitTime);
    }

    public void NextPage()
    {
        if(canNext && !nowAlpha)
        {
            Contents();
            InnerText.text = textContent;
            StartCoroutine("ColorAlpha"); //出現させる
        }
        else if(nowAlpha)
        {
            Invoke("WaitOneSecNext",1f);
        }
        else //nextに行けず、消している最中でもない、つまり現在文字列表示中
        {
            StartCoroutine("ColorAlpha"); //消す
            NextPage();
        }
    }
    private void PausePage() //何か反応があったらNextPageに飛ばす。それまで文字表示しっぱなしで待機する
    {

    }
    private void FinishPage() //これで終わり表示している文字を透明にする。
    {

    }
    private void WaitOneSecNext()
    {
        if(InnerText.color.a == 0)
        {
            canNext = true;
        }
        NextPage();
    }

    private void Start()
    {
        inStart = GetComponent<InterviewStart>();
    }
    IEnumerator ColorAlpha() //透明度をいじるところ
    {
        bool appear = false;
        nowAlpha = true;

        if(InnerText.color.a == 0) //つまり現在透明、これから出現
        {
            canNext = false;
            appear = true;
        }

        float col = 0f;
        for(int i = 0; i < 17; i++)
        {
            if(appear)
            {
                col = (255 - (17 - i) * 15) / 255f;
            }
            else
            {
                col = (255 - i * 15) / 255f;
            }
            
            InnerText.color = new Color(0,0,0,col);
            yield return wait_01;
        }

        if(appear)
        {
            InnerText.color = new Color(0,0,0,1);
        }
        else
        {
            InnerText.color = new Color(0,0,0,0);
            canNext = true;
        }
        nowAlpha = false;
    }
    
}
