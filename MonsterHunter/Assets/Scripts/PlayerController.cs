using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // �̵� �ӵ�
    private float MoveSpeed = 5f;
    // ������
    private float JumpPower = 350f;
    // ���� Ƚ��
    private int JumpCount = 0;

    // Rigidbody2D �޾ƿ���
    private Rigidbody2D PlayerRigidbody;

    // Animator �޾ƿ���
    private Animator PlayerAnimator;

    public SpriteRenderer Renderer;

    // ���� ��Ҵ��� Ȯ��
    public bool ifLanded;

    public bool ifDead;

    public HpController HPCon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();

        ifDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ifDead)
        {
            return;
        }

        Move();
        Jump();
    }

    void Move()
    {
        float MoveInput = Input.GetAxis("Horizontal");
        Vector3 MoveDirection = new Vector3(MoveInput, 0, 0);

        if(MoveInput != 0 && JumpCount == 0)
        {
            PlayerAnimator.SetBool("ToWalk", true);

            if (MoveInput > 0)
            {
                Renderer.flipX = false;
            }
            else if (MoveInput < 0)
            {
                Renderer.flipX = true;
            }
        }
        else
        {
            PlayerAnimator.SetBool("ToWalk", false);
        }

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

            PlayerAnimator.SetTrigger("Jump");
        }
        //  Space�ٿ� ���� ����, ���� �ӵ��� 0���� ũ�ٸ� (���� ������ �ߴٸ�)
        else if(Input.GetKeyUp(KeyCode.Space) && PlayerRigidbody.velocity.y > 0)
        {
            // �۰� ����
            PlayerRigidbody.velocity *= 0.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == ("Ground"))
        {
            JumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("DeadZone") && !ifDead)
        {
            HPCon.CurrentHp = 0f;
            Die();
        }
        if (collision.gameObject.tag == ("Attack"))
        {
            HPCon.CurrentHp -= 35f;
        }
        if (collision.gameObject.tag == ("Potion"))
        {
            HPCon.CurrentHp += 20;
        }
    }

    public void Die()
    {
        PlayerAnimator.SetTrigger("Die");

        PlayerRigidbody.velocity = Vector3.zero;

        ifDead = true;
    }
}
