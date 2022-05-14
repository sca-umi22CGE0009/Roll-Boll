using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 7; //動く速さ
    public float jumpPower;//ジャンプ
    public Text scoreText;　//スコアのUI
    public Text winText;   //リザルトのUI

    private Rigidbody rb;
    private int score;      //スコア
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //UIを初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpPower;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            // スコアを加算します
            score = score + 1;

            // UI の表示を更新します
            SetCountText();
        }
    }

    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= 12)
        {
            // リザルトの表示を更新
            winText.text = "You Win!";
        }
        }
}
