using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    public GameObject AttackPrefab;

    public GameObject Enemy;

    public EnemyController EController;

    private float speed = 10f;

    private float SpawnTime = 0.45f;
    private float TimeAfterSpawn;

    private int SpawnCount = 1;

    private bool temp;

    // Start is called before the first frame update
    void Start()
    {
        TimeAfterSpawn = 0f;
        temp = EController.Renderer.flipX;
    }

    // Update is called once per frame
    void Update()
    {
        if(EController.CurrentHp == 0)
        {
            return;
        }
        TimeAfterSpawn += Time.deltaTime;

        if (TimeAfterSpawn >= SpawnTime && SpawnCount <= 3)
        {
            GameObject Attack = Instantiate(AttackPrefab);
            Attack.transform.position = Enemy.transform.position;

            Rigidbody2D AttackRigidbody = Attack.GetComponent<Rigidbody2D>();

            Vector2 AttackVector2 = Vector2.zero;
            if (EController.Renderer.flipX == false)
            {
                AttackVector2.x = 1;
            }
            else
            {
                AttackVector2.x = -1;
            }
            AttackRigidbody.velocity = AttackVector2 * speed;

            SpawnCount++;
            TimeAfterSpawn = 0f;
        }

        if (temp != EController.Renderer.flipX)
        {
            SpawnCount = 0;
            temp = EController.Renderer.flipX;
        }
    }
}
