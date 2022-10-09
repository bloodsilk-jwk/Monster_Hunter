using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 MoveDirection;

    private float MoveSpeed = 3f;

    private float MaxRange;
    private float MinRange;

    public int CurrentHp = 3;

    private Animator EnemyAnimator;

    public SpriteRenderer Renderer;

    private Rigidbody2D EnemyRigidbody;

    private bool ifDead;

    // Start is called before the first frame update
    void Start()
    {
        MaxRange = transform.position.x + 2f;
        MinRange = transform.position.x - 2f;
        Renderer = GetComponentInChildren<SpriteRenderer>();
        MoveDirection = new Vector3(1, 0, 0);
        EnemyAnimator = GetComponent<Animator>();
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        ifDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ifDead)
        {
            return;
        }

        if (CurrentHp == 0 && ifDead == false)
        {
            EnemyAnimator.SetTrigger("Die");
            EnemyRigidbody.velocity = Vector3.zero;
            Destroy(gameObject, 1f);
            ifDead = true;
            return;
        }

        Move();
    }

    private void Move()
    {
        // 이동 방향 설정 + 이동 설정
        transform.position += MoveDirection * MoveSpeed * Time.deltaTime;

        // 최대로 갔으면 방향 전환
        if (transform.position.x >= MaxRange)
        {
            MoveDirection.x = -1;
            Renderer.flipX = true;
        }
        else if (transform.position.x <= MinRange)
        {
            MoveDirection.x = 1;
            Renderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            CurrentHp--;
        }
    }
}
