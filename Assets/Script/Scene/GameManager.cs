using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //今持っているアイテム
    public static int[] ItemManager = new int[5]{-1,-1,-1,-1,-1};
    

    //入手済みのアイテム判定
    public static bool[] GotItemManager = new bool[30];  //とりあえず初期化、あとで増やして29をスパナの2本目にしている




    //-----------以下は機能関係------------------------

    private void Awake()
    {
        Application.targetFrameRate = 30;

        if(ES3.FileExists("SaveFile.es3"))
        {
            Debug.Log("ファイルがあった");
        //    ES3.DeleteFile("SaveFile.es3");
            ES3AutoSaveMgr.Current.Load();
        }
        
    }

    

    void OnApplicationPause(bool pauseStatus)
    {
       if (pauseStatus)
        {
            // アプリがバックグラウンドに移動した場合の処理
            Debug.Log("アプリがバックグラウンドに移動しました");
        }
       else
        {
            // アプリがフォアグラウンドに戻った場合の処理
            Debug.Log("アプリがフォアグラウンドに戻りました");
        }
    }

    void OnApplicationQuit()
    {
        // アプリが閉じられた場合の処理
        Debug.Log("アプリが閉じられました");

        // To save
        ES3AutoSaveMgr.Current.Save();

    }
}
