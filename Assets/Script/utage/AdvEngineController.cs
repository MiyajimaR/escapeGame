using System;
using System.Collections;
using UnityEngine;
using Utage;
using UtageExtensions;
 
public class AdvEngineController : MonoBehaviour
{
<<<<<<< HEAD
=======
    [SerializeField]private ResumeScript resumeScript;
    private bool init = false;


>>>>>>> cae8b69e0bf79ce51246141e7c56c475a9358c30
    // ADVエンジン
    public AdvEngine AdvEngine { get { return advEngine; } }
    [SerializeField]
    protected AdvEngine advEngine;
 
    //再生中かどうか
    public bool IsPlaying { get; private set; }
 
    float defaultSpeed = -1;
 
    //指定のラベルのシナリオを再生する
    public void JumpScenario(string label)
    {
        StartCoroutine(JumpScenarioAsync(label, null));
    }
 
    //指定のラベルのシナリオを再生する
    //終了した時にonCompleteが呼ばれる
    public void JumpScenario(string label, Action onComplete)
    {
        StartCoroutine(JumpScenarioAsync(label, onComplete));
    }
 
    IEnumerator JumpScenarioAsync(string label, Action onComplete)
    {
        IsPlaying = true;
        AdvEngine.JumpScenario(label);
        while (!AdvEngine.IsEndOrPauseScenario)
        {
            yield return null;
        }
        IsPlaying = false;
        if(onComplete !=null) onComplete();
    }
 
    //指定のラベルのシナリオを再生する
    //ラベルがなかった場合を想定
    public void JumpScenario(string label, Action onComplete, Action onFailed)
    {
        JumpScenario(label, null, onComplete, onFailed);
    }
 
    //指定のラベルのシナリオを再生する
    //ラベルがなかった場合を想定
    public void JumpScenario(string label, Action onStart, Action onComplete, Action onFailed)
    {
        if (string.IsNullOrEmpty(label))
        {
            if(onFailed!=null)onFailed();
            Debug.LogErrorFormat("シナリオラベルが空です");
            return;
        }
        if (label[0] == '*')
        {
            label = label.Substring(1);
        }
        if (AdvEngine.DataManager.FindScenarioData(label) == null)
        {
            if(onFailed!=null)onFailed();
            Debug.LogErrorFormat("{0}はまだロードされていないか、存在しないシナリオです", label);
            return;
        }
 
        if (onStart != null) onStart();
        JumpScenario(
            label,
            onComplete);
    }
         
    //シナリオの呼び出し以外に、
    //AdvEngineを操作する処理をまとめておくと、便利
    //何が必要かはプロジェクトによるので、場合によって増やしていく
 
    //以下、メッセージウィンドのテキスト表示速度を操作する処理のサンプル
 
    //メッセージウィンドのテキスト表示の速度を指定のスピードに
    public void ChangeMessageSpeed( float  speed)
    {
        if (defaultSpeed < 0 )
        {
            defaultSpeed = AdvEngine.Config.MessageSpeed;
        }
        AdvEngine.Config.MessageSpeed = speed;
    }
    //メッセージウィンドのテキスト表示の速度を元に戻す
    public void ResetMessageSpeed()
    {
        if (defaultSpeed >= 0)
        {
            AdvEngine.Config.MessageSpeed = defaultSpeed;
        }
    }

    public void UtageStringParam(string StringParam)
    {
        advEngine.Param.SetParameterString("GetItemParam",StringParam);
    }

<<<<<<< HEAD
=======
                

    private void Update()//オートセーブの初期化、それぞれ使用しているスクリプトでのセーブ有効化が必要
    {
        if (!advEngine.Param.IsInit || init) return;
        

        init = true;
        advEngine.Param.SetParameterInt("eduParam",resumeScript.eduSelect);
        advEngine.Param.SetParameterInt("motiParam",resumeScript.motivaSelect);
        advEngine.Param.SetParameterInt("reqParam",resumeScript.reqSelect);
            
        
    }
    public void OnSelectParamInEscape()  //選択肢のたび更新される
    {
        resumeScript.eduSelect = advEngine.Param.GetParameterInt("eduParam");
        resumeScript.motivaSelect = advEngine.Param.GetParameterInt("motiParam");
        resumeScript.reqSelect = advEngine.Param.GetParameterInt("reqParam");
    }
>>>>>>> cae8b69e0bf79ce51246141e7c56c475a9358c30
}

    /*private void UtageParameterControll() //engineはAdvEngineのこと
        {
            //パラメーターの取得
            var obj  = advEngine.Param.GetParameter("パラメーター名");
            //実際に使うときは型キャストする。ボクシングといってAlloc（メモリ確保）が発生してしまう。
            float hoge = (float)advEngine.Param.GetParameter("hoge");
            //型指定済みの取得を使えばキャストはいらない。
            //宴3.9.8以降では内部でのボクシングも発生しない。
            string str = advEngine.Param.GetParameterString("String型のパラメーター名");
            bool flag = advEngine.Param.GetParameterBoolean("Bool型のパラメーター名");
            int point = advEngine.Param.GetParameterInt("Int型のパラメーター名");
            float f = advEngine.Param.GetParameterFloat("Float型のパラメーター名");
     
            //パラメーターの設定
            advEngine.Param.SetParameter("パラメーター名",hoge);
     
            //型指定済みの設定方法
            advEngine.Param.SetParameterString("String型のパラメーター名","設定したい文字列");
            advEngine.Param.SetParameterBoolean("Bool型のパラメーター名",true);
            advEngine.Param.SetParameterInt("Int型のパラメーター名",100);
            advEngine.Param.SetParameterFloat("Float型のパラメーター名",0.1f);
        }*/
    