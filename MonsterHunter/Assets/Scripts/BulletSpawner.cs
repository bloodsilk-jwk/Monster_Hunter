using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;

    public GameObject Player;

    public PlayerController PController;

    private float speed = 10f;

    private float SpawnTime = 1f;
    private float TimeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        TimeAfterSpawn = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PController.ifDead == true)
        {
            return;
        }

        TimeAfterSpawn += Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && TimeAfterSpawn >= SpawnTime)
        {
            TimeAfterSpawn = 0f;

            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = Player.transform.position;

            Rigidbody2D BulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            Vector2 BulletVector2 = Vector2.zero;
            if(PController.Renderer.flipX == false)
            {
                BulletVector2.x = 1;
            }
            else 
            {
                BulletVector2.x = -1;
            }
            BulletRigidbody.velocity = BulletVector2 * speed;

        }
    }
}
