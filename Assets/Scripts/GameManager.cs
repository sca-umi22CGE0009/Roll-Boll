using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized]
    public int currentStageNum = 0; //現在のステージ番号

    [SerializeField]
    string[] stageName; //ステージ名

    void Start()
    {
        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
        DontDestroyOnLoad(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //次のステージに進む処理
    public void NextStage()
    {
        currentStageNum += 1;
        //コルーチンを実行
        StartCoroutine(WaitForLoadScene());
    }
    //シーンの読み込みと待機を行うコルーチン
    IEnumerator WaitForLoadScene()
    {
        //シーンを非同期で読込し、読み込まれるまで待機する
        yield return SceneManager.LoadSceneAsync(stageName[currentStageNum]);
    }

    public void GameOver()
    {

    }
}
