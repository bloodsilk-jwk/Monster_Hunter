using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동 속도
    private float MoveSpeed = 5f;
    // 점프력
    private float JumpPower = 500f;
    // 점프 횟수
    private int JumpCount = 0;

    // Rigidbody2D 받아오기
    Rigidbody2D PlayerRigidbody;

    // Animator 받아오기
    Animator PlayerAnimator;

    // 땅에 닿았는지 확인
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
        // Space바를 누르고, 점프 횟수가 0번이나 1번이면
        if(Input.GetKeyDown(KeyCode.Space) && JumpCount < 2)
        {
            // 점프 횟수 증가
            JumpCount++;

            // 점프 직전에 속도를 순간적으로 (0,0)으로 변경;
            PlayerRigidbody.velocity = Vector3.zero;

            // 위쪽으로 힘주기
            PlayerRigidbody.AddForce(new Vector3(0, JumpPower, 0));
        }
        //  Space바에 손을 떼고, 세로 속도가 0보다 크다면 (위로 점프를 했다면)
        else if(Input.GetKeyUp(KeyCode.Space) && PlayerRigidbody.velocity.y > 0)
        {
            // 작게 점프
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
