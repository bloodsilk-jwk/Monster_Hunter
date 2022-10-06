using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵� �ӵ�
    private float MoveSpeed = 5f;
    // ������
    private float JumpPower = 500f;
    // ���� Ƚ��
    private int JumpCount = 0;

    // Rigidbody2D �޾ƿ���
    Rigidbody2D PlayerRigidbody;

    // Animator �޾ƿ���
    Animator PlayerAnimator;

    // ���� ��Ҵ��� Ȯ��
    private bool ifLanded;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float MoveInput = Input.GetAxis("Horizontal");
        Vector3 MoveDirection = new Vector3(MoveInput, 0, 0);
        transform.position += MoveDirection * MoveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        // Space�ٸ� ������, ���� Ƚ���� 0���̳� 1���̸�
        if(Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            // ���� Ƚ�� ����
            JumpCount++;

            // ���� ������ �ӵ��� ���������� (0,0)���� ����;
            PlayerRigidbody.velocity = Vector3.zero;

            // �������� ���ֱ�
            PlayerRigidbody.AddForce(new Vector3(0, JumpPower, 0));
        }
        //  Space�ٿ� ���� ����, ���� �ӵ��� 0���� ũ�ٸ� (���� ������ �ߴٸ�)
        else if(Input.GetKeyUp(KeyCode.Space) && PlayerRigidbody.velocity.y > 0)
        {
            // �۰� ����
            PlayerRigidbody.velocity *= 0.5f;
        }
        PlayerAnimator.SetBool("ifLanded", ifLanded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == ("Ground"))
        {
            ifLanded = true;
            JumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ifLanded = false;
    }
}
