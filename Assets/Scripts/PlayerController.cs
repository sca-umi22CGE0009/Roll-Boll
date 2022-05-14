using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 7; //��������
    public float jumpPower;//�W�����v
    public Text scoreText;�@//�X�R�A��UI
    public Text winText;   //���U���g��UI

    private Rigidbody rb;
    private int score;      //�X�R�A
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //UI��������
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //�J�[�\���L�[�̓��͂��擾
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //�ړ�������ݒ�
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpPower;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �Ԃ������I�u�W�F�N�g�����W�A�C�e���������ꍇ
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // ���̎��W�A�C�e�����\���ɂ��܂�
            other.gameObject.SetActive(false);

            // �X�R�A�����Z���܂�
            score = score + 1;

            // UI �̕\�����X�V���܂�
            SetCountText();
        }
    }

    // UI �̕\�����X�V����
    void SetCountText()
    {
        // �X�R�A�̕\�����X�V
        scoreText.text = "Count: " + score.ToString();

        // ���ׂĂ̎��W�A�C�e�����l�������ꍇ
        if (score >= 12)
        {
            // ���U���g�̕\�����X�V
            winText.text = "You Win!";
        }
        }
}
