using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PCManager : MonoBehaviour
{
    [SerializeField]private EventSystem eventSystem;
    [SerializeField]private AdvEngineController adv;
    [SerializeField]private transition tra;
    [SerializeField]private GameObject mailPanel,wordPanel;
    [SerializeField]private ResumeScript resumeScript;
    [SerializeField]private GameObject alphaPanel;
    [SerializeField]private GameObject blackPanel;
    private RectTransform rect = null;

    public List<GameObject> mailContents = new List<GameObject>();
    [SerializeField]private GameObject scrollContent;
    [SerializeField]private GameObject[] preMailContents;

    private Vector2 nowPanelPos;

    public void SendEmail()
    {
        if(resumeScript.eduSelect != 0 && resumeScript.motivaSelect != 0 && resumeScript.reqSelect != 0) //全部の項目が書いてあったら
        {
            if(adv.IsPlaying)
            {
                Invoke("SendEmail",0.5f);
                return;
            }
            else
            {
                StartCoroutine("sendEmail");
            }
        }
    }
    private IEnumerator sendEmail()
    {
        alphaPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        wordPanel.SetActive(false);
        adv.JumpScenario("sendEmail");

        yield return new WaitForSeconds(1f);

        mailPanel.SetActive(true);

        alphaPanel.SetActive(false);
    }
    public void StartMeetApp()
    {
        alphaPanel.SetActive(true);
        StartCoroutine("startingmeetApp");
    }
    public void StartingApp(GameObject appPanel)
    {
        alphaPanel.SetActive(true);
        StartCoroutine("startingApp",appPanel);
    }
    public void ShutApp(GameObject appPanel)
    {
        alphaPanel.SetActive(true);
        StartCoroutine("shutApp",appPanel);
    }
    private IEnumerator startingmeetApp()
    {
        if(rect == null)
        {
            rect = blackPanel.GetComponent<RectTransform>();
        }
        Vector2 oldPos = blackPanel.transform.position;
        Vector2 oldScale = rect.sizeDelta;
        blackPanel.SetActive(true);

        GameObject obj = eventSystem.currentSelectedGameObject;
        blackPanel.transform.position = obj.transform.position;
        nowPanelPos = obj.transform.position;

        var wait = new WaitForSeconds(0.03f);
        float rex = 0f;
        float rey = 0f;
        for(int i = 0; i < 5; i++)
        {
            rex += rect.sizeDelta.x  / 5f;
            rey += rect.sizeDelta.y / 5f;
            rect.sizeDelta = new Vector2(rex,rey);
            yield return wait;
        }
        

        tra.xTransitionButton(-1);

        alphaPanel.SetActive(false);
        blackPanel.SetActive(false);
        blackPanel.transform.position = oldPos;
        rect.sizeDelta = oldScale;
    }
    private IEnumerator startingApp(GameObject appPanel)
    {
        if(rect == null)
        {
            rect = blackPanel.GetComponent<RectTransform>();
        }
        Vector2 oldPos = blackPanel.transform.position;
        Vector2 oldScale = rect.sizeDelta;
        Vector2 oldDelta = blackPanel.GetComponent<RectTransform>().sizeDelta;
        blackPanel.SetActive(true);

        GameObject obj = eventSystem.currentSelectedGameObject;
        blackPanel.transform.position = obj.transform.position;
        nowPanelPos = obj.transform.position;

        var wait = new WaitForSeconds(0.03f);
        
        float rex = 0f;
        float rey = 0f;
        for(int i = 0; i < 5; i++)
        {
            rex += rect.sizeDelta.x  / 5f;
            rey += rect.sizeDelta.y / 5f;
            rect.sizeDelta = new Vector2(rex,rey);
            yield return wait;
        }

        appPanel.SetActive(true);
        
        alphaPanel.SetActive(false);
        blackPanel.SetActive(false);
        blackPanel.transform.position = oldPos;
        rect.sizeDelta = oldScale;
    }
    private IEnumerator shutApp(GameObject appPanel)
    {
        Vector2 oldPos = blackPanel.transform.position;
        Vector2 oldScale = rect.sizeDelta;
        blackPanel.transform.position = nowPanelPos;
        blackPanel.SetActive(true);

        appPanel.SetActive(false);

        var wait = new WaitForSeconds(0.03f);
        float rex = rect.sizeDelta.x;
        float rey = rect.sizeDelta.y;
        for(int i = 0; i < 5; i++)
        {
            rex -= rect.sizeDelta.x  / 5f;
            rey -= rect.sizeDelta.y / 5f;
            rect.sizeDelta = new Vector2(rex,rey);
            yield return wait;
        }
        blackPanel.SetActive(false);
        blackPanel.transform.position = oldPos;
        rect.sizeDelta = oldScale;
        alphaPanel.SetActive(false);
    }

    private void newMailContents()
    {
        for(int i = 0; i < preMailContents.Length; i++)
        {
            preMailContents[i].SetActive(false);
        }
        scrollContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0,(mailContents.Count * 300f) + 150f);

        for(int i = 0; i < mailContents.Count; i++)
        {
            mailContents[i].SetActive(true);
            mailContents[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, (i * 300f) + 150f);
        }
    }
    public void newMail(int mailNum)  //メールを追加する場合これを使う。事前にメールの内容はpreに入れておく
    {
        mailContents.Add(preMailContents[mailNum]);
        newMailContents();
    }
    private void Start()
    {
        newMailContents();
    }
}
