using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed; // 動く速さ
    public Text scoreText; // スコアの UI
    public Text winText; // リザルトの UI
    public Text GameOver;

    private Rigidbody rb; // Rididbody
    private int score; // スコア

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        // UI を初期化
        score = 0;
        SetCountText();

    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);
    }

    // 玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("PickUp"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            // スコアを加算します
            score = score + 1;

            // UI の表示を更新します
            SetCountText ();
        }
        if(other.gameObject.CompareTag("BadPickUp"))
        {
            SceneManager.LoadScene("GameOver");
        }
         if(other.gameObject.CompareTag("GameOver"))
         {
             SceneManager.LoadScene("GameOver");
         }
        if (other.gameObject.CompareTag("Conceal"))
        {
            SceneManager.LoadScene("Perfect");
        }

    }

    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= 15)
        {
            // リザルトの表示を更新
             SceneManager.LoadScene("Clear");
        }

    }
}
