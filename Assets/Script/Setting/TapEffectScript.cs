using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TapEffectScript : MonoBehaviour
{
    public int objID = 0;  //0,teddybear 1,star 2,planet 3,astronaut 4,music
    [SerializeField]private int startObj;
    private List<GameObject> objPool = new List<GameObject>();
    private List<TapObjectScript> objTapComponent = new List<TapObjectScript>();

    private Vector3 StartPos;
    [SerializeField]private GameObject[] obj;

    private bool canFollow = false;
    private const float speed = 4f;

    private int objNum
    {
        get
        {
            int i = 0;
            switch(objID)
            {
                case 0:
                    i = 0;
                    break;
                case 1:
                    i =  1;
                    break;
                case 2:
                    i = Random.Range(2,6);
                    break;
                case 3:
                    i =  6;
                    break;
                case 4:
                    i = Random.Range(7,11);
                    break;
            }
            return i;
        }
        set{}
    }

    void Start()
    {
        if(objID == -1)    return;
        
        for(int i = 0; i < startObj; i++)
        {
            objPool.Add(Instantiate(obj[objNum],transform.position,Quaternion.identity));
            objTapComponent.Add(objPool[i].GetComponent<TapObjectScript>());
            objPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(objID == -1)    return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))  //クリック
        {
            StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);

            for(int i = 0; i < 6; i++)
            {
                Pooling(StartPos);
            }
        }

        if (Input.GetMouseButton(0))  //クリック中
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);

            if(Vector2.Distance(StartPos,pos) > 1f || canFollow)
            {
                canFollow = true;
                for(int i = 0; i < objPool.Count; i++)
                {
                    if(objPool[i].activeSelf)
                    {
                        objTapComponent[i].CancelInvoke();
                        objTapComponent[i].canMove = false;
                        Vector2 nowPos = objPool[i].transform.position;
                        objPool[i].transform.position = Vector2.MoveTowards(nowPos, pos, speed * Time.deltaTime);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) //クリックをやめた
        {
            canFollow = false;
            for(int i = 0; i < objPool.Count; i++)
            {
                if(objPool[i].activeSelf)
                {
                    objTapComponent[i].Invoke("dis",0.3f);
                    objTapComponent[i].canMove = true;
                    Vector2 nowPos = objPool[i].transform.position;
                }
            }
        }
#else
        // タッチされているかチェック
        if (Input.touchCount > 0) 
        {
            // タッチ情報の取得
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) 
            {
                StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);

                for(int i = 0; i < 6; i++)
                {
                    Pooling(StartPos);
                }
            }

            if (touch.phase == TouchPhase.Moved) 
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);

                if(Vector2.Distance(StartPos,pos) > 1f || canFollow)
                {
                    canFollow = true;
                    for(int i = 0; i < objPool.Count; i++)
                    {
                        if(objPool[i].activeSelf)
                        {
                            objTapComponent[i].CancelInvoke();
                            objTapComponent[i].canMove = false;
                            Vector2 nowPos = objPool[i].transform.position;
                            objPool[i].transform.position = Vector2.MoveTowards(nowPos, pos, speed * Time.deltaTime);
                        }
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended) 
            {
                canFollow = false;
                for(int i = 0; i < objPool.Count; i++)
                {
                    if(objPool[i].activeSelf)
                    {
                        objTapComponent[i].Invoke("dis",0.3f);
                        objTapComponent[i].canMove = true;
                        Vector2 nowPos = objPool[i].transform.position;
                    }
                }
            }
        }
#endif
    }

    private void Pooling(Vector2 pos)
    {
        for(int i = 0; i < objPool.Count; i++)
        {
            if(!objPool[i].activeSelf)
            {
                objPool[i].transform.position = pos;
                objPool[i].SetActive(true);

                if(objTapComponent[i] == null)
                {
                    objTapComponent[i] = objPool[i].GetComponent<TapObjectScript>();
                }
                return;
            }
        }
        objPool.Add(Instantiate(obj[objNum],pos,Quaternion.identity));
        objTapComponent.Add(objPool[objPool.Count - 1].GetComponent<TapObjectScript>());
    }

    public void ChangeEffect(int ID)
    {
        if(ID == objID)    return;

        objID = ID;
        for(int i = 0; i < objPool.Count; i++)
        {
            Destroy(objPool[i]);
            objPool[i] = null;
            objTapComponent[i] = null;
        }
        objPool.Clear();
        objTapComponent.Clear();

        if(objID == -1)    return;

        for(int i = 0; i < startObj; i++)
        {
            objPool.Add(Instantiate(obj[objNum],transform.position,Quaternion.identity));
            objTapComponent.Add(objPool[i].GetComponent<TapObjectScript>());
            objPool[i].SetActive(false);
        }
    }

}
